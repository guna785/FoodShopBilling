import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/Home.dart';
import 'package:food_shopping/Views/Components/ProductCategories.dart';
import 'package:food_shopping/Views/Components/Products.dart';
import 'package:food_shopping/Views/Components/Sales.dart';
import 'package:food_shopping/Views/Shared/AppBarLayout.dart';
import 'package:food_shopping/Views/Shared/DrawerLayout.dart';

class MasterLayout extends StatefulWidget {
  const MasterLayout({super.key});

  @override
  State<MasterLayout> createState() => _MasterLayoutState();
}

class _MasterLayoutState extends State<MasterLayout> {
  Widget currentPage = const Home();

  void _onDrawerItemClick({required String clickedIndex}) {
    setState(() {
      switch (clickedIndex) {
        case "Home":
          currentPage = const Home();
          break;
        case "Products":
          currentPage = const Products();
          break;
        case "Product Category":
          currentPage = const Productcategories();
          break;
        case "Sales":
          currentPage = const Sales();
          break;
        default:
          currentPage = const Home();
          break;
      }
    });
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: DrawerLayout(onDrawerItemClick: _onDrawerItemClick),
      appBar: const AppBarLayout(),
      body: SafeArea(child: currentPage),
    );
  }
}
