import 'app_config.dart';
import 'database.dart';
import 'pluralize.dart';

/// Applies relationship side-loading to response data, mirroring the original
/// Node.js implementation's hasMany / belongsTo logic.
class RelationshipEngine {
  final List<Relationship> relationships;
  final JsonDatabase db;

  const RelationshipEngine({required this.relationships, required this.db});

  /// Enriches [data] (list or map) based on [method] and [path].
  dynamic apply(String method, String path, dynamic data) {
    if (method != 'GET') return data;
    for (final rel in relationships) {
      if (data is List) {
        data = _applyIndex(rel, path, data);
      } else if (data is Map<String, dynamic>) {
        _applySingle(rel, path, data);
      }
    }
    return data;
  }

  List<Map<String, dynamic>> _applyIndex(
    Relationship rel,
    String path,
    List items,
  ) {
    final typedItems = items.cast<Map<String, dynamic>>();
    if (rel.type == 'hasMany' && path == '/${rel.source}') {
      final dest = db.rawCollection(rel.destination);
      for (final item in typedItems) {
        final fk = '${singular(rel.source)}_id';
        item[rel.destination] =
            dest.where((d) => d[fk]?.toString() == item['id']?.toString()).toList();
      }
    } else if (rel.type == 'belongsTo' && path == '/${rel.source}') {
      final dest = db.rawCollection(rel.destination);
      final fk = '${singular(rel.destination)}_id';
      for (final item in typedItems) {
        final matched = dest
            .where((d) => d['id']?.toString() == item[fk]?.toString())
            .firstOrNull;
        item[singular(rel.destination)] = matched;
        item.remove(fk);
      }
    }
    return typedItems;
  }

  void _applySingle(Relationship rel, String path, Map<String, dynamic> item) {
    if (!path.startsWith('/${rel.source}')) return;
    if (rel.type == 'hasMany') {
      final dest = db.rawCollection(rel.destination);
      final fk = '${singular(rel.source)}_id';
      item[rel.destination] =
          dest.where((d) => d[fk]?.toString() == item['id']?.toString()).toList();
    } else if (rel.type == 'belongsTo') {
      final dest = db.rawCollection(rel.destination);
      final fk = '${singular(rel.destination)}_id';
      final matched = dest
          .where((d) => d['id']?.toString() == item[fk]?.toString())
          .firstOrNull;
      item[singular(rel.destination)] = matched;
      item.remove(fk);
    }
  }
}
