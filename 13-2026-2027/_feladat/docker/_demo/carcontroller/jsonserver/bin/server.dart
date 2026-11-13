import 'dart:io';

import 'package:shelf/shelf.dart';
import 'package:shelf/shelf_io.dart' as io;
import 'package:shelf_router/shelf_router.dart';

import 'package:dart_server/app_config.dart';
import 'package:dart_server/browser_ui.dart';
import 'package:dart_server/database.dart';
import 'package:dart_server/handler.dart';
import 'package:dart_server/routes_middleware.dart';

Future<void> main(List<String> args) async {
  final dataDir = Platform.environment['DATA_DIR'] ?? 'data';
  final port = int.tryParse(Platform.environment['PORT'] ?? '3000') ?? 3000;

  final db = JsonDatabase('$dataDir/db.json');
  final config = AppConfig.load('$dataDir/config.json');
  final routes = loadRoutes('$dataDir/routes.json');

  // Mount browser UI at / and delegate everything else to the CRUD handler.
  final root = Router()
    ..get('/', buildBrowserUiHandler(db))
    ..mount('/', buildHandler(db: db, config: config));

  final handler = Pipeline()
      .addMiddleware(logRequests())
      .addMiddleware(routesMiddleware(routes))
      .addHandler(root.call);

  final server = await io.serve(handler, InternetAddress.anyIPv4, port);
  print('JSON Server running on port ${server.port}');
}
