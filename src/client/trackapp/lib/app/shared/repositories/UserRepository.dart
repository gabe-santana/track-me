import 'package:dio/dio.dart';
import 'package:trackapp/app/shared/models/user.dart';

class UserRepository{
  final Dio dio;
  
  UserRepository(this.dio);

  Future<List<User>> getAll() async {
    var response = await dio.get("/user/getall");
    List<User> users = [];
    for (var json in (response.data as List)) {
      users.add(User.fromJson(json));
    }
    return users;
  }

  Future<User> getById(String id) async {
    var response = await dio.get("/user/$id");
    return User.fromJson(response.data);
  }

  Future<User> create(User user) async {
    var response = await dio.post("/user", data: user.toJson());
    return User.fromJson(response.data);
  }

  Future<User> update(User user) async {
    var response = await dio.put("/user", data: user.toJson());
    return User.fromJson(response.data);
  }

  Future<void> delete(String id) async {
    await dio.delete("/user/$id");
  }
  
}