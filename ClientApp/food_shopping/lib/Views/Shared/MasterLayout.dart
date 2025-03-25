import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/Home.dart';
import 'package:food_shopping/Views/Shared/AppBarLayout.dart';
import 'package:food_shopping/Views/Shared/DrawerLayout.dart';

class MasterLayout extends StatefulWidget {
  const MasterLayout({super.key});

  @override
  State<MasterLayout> createState() => _MasterLayoutState();
}

class _MasterLayoutState extends State<MasterLayout> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      drawer: DrawerLayout(),
      appBar: AppBarLayout(),
      body: Home(),
    );
  }
}
