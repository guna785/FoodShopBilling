import 'package:flutter/material.dart';
import 'package:food_shopping/Controllers/menu_app_controller.dart';
import 'package:food_shopping/Views/Screens/dashboard_screen.dart';
import 'package:food_shopping/Views/Shared/DrawerLayout.dart';
import 'package:food_shopping/responsive.dart';
import 'package:provider/provider.dart';

class MasterLayout extends StatelessWidget {
  const MasterLayout({super.key});
  void _onDrawerItemClick({required String clickedIndex}) {

  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: context.read<MenuAppController>().scaffoldKey,
      drawer: DrawerLayout(onDrawerItemClick: _onDrawerItemClick),
      body: SafeArea(
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // We want this side menu only for large screen
            if (Responsive.isDesktop(context))
              Expanded(
                // default flex = 1
                // and it takes 1/6 part of the screen
                child: DrawerLayout(onDrawerItemClick: _onDrawerItemClick),
              ),
            Expanded(
              // It takes 5/6 part of the screen
              flex: 5,
              child: DashboardScreen(),
            ),
          ],
        ),
      ),
    );
  }
}