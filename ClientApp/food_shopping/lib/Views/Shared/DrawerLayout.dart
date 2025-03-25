import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/Home.dart';
import 'package:food_shopping/Views/Shared/MasterLayout.dart';

class DrawerLayout extends StatelessWidget {
  const DrawerLayout({super.key, required this.onDrawerItemClick});
  final void Function({required String clickedIndex}) onDrawerItemClick;
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            /// Header of the Drawer
            Material(
              color: Colors.blueAccent,
              child: InkWell(
                onTap: () {
                  /// Close Navigation drawer before
                  Navigator.pop(context);
                  //Navigator.push(context, MaterialPageRoute(builder: (context) => UserProfile()),);
                },
                child: Container(
                  padding: EdgeInsets.only(
                      top: MediaQuery.of(context).padding.top, bottom: 24),
                  child: const Column(
                    children: [
                      CircleAvatar(
                        radius: 52,
                        backgroundImage: NetworkImage(
                            'https://images.unsplash.com/photo-1554151228-14d9def656e4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTB8fHNtaWx5JTIwZmFjZXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60'
                            // 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c21pbHklMjBmYWNlfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
                            ),
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      Text(
                        'Sophia',
                        style: TextStyle(fontSize: 28, color: Colors.white),
                      ),
                      const Text(
                        '@sophia.com',
                        style:
                            const TextStyle(fontSize: 14, color: Colors.white),
                      ),
                    ],
                  ),
                ),
              ),
            ),

            /// Header Menu items
            Column(
              children: [
                const Divider(
                  color: Colors.black45,
                ),
                ListTile(
                  leading: Icon(Icons.home_outlined),
                  title: Text('Home'),
                  onTap: () {
                    /// Close Navigation drawer before
                    onDrawerItemClick(clickedIndex: "Home");
                    Navigator.pop(context);
                    //Navigator.push(context, MaterialPageRoute(builder: (context) => HomeScreen()),);
                  },
                ),
                const Divider(
                  color: Colors.black45,
                ),
                ListTile(
                  leading: Icon(Icons.update),
                  title: Text('Sales'),
                  onTap: () {
                     onDrawerItemClick(clickedIndex: "Sales");
                    Navigator.pop(context);
                  },
                ),
                const Divider(
                  color: Colors.black45,
                ),
                ListTile(
                  leading: Icon(Icons.favorite_border),
                  title: Text('Products'),
                  onTap: () {
                     onDrawerItemClick(clickedIndex: "Products");
                    Navigator.pop(context);
                  },
                ),
                ListTile(
                  leading: Icon(Icons.workspaces),
                  title: Text('Product Category'),
                  onTap: () {
                     onDrawerItemClick(clickedIndex: "Product Category");
                    Navigator.pop(context);
                  },
                ),
                const Divider(
                  color: Colors.black45,
                ),
              ],
            )
          ],
        ),
      ),
    );
  }
}
