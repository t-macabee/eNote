import 'dart:convert';
import 'package:enote_desktop/models/korisnik.dart';
import 'package:http/http.dart' as http;

class AuthProvider {
  static String? username;
  static String? password;
  static Korisnik? currentUser;

  static const String _baseUrl = "http://localhost:5256";
  static const String _loginEndpoint = "/Auth/Login";

  static Future<bool> login(String username, String password) async {
    AuthProvider.username = username;
    AuthProvider.password = password;

    var url = "$_baseUrl$_loginEndpoint";
    var uri = Uri.parse(url);

    var headers = {
      "Content-Type": "application/json",
      "Authorization": _createBasicAuthHeader()
    };
    var body = jsonEncode({"username": username, "password": password});

    try {
      var response = await http.post(uri, headers: headers, body: body);

      if (response.statusCode < 299) {
        var data = jsonDecode(response.body);
        currentUser = Korisnik.fromJson(data);
        return true;
      } else {
        throw Exception("Something bad happened please try again");
      }
    } catch (e) {
      return false;
    }
  }

  static void logout() {
    username = null;
    password = null;
    currentUser = null;
  }

  static String _createBasicAuthHeader() {
    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";
    return basicAuth;
  }
}
