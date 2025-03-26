import 'package:flutter/material.dart';
import 'package:food_shopping/Controllers/menu_app_controller.dart';
import 'package:food_shopping/Views/Screens/AuditTrails.dart';
import 'package:food_shopping/Views/Screens/Categories.dart';
import 'package:food_shopping/Views/Screens/Products.dart';
import 'package:food_shopping/Views/Screens/Roles.dart';
import 'package:food_shopping/Views/Screens/Sales.dart';
import 'package:food_shopping/Views/Screens/Users.dart';
import 'package:food_shopping/Views/Screens/dashboard_screen.dart';
import 'package:food_shopping/Views/Shared/DrawerLayout.dart';
import 'package:food_shopping/responsive.dart';
import 'package:provider/provider.dart';

class MasterLayout extends StatefulWidget {
  const MasterLayout({super.key});

  @override
  State<MasterLayout> createState() => _MasterLayoutState();
}

class _MasterLayoutState extends State<MasterLayout> {
  Widget body = DashboardScreen();
  void _onDrawerItemClick({required String clickedIndex}) {
     setState(() {
      switch (clickedIndex) {
        case "Home":
          body = DashboardScreen();
          break;
        case "Products":
          body =  Products();
          break;
        case "Product Category":
          body =  ProductCategories();
          break;
        case "Sales":
          body = Sales();
          break;
        case "AuditTrails":
          body = AuditTrails();
          break;
        case "Roles":
          body = Roles();
          break;
        case "Users":
          body = Users();
          break;
        case "Reporting":
          body = Sales();
          break;
        default:
          body =  DashboardScreen();
          break;
      }
    });
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
              child: body,
            ),
          ],
        ),
      ),
    );
  }
}
