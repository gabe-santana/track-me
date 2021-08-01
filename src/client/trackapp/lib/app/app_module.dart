import 'package:dio/dio.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'modules/home/home_module.dart';
import 'shared/repositories/TrackerRepository.dart';
import 'shared/repositories/UserRepository.dart';
import 'shared/utils/constants.dart';

class AppModule extends Module {
  @override
  final List<Bind> binds = [
    Bind((i) => UserRepository(i.get())),
    Bind((i) => TrackerRepository(i.get())),
    Bind((i) => Dio(BaseOptions(baseUrl: URL_BASE)))
  ];

  @override
  final List<ModularRoute> routes = [
    ModuleRoute(Modular.initialRoute, module: HomeModule()),
  ];

}