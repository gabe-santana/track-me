import 'package:dio/dio.dart';
import 'package:trackapp/app/shared/models/tracker.dart';

class TrackerRepository{
  final Dio dio;
  
  TrackerRepository(this.dio);
  
  Future<List<Tracker>> getAll() async {
    var response = await dio.get("/tracker/getall");
    List<Tracker> trackers = [];
    for (var json in (response.data as List)) {
      trackers.add(Tracker.fromJson(json));
    }
    return trackers;
  }

  Future<Tracker> getById(String id) async {
    var response = await dio.get("/tracker/$id");
    return Tracker.fromJson(response.data);
  }

  Future<Tracker> create(Tracker tracker) async {
    var response = await dio.post("/tracker", data: tracker.toJson());
    return Tracker.fromJson(response.data);
  }

  Future<Tracker> update(Tracker tracker) async {
    var response = await dio.put("/tracker", data: tracker.toJson());
    return Tracker.fromJson(response.data);
  }

  Future<void> delete(String id) async {
    await dio.delete("/tracker/$id");
  }
}