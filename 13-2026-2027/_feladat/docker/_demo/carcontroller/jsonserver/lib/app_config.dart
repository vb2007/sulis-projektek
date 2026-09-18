import 'dart:convert';
import 'dart:io';

/// Represents a single relationship definition from config.json.
class Relationship {
  final String source;
  final String destination;
  final String type;

  const Relationship({
    required this.source,
    required this.destination,
    required this.type,
  });

  factory Relationship.fromJson(Map<String, dynamic> json) => Relationship(
        source: json['source'] as String,
        destination: json['destination'] as String,
        type: json['type'] as String,
      );
}

/// Parsed representation of config.json.
class AppConfig {
  final bool timestamps;
  final bool wrapper;
  final String wrapperKey;
  final List<Relationship> relationships;

  const AppConfig({
    required this.timestamps,
    this.wrapper = true,
    this.wrapperKey = 'data',
    required this.relationships,
  });

  /// Loads and parses config.json from [path]. Returns defaults if file is absent.
  factory AppConfig.load(String path) {
    final file = File(path);
    if (!file.existsSync()) return const AppConfig(timestamps: false, relationships: []);
    final json = jsonDecode(file.readAsStringSync()) as Map<String, dynamic>;
    return AppConfig(
      timestamps: (json['timestamps'] as bool?) ?? false,
      wrapper: (json['wrapper'] as bool?) ?? true,
      wrapperKey: (json['wrapperKey'] as String?) ?? 'data',
      relationships: ((json['relationships'] as List?) ?? [])
          .cast<Map<String, dynamic>>()
          .map(Relationship.fromJson)
          .toList(),
    );
  }
}

/// Loads routes.json rewrite rules. Returns empty map if file is absent.
Map<String, String> loadRoutes(String path) {
  final file = File(path);
  if (!file.existsSync()) return {};
  final json = jsonDecode(file.readAsStringSync()) as Map<String, dynamic>;
  return json.map((k, v) => MapEntry(k, v as String));
}
