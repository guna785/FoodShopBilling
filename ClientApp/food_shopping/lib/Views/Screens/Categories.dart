import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/header.dart';
import 'package:food_shopping/constants.dart';

class ProductCategories extends StatelessWidget {
  const ProductCategories({super.key});

  @override
  Widget build(BuildContext context) {
     return SingleChildScrollView(
        primary: false,
        padding: EdgeInsets.all(defaultPadding),
        child: Column(children: [
          Header(Title: "Product Categories"),
          SizedBox(height: defaultPadding),
          const Placeholder()
        ]));
  }
}