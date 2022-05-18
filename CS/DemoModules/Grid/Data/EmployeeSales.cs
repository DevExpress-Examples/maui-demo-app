using System;
using System.Data;
using System.Globalization;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class EmployeeSales {
        public DataTable Data { get; private set; }
        public EmployeeSales() {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Full Name"));
            for (int i = 0; i < 5; i++) {
                int year = DateTime.Now.Year - 5 + i;
                for (int j = 1; j < 5; j++) {
                    dataTable.Columns.Add(new DataColumn("Q" + j + ", " + year, typeof(double)));
                }
                dataTable.Columns.Add(new DataColumn("" + year + " Total", typeof(double)));
            }

            Random random = new Random();
            EmployeesRepository employees = new EmployeesRepository();
            foreach (Employee employee in employees.Employees) {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Full Name"] = employee.FullName;

                for (int i = 0; i < 5; i++) {
                    double yearTotal = 0;
                    int year = DateTime.Now.Year - 5 + i;
                    for (int j = 1; j < 5; j++) {
                        double value = random.Next(100000);
                        dataRow["Q" + j + ", " + year] = value;
                        yearTotal += value;
                    }
                    dataRow["" + year + " Total"] = yearTotal;
                }
                dataTable.Rows.Add(dataRow);
            }

            Data = dataTable;
        }
    }
}
