class State {
  int? acelerotometerState;

  State({this.acelerotometerState});

  State.fromJson(Map<String, dynamic> json) {
    acelerotometerState = json['acelerotometerState'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['acelerotometerState'] = this.acelerotometerState;
    return data;
  }
}
