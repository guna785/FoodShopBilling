// ignore_for_file: file_names

import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:food_shopping/responsive.dart';

class DrawerLayout extends StatelessWidget {
  const DrawerLayout({super.key, required this.onDrawerItemClick});
  final void Function({required String clickedIndex}) onDrawerItemClick;
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          DrawerHeader(
            child: Image.asset("assets/images/logo.png"),
          ),
          DrawerListTile(
            title: "Dashboard",
            svgSrc: "assets/icons/menu_dashboard.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Home");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Sales",
            svgSrc: "assets/icons/menu_tran.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Sales");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Products",
            svgSrc: "assets/icons/menu_task.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Products");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Product Category",
            svgSrc: "assets/icons/menu_doc.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Product Category");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Users",
            svgSrc: "assets/icons/menu_store.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Users");
              if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Roles",
            svgSrc: "assets/icons/menu_notification.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Roles");
              if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Reporting",
            svgSrc: "assets/icons/menu_profile.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "Reporting");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
          DrawerListTile(
            title: "Audit Trails",
            svgSrc: "assets/icons/menu_setting.svg",
            press: () {
              onDrawerItemClick(clickedIndex: "AuditTrails");
               if (!Responsive.isDesktop(context)) {
                Navigator.pop(context);
              }
            },
          ),
        ],
      ),
    );
  }
}

class DrawerListTile extends StatelessWidget {
   const DrawerListTile({
    Key? key,
    // For selecting those three line once press "Command+D"
    required this.title,
    required this.svgSrc,
    required this.press,
  }) : super(key: key);

  final String title, svgSrc;
  final VoidCallback press;

  @override
  Widget build(BuildContext context) {
    return ListTile(
      onTap: press,
      horizontalTitleGap: 0.0,
      leading: SvgPicture.asset(
        svgSrc,
        colorFilter: ColorFilter.mode(Colors.white54, BlendMode.srcIn),
        height: 16,
      ),
      title: Text(
        title,
        style: TextStyle(color: Colors.white54),
      ),
    );
  }
}
