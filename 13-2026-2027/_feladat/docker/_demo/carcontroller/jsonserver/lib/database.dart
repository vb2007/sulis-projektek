import 'dart:convert';
import 'dart:io';

/// File-backed JSON database. Thread-unsafe — designed for single-process use.
class JsonDatabase {
  final String path;
  Map<String, dynamic> _data = {};

  JsonDatabase(this.path) {
    _load();
  }

  void _load() {
    final file = File(path);
    _data = file.existsSync()
        ? jsonDecode(file.readAsStringSync()) as Map<String, dynamic>
        : {};
  }

  void _save() => File(path).writeAsStringSync(jsonEncode(_data));

  /// Returns all items in [collection], applying optional query filters.
  List<Map<String, dynamic>> getCollection(
    String collection, {
    Map<String, String> filters = const {},
    String? sortField,
    String? sortOrder,
    int? page,
    int? limit,
  }) {
    final raw = _data[collection];
    if (raw == null) return [];
    var items = (raw as List).cast<Map<String, dynamic>>();

    // Field-equality filtering (skip underscore-prefixed control params).
    for (final entry in filters.entries) {
      if (!entry.key.startsWith('_')) {
        items = items
            .where((item) => item[entry.key]?.toString() == entry.value)
            .toList();
      }
    }

    // Sorting.
    if (sortField != null) {
      items = List.from(items)
        ..sort((a, b) {
          final av = a[sortField]?.toString() ?? '';
          final bv = b[sortField]?.toString() ?? '';
          final cmp = av.compareTo(bv);
          return sortOrder?.toLowerCase() == 'desc' ? -cmp : cmp;
        });
    }

    // Pagination.
    if (limit != null) {
      final offset = ((page ?? 1) - 1) * limit;
      items = items.skip(offset).take(limit).toList();
    }

    return items;
  }

  /// Returns a single item by [id], or null if not found.
  Map<String, dynamic>? getById(String collection, String id) {
    final raw = _data[collection] as List?;
    if (raw == null) return null;
    return raw
        .cast<Map<String, dynamic>>()
        .where((item) => item['id']?.toString() == id)
        .firstOrNull;
  }

  /// Inserts [item] into [collection], auto-generating an integer id if absent.
  Map<String, dynamic> insert(String collection, Map<String, dynamic> item) {
    final list = (_data[collection] as List?)?.cast<Map<String, dynamic>>() ?? [];
    if (!item.containsKey('id')) {
      final maxId = list.isEmpty
          ? 0
          : list
              .map((e) => int.tryParse(e['id']?.toString() ?? '0') ?? 0)
              .reduce((a, b) => a > b ? a : b);
      item['id'] = (maxId + 1).toString();
    }
    list.add(item);
    _data[collection] = list;
    _save();
    return item;
  }

  /// Merges [updates] into the item with [id]. Returns null if not found.
  Map<String, dynamic>? update(
    String collection,
    String id,
    Map<String, dynamic> updates,
  ) {
    final list = (_data[collection] as List?)?.cast<Map<String, dynamic>>() ?? [];
    final index = list.indexWhere((item) => item['id']?.toString() == id);
    if (index == -1) return null;
    list[index] = {...list[index], ...updates, 'id': list[index]['id']};
    _data[collection] = list;
    _save();
    return list[index];
  }

  /// Replaces the item with [id] entirely. Returns null if not found.
  Map<String, dynamic>? replace(
    String collection,
    String id,
    Map<String, dynamic> item,
  ) {
    final list = (_data[collection] as List?)?.cast<Map<String, dynamic>>() ?? [];
    final index = list.indexWhere((existing) => existing['id']?.toString() == id);
    if (index == -1) return null;
    item['id'] = list[index]['id'];
    list[index] = item;
    _data[collection] = list;
    _save();
    return list[index];
  }

  /// Removes the item with [id] from [collection]. Returns false if not found.
  bool delete(String collection, String id) {
    final list = (_data[collection] as List?)?.cast<Map<String, dynamic>>() ?? [];
    final before = list.length;
    list.removeWhere((item) => item['id']?.toString() == id);
    if (list.length == before) return false;
    _data[collection] = list;
    _save();
    return true;
  }

  /// Returns all item from [collection] unfiltered — used by the relationship engine.
  List<Map<String, dynamic>> rawCollection(String collection) {
    final raw = _data[collection] as List?;
    return raw?.cast<Map<String, dynamic>>() ?? [];
  }

  /// Returns true if [collection] exists in the database.
  bool hasCollection(String collection) => _data.containsKey(collection);

  /// Returns the names of all collections.
  List<String> get collections => _data.keys.toList();
}
