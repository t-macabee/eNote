import 'dart:convert';
import 'package:enote_desktop/providers/auth_provider.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class KorisniciProvider {
  static String baseUrl = const String.fromEnvironment("baseUrl",
      defaultValue: "http://localhost:5256/");

  KorisniciProvider();

  Future<dynamic> get() async {
    var url = "${baseUrl}Instrumenti";
    var uri = Uri.parse(url);
    var response = await http.get(uri, headers: createHeaders());

    if (validResponse(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Unknown exception");
    }
  }

  bool validResponse(Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Something bad happened, please try again!");
    }
  }

  Map<String, String> createHeaders() {
    String username = AuthProvider.username!;
    String password = AuthProvider.password!;

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    return headers;
  }
}
