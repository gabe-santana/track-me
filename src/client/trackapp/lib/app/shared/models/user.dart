class User {
  String? email;
  String? name;
  String? trackerId;

  User({this.email, this.name, this.trackerId});

  User.fromJson(Map<String, dynamic> json) {
    email = json['email'];
    name = json['name'];
    trackerId = json['trackerId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['email'] = this.email;
    data['name'] = this.name;
    data['trackerId'] = this.trackerId;
    return data;
  }
}
