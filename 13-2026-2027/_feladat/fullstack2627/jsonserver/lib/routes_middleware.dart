import 'package:shelf/shelf.dart';

/// Rewrites incoming request paths according to routes.json rules.
///
/// Supports wildcard patterns with a single capture group, e.g.:
///   { "/api/*": "/$1" }  rewrites /api/posts/1 -> /posts/1
Middleware routesMiddleware(Map<String, String> rules) {
  return (Handler inner) {
    return (Request request) async {
      final originalPath = request.requestedUri.path;
      final rewritten = _rewrite(originalPath, rules);
      if (rewritten == originalPath) return inner(request);

      // Buffer the body so it can be re-streamed to the new Request.
      final bodyBytes = await request.read().toList();
      final newUri = request.requestedUri.replace(path: rewritten);
      final newRequest = Request(
        request.method,
        newUri,
        headers: request.headers,
        body: Stream.fromIterable(bodyBytes),
        context: request.context,
      );
      return inner(newRequest);
    };
  };
}

String _rewrite(String path, Map<String, String> rules) {
  for (final entry in rules.entries) {
    final pattern = entry.key.replaceAll('*', '(.+)');
    final regex = RegExp('^$pattern\$');
    final match = regex.firstMatch(path);
    if (match == null) continue;
    var target = entry.value;
    for (var i = 1; i <= match.groupCount; i++) {
      target = target.replaceAll('\$$i', match.group(i) ?? '');
    }
    return target;
  }
  return path;
}
