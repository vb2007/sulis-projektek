import 'dart:async';
import 'dart:convert';

import 'package:shelf/shelf.dart';
import 'package:shelf_router/shelf_router.dart';

import 'app_config.dart';
import 'database.dart';
import 'relationship_engine.dart';

/// Builds the main CRUD router. Every collection in db.json gets full REST endpoints.
Handler buildHandler({
  required JsonDatabase db,
  required AppConfig config,
}) {
  final engine = RelationshipEngine(relationships: config.relationships, db: db);
  final router = Router();

  Object wrap(Object payload) =>
      config.wrapper ? {config.wrapperKey: payload} : payload;

  // Collection index + create.
  router.get('/<collection>', (Request request, String collection) async {
    if (!db.hasCollection(collection)) return _notFound('Collection not found.');
    final params = request.url.queryParameters;
    final items = db.getCollection(
      collection,
      filters: params,
      sortField: params['_sort'],
      sortOrder: params['_order'],
      page: int.tryParse(params['_page'] ?? ''),
      limit: int.tryParse(params['_limit'] ?? ''),
    );
    // Deep-copy each item so the relationship engine doesn't mutate in-memory db records.
    final copies = items.map((e) => Map<String, dynamic>.from(e)).toList();
    final enriched = engine.apply('GET', '/$collection', copies);
    return _json(wrap(enriched));
  });

  router.post('/<collection>', (Request request, String collection) async {
    if (!db.hasCollection(collection)) return _notFound('Collection not found.');
    final body = await _parseBody(request);
    if (config.timestamps) {
      body['created_at'] = DateTime.now().toIso8601String();
      body['updated_at'] = DateTime.now().toIso8601String();
    }
    final item = db.insert(collection, body);
    return _json(wrap(item), status: 201);
  });

  // Single item: read, replace, patch, delete.
  router.get('/<collection>/<id>', (Request request, String collection, String id) async {
    final item = db.getById(collection, id);
    if (item == null) return _notFound('Item not found.');
    final enriched = engine.apply('GET', '/$collection/$id', Map<String, dynamic>.from(item));
    return _json(wrap(enriched));
  });

  router.put('/<collection>/<id>', (Request request, String collection, String id) async {
    final body = await _parseBody(request);
    if (config.timestamps) body['updated_at'] = DateTime.now().toIso8601String();
    final updated = db.replace(collection, id, body);
    if (updated == null) return _notFound('Item not found.');
    return _json(wrap(updated));
  });

  router.patch('/<collection>/<id>', (Request request, String collection, String id) async {
    final body = await _parseBody(request);
    if (config.timestamps) body['updated_at'] = DateTime.now().toIso8601String();
    final updated = db.update(collection, id, body);
    if (updated == null) return _notFound('Item not found.');
    return _json(wrap(updated));
  });

  router.delete('/<collection>/<id>', (Request request, String collection, String id) async {
    final deleted = db.delete(collection, id);
    if (!deleted) return _notFound('Item not found.');
    return _json(wrap(<String, dynamic>{}));
  });

  return router.call;
}

/// Parses JSON, urlencoded, and multipart request bodies into a map.
Future<Map<String, dynamic>> _parseBody(Request request) async {
  final contentType = request.headers['content-type'] ?? '';
  final bytes = await request.read().expand((b) => b).toList();
  final raw = utf8.decode(bytes);

  if (contentType.contains('application/json')) {
    if (raw.isEmpty) return {};
    final decoded = jsonDecode(raw);
    return decoded is Map<String, dynamic> ? decoded : {};
  }

  if (contentType.contains('application/x-www-form-urlencoded')) {
    return Uri.splitQueryString(raw).cast<String, dynamic>();
  }

  if (contentType.contains('multipart/form-data')) {
    // Parse simple multipart fields (no file uploads).
    final boundary = _extractBoundary(contentType);
    if (boundary == null) return {};
    return _parseMultipart(raw, boundary);
  }

  return {};
}

String? _extractBoundary(String contentType) {
  final match = RegExp(r'boundary=([^\s;]+)').firstMatch(contentType);
  return match?.group(1);
}

Map<String, dynamic> _parseMultipart(String body, String boundary) {
  final result = <String, dynamic>{};
  final parts = body.split('--$boundary');
  for (final part in parts) {
    final dispositionMatch =
        RegExp(r'Content-Disposition:.*name="([^"]+)"', caseSensitive: false)
            .firstMatch(part);
    if (dispositionMatch == null) continue;
    final name = dispositionMatch.group(1)!;
    final valueStart = part.indexOf('\r\n\r\n');
    if (valueStart == -1) continue;
    final value = part.substring(valueStart + 4).trim();
    if (value.isNotEmpty && !value.startsWith('--')) {
      result[name] = value;
    }
  }
  return result;
}

Response _json(Object body, {int status = 200}) => Response(
      status,
      body: jsonEncode(body),
      headers: {'content-type': 'application/json'},
    );

Response _notFound(String message) => Response.notFound(
      jsonEncode({'error': message}),
      headers: {'content-type': 'application/json'},
    );
