import 'location.dart';
import 'state.dart';

class Tracker {
  String? id;
  Location? location;
  State? state;

  Tracker({this.id, this.location, this.state});

  Tracker.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    location = json['location'] != null
        ? new Location.fromJson(json['location'])
        : null;
    state = json['state'] != null ? new State.fromJson(json['state']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    if (this.location != null) {
      data['location'] = this.location?.toJson();
    }
    if (this.state != null) {
      data['state'] = this.state?.toJson();
    }
    return data;
  }
}






