import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';

class AppWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Rastreie agora',
      darkTheme: ThemeData(
        // Define the default brightness and colors.
        brightness: Brightness.dark,
        primaryColor: Colors.black26,
        accentColor: Colors.cyan[600],

        // Define the default font family.
        fontFamily: 'Lato',
        
        // Define the default TextTheme. Use this to specify the default
        // text styling for headlines, titles, bodies of text, and more.
        textTheme: const TextTheme(
          headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
          headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
          bodyText2: TextStyle(fontSize: 26.0, fontFamily: 'Hind'),
        ),
      ),
      themeMode: ThemeMode.dark,
      debugShowCheckedModeBanner: false
    ).modular();
  }
}