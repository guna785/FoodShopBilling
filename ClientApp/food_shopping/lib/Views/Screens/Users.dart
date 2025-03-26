import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/header.dart';
import 'package:food_shopping/constants.dart';

class Users extends StatelessWidget {
  const Users({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        primary: false,
        padding: EdgeInsets.all(defaultPadding),
        child: Column(children: [
          Header(Title: "Users"),
          SizedBox(height: defaultPadding),
          const Placeholder()
        ]));
  }
}
