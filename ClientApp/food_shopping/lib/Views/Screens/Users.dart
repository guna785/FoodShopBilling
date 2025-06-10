import 'package:flutter/material.dart';
import 'package:food_shopping/Views/Components/header.dart';
import 'package:food_shopping/constants.dart';
import 'package:paged_datatable/paged_datatable.dart';

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
           Expanded( child: PagedDataTableTheme(
                data: PagedDataTableThemeData(
                  selectedRow: const Color(0xFFCE93D8),
                  rowColor: (index) => index.isEven ? Colors.purple[50] : null,
                ),
                child:PaginatedDataTable(
                   header: Text('Users'),
                   columns: [
            DataColumn(label: Text('Task')),
            DataColumn(label: Text('Priority')),
            DataColumn(label: Text('Due Date')),
          ],
          source: TaskDataSource(),
          rowsPerPage: 10,
                )
                
            ))
        ]));
  }
}
