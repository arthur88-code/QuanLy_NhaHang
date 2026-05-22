import 'dart:convert';

import 'package:flutter/foundation.dart';
import 'package:http/http.dart' as http;

class ApiException implements Exception {
  ApiException(this.message);

  final String message;

  @override
  String toString() => message;
}

class ApiClient {
  ApiClient({http.Client? client}) : _client = client ?? http.Client();

  static const String _configuredBaseUrl = String.fromEnvironment(
    'API_BASE_URL',
    defaultValue: '',
  );
  static String? _activeBaseUrl;

  final http.Client _client;

  Future<dynamic> get(String path) => _request('GET', path);

  Future<dynamic> post(String path, Map<String, dynamic> body) {
    return _request('POST', path, body: body);
  }

  Future<dynamic> put(String path, Map<String, dynamic> body) {
    return _request('PUT', path, body: body);
  }

  Future<dynamic> patch(String path, Map<String, dynamic> body) {
    return _request('PATCH', path, body: body);
  }

  Future<dynamic> delete(String path) => _request('DELETE', path);

  Future<dynamic> _request(
    String method,
    String path, {
    Map<String, dynamic>? body,
  }) async {
    final headers = {'Content-Type': 'application/json'};
    final payload = body == null ? null : jsonEncode(body);

    http.Response? response;
    Object? lastError;
    for (final baseUrl in _candidateBaseUrls()) {
      final uri = Uri.parse('$baseUrl$path');
      try {
        response = await switch (method) {
          'GET' => _client.get(uri).timeout(const Duration(seconds: 8)),
          'POST' => _client
              .post(uri, headers: headers, body: payload)
              .timeout(const Duration(seconds: 8)),
          'PUT' => _client
              .put(uri, headers: headers, body: payload)
              .timeout(const Duration(seconds: 8)),
          'PATCH' => _client
              .patch(uri, headers: headers, body: payload)
              .timeout(const Duration(seconds: 8)),
          'DELETE' => _client.delete(uri).timeout(const Duration(seconds: 8)),
          _ => throw ApiException('Phuong thuc API khong hop le'),
        };
        _activeBaseUrl = baseUrl;
        break;
      } catch (error) {
        lastError = error;
      }
    }

    if (response == null) {
      throw ApiException(
        'Khong ket noi duoc server. Hay mo backend cung may hoac build app voi API_BASE_URL phu hop. Loi: $lastError',
      );
    }

    final decoded = response.body.isEmpty ? null : jsonDecode(response.body);
    if (response.statusCode < 200 || response.statusCode >= 300) {
      final message = decoded is Map && decoded['message'] != null
          ? decoded['message'].toString()
          : 'Loi API ${response.statusCode}';
      throw ApiException(message);
    }
    return decoded;
  }

  List<String> _candidateBaseUrls() {
    if (_configuredBaseUrl.isNotEmpty) return [_configuredBaseUrl];
    if (_activeBaseUrl != null) return [_activeBaseUrl!];
    if (kIsWeb) return [Uri.base.origin];
    return const [
      'http://10.0.2.2:3000',
      'http://127.0.0.1:3000',
      'http://localhost:3000',
    ];
  }
}
