import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:test/test.dart';

/// Integration tests -- starts the server against a temporary db.json.
///
/// Run with: dart test
void main() {
  late Process process;
  late Directory tempDir;
  final port = 3099;
  final base = 'http://localhost:$port';

  setUpAll(() async {
    tempDir = Directory.systemTemp.createTempSync('dart_json_server_test');
    File('${tempDir.path}/db.json').writeAsStringSync(jsonEncode({
      'posts': [
        {'id': '1', 'title': 'Hello'},
      ],
      'comments': [
        {'id': '1', 'text': 'Great post', 'post_id': '1'},
      ],
    }));
    File('${tempDir.path}/config.json').writeAsStringSync(jsonEncode({
      'timestamps': false,
      'relationships': [
        {'source': 'posts', 'destination': 'comments', 'type': 'hasMany'},
        {'source': 'comments', 'destination': 'posts', 'type': 'belongsTo'},
      ],
    }));
    File('${tempDir.path}/routes.json').writeAsStringSync(jsonEncode({'/api/*': r'/$1'}));

    process = await Process.start(
      'dart',
      ['run', 'bin/server.dart'],
      environment: {...Platform.environment, 'PORT': '$port', 'DATA_DIR': tempDir.path},
    );
    await Future.delayed(const Duration(seconds: 3));
  });

  tearDownAll(() {
    process.kill();
    tempDir.deleteSync(recursive: true);
  });

  group('CRUD', () {
    test('GET /posts returns all posts wrapped in data', () async {
      final res = await http.get(Uri.parse('$base/posts'));
      expect(res.statusCode, 200);
      final body = jsonDecode(res.body) as Map;
      expect(body['data'], isList);
      expect((body['data'] as List).first['title'], 'Hello');
    });

    test('GET /posts/1 returns a single post', () async {
      final res = await http.get(Uri.parse('$base/posts/1'));
      expect(res.statusCode, 200);
      expect(jsonDecode(res.body)['data']['id'], '1');
    });

    test('POST /posts creates a new post with auto-id', () async {
      final res = await http.post(
        Uri.parse('$base/posts'),
        headers: {'content-type': 'application/json'},
        body: jsonEncode({'title': 'New post'}),
      );
      expect(res.statusCode, 201);
      final data = jsonDecode(res.body)['data'] as Map;
      expect(data['title'], 'New post');
      expect(data.containsKey('id'), isTrue);
    });

    test('PATCH /posts/1 updates a field', () async {
      final res = await http.patch(
        Uri.parse('$base/posts/1'),
        headers: {'content-type': 'application/json'},
        body: jsonEncode({'title': 'Updated'}),
      );
      expect(res.statusCode, 200);
      expect(jsonDecode(res.body)['data']['title'], 'Updated');
    });

    test('PUT /posts/1 replaces the item', () async {
      final res = await http.put(
        Uri.parse('$base/posts/1'),
        headers: {'content-type': 'application/json'},
        body: jsonEncode({'title': 'Replaced'}),
      );
      expect(res.statusCode, 200);
      expect(jsonDecode(res.body)['data']['title'], 'Replaced');
    });

    test('DELETE removes item and returns 200', () async {
      final created = await http.post(
        Uri.parse('$base/posts'),
        headers: {'content-type': 'application/json'},
        body: jsonEncode({'title': 'To delete'}),
      );
      final id = jsonDecode(created.body)['data']['id'];
      final res = await http.delete(Uri.parse('$base/posts/$id'));
      expect(res.statusCode, 200);
      final gone = await http.get(Uri.parse('$base/posts/$id'));
      expect(gone.statusCode, 404);
    });

    test('GET /posts/999 returns 404', () async {
      final res = await http.get(Uri.parse('$base/posts/999'));
      expect(res.statusCode, 404);
    });
  });

  group('Relationships', () {
    test('GET /posts includes hasMany comments', () async {
      final res = await http.get(Uri.parse('$base/posts'));
      final posts = jsonDecode(res.body)['data'] as List;
      final post1 = posts.firstWhere((p) => p['id'] == '1');
      expect(post1['comments'], isList);
    });

    test('GET /comments/1 includes belongsTo post', () async {
      final res = await http.get(Uri.parse('$base/comments/1'));
      final comment = jsonDecode(res.body)['data'];
      expect(comment['post'], isNotNull);
    });
  });

  group('Routes rewrite', () {
    test('/api/posts rewrites to /posts', () async {
      final res = await http.get(Uri.parse('$base/api/posts'));
      expect(res.statusCode, 200);
    });
  });

  group('Query params', () {
    test('_limit limits result count', () async {
      await http.post(Uri.parse('$base/posts'),
          headers: {'content-type': 'application/json'},
          body: jsonEncode({'title': 'Extra'}));
      final res = await http.get(Uri.parse('$base/posts?_limit=1'));
      expect((jsonDecode(res.body)['data'] as List).length, 1);
    });

    test('field filter narrows results', () async {
      // belongsTo engine replaces post_id with nested post object,
      // so we verify the filtered set is non-empty and has embedded post.
      final res = await http.get(Uri.parse('$base/comments?post_id=1'));
      expect(res.statusCode, 200);
      final data = jsonDecode(res.body)['data'] as List;
      expect(data, isNotEmpty);
      expect(data.every((c) => c['post'] != null), isTrue);
    });
  });

  group('wrapper: false', () {
    late Process proc;
    late Directory dir;
    final rawPort = 3098;
    final rawBase = 'http://localhost:$rawPort';

    setUpAll(() async {
      dir = Directory.systemTemp.createTempSync('dart_json_server_raw');
      File('${dir.path}/db.json')
          .writeAsStringSync(jsonEncode({'items': [{'id': '1', 'name': 'A'}]}));
      File('${dir.path}/config.json').writeAsStringSync(
          jsonEncode({'timestamps': false, 'wrapper': false, 'relationships': []}));
      File('${dir.path}/routes.json').writeAsStringSync(jsonEncode({}));

      proc = await Process.start(
        'dart',
        ['run', 'bin/server.dart'],
        environment: {...Platform.environment, 'PORT': '$rawPort', 'DATA_DIR': dir.path},
      );
      await Future.delayed(const Duration(seconds: 3));
    });

    tearDownAll(() {
      proc.kill();
      dir.deleteSync(recursive: true);
    });

    test('GET /items returns bare array without data wrapper', () async {
      final res = await http.get(Uri.parse('$rawBase/items'));
      expect(res.statusCode, 200);
      final body = jsonDecode(res.body);
      expect(body, isList);
      expect((body as List).first['name'], 'A');
    });

    test('GET /items/1 returns bare object without data wrapper', () async {
      final res = await http.get(Uri.parse('$rawBase/items/1'));
      expect(res.statusCode, 200);
      final body = jsonDecode(res.body);
      expect(body, isMap);
      expect((body as Map)['name'], 'A');
    });
  });

  group('wrapperKey', () {
    late Process proc;
    late Directory dir;
    final kwPort = 3097;
    final kwBase = 'http://localhost:$kwPort';

    setUpAll(() async {
      dir = Directory.systemTemp.createTempSync('dart_json_server_kw');
      File('${dir.path}/db.json')
          .writeAsStringSync(jsonEncode({'things': [{'id': '1', 'val': 'x'}]}));
      File('${dir.path}/config.json').writeAsStringSync(jsonEncode({
        'timestamps': false,
        'wrapper': true,
        'wrapperKey': 'result',
        'relationships': [],
      }));
      File('${dir.path}/routes.json').writeAsStringSync(jsonEncode({}));

      proc = await Process.start(
        'dart',
        ['run', 'bin/server.dart'],
        environment: {...Platform.environment, 'PORT': '$kwPort', 'DATA_DIR': dir.path},
      );
      await Future.delayed(const Duration(seconds: 3));
    });

    tearDownAll(() {
      proc.kill();
      dir.deleteSync(recursive: true);
    });

    test('GET /things uses custom wrapperKey "result"', () async {
      final res = await http.get(Uri.parse('$kwBase/things'));
      expect(res.statusCode, 200);
      final body = jsonDecode(res.body) as Map;
      expect(body.containsKey('result'), isTrue);
      expect(body.containsKey('data'), isFalse);
      expect((body['result'] as List).first['val'], 'x');
    });
  });
}
