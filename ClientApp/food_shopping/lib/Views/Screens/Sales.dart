import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/header.dart';
import 'package:food_shopping/constants.dart';

class Sales extends StatelessWidget {
  const Sales({super.key});

  @override
  Widget build(BuildContext context) {
     return SingleChildScrollView(
        primary: false,
        padding: EdgeInsets.all(defaultPadding),
        child: Column(children: [
          Header(Title: "Sales"),
          SizedBox(height: defaultPadding),
          const Placeholder()
        ]));
  }
}