using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class GridOrdersRepository : OrdersRepository {
        const int defaultOrderCount = 30;
        const int entriesPerOrder = 1;

        protected readonly List<Commodity> availableCommodities;
        protected readonly Random random;
        readonly int orderCount;
        readonly DateTime now;

        public delegate void OrderChange(int currentPercent);

        public GridOrdersRepository()
            : this(defaultOrderCount) {
        }
        public GridOrdersRepository(int orderCount)
            : this(orderCount, null) {
        }
        public GridOrdersRepository(int orderCount, OrderChange orderChange)
            : base() {
            this.orderCount = orderCount;
            this.now = DateTime.Now;
            this.random = new Random((int)this.now.Ticks);
            this.availableCommodities = new List<Commodity>();

            GenerateCustomers();
            GenerateCommodities();
            int percent = orderCount / 100;
            for (int i = 0; i < orderCount; i++) {
                Orders.Add(GenerateOrder(i));
                if (orderChange != null && i % percent == 0) {
                    Action action = new Action(() => { orderChange(i / percent); });
                    Device.BeginInvokeOnMainThread(action);
                }
            }
        }

        protected override Order GenerateOrder(int number) {
            Order order = new Order(RandomItem<Customer>(Customers), number, RandomDateSince(this.now, TimeSpan.FromDays(180), TimeSpan.FromDays(30)), number % 3 == 0);
            order.Priority = (OrderPriority)this.random.Next(0, 3);
            order.Discount = this.random.Next(0, 30) / 100.0;

            for (int i = 0; i < entriesPerOrder; i++)
                order.AddEntry(new OrderEntry(RandomItem<Commodity>(this.availableCommodities), number, number * 10));

            return order;
        }
        protected override int GetOrderCount() {
            return this.orderCount;
        }

        DateTime RandomDateSince(DateTime sinceDate, TimeSpan offsetPast, TimeSpan offsetFuture) {
            TimeSpan totalSpan = offsetPast + offsetFuture;
            int days = (int)(this.random.NextDouble() * totalSpan.TotalDays);
            return (sinceDate - offsetPast).AddDays(days);
        }

        T RandomItem<T>(IList<T> list) {
            int index = (int)(this.random.NextDouble() * 0.99 * (list.Count));
            return list[index];
        }

        protected virtual void GenerateCommodities() {
            this.availableCommodities.Add(new Commodity("Item #A"));
            this.availableCommodities.Add(new Commodity("Item #B"));
            this.availableCommodities.Add(new Commodity("Item #C"));
        }
        void GenerateCustomers() {
            Customers.Add(
                new Customer("Nancy Davolio") {
                    Id = 1,
                    BirthDate = new DateTime(1978, 12, 8),
                    HireDate = new DateTime(2005, 5, 1),
                    Position = "Sales Representative",
                    Address = "98122, 507 - 20th Ave. E. Apt. 2A, Seattle WA, USA",
                    Phone = "(206) 555-9857",
                    Email = "NancyDavolio@devexpress.com",
                    Notes = "Education includes a BA in psychology from Colorado State University in 2000. She also completed \"The Art of the Cold Call.\" Nancy is a member of Toastmasters International.",
                }
            );
            Customers.Add(
                new Customer("Andrew Fuller") {
                    Id = 2,
                    BirthDate = new DateTime(1965, 2, 19),
                    HireDate = new DateTime(1992, 8, 14),
                    Position = "Vice President, Sales",
                    Address = "98401, 908 W. Capital Way, Tacoma WA, USA",
                    Phone = "(206) 555-9482",
                    Email = "AndrewFuller@devexpress.com",
                    Notes = "Andrew received his BTS commercial in 1987 and a Ph.D. in international marketing from the University of Dallas in 1994. He is fluent in French and Italian and reads German. He joined the company as a sales representative, was promoted to sales manager in January 2005 and to vice president of sales in March 2006. Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association."
                }
            );
            Customers.Add(
                new Customer("Janet Leverling") {
                    Id = 3,
                    BirthDate = new DateTime(1985, 8, 30),
                    HireDate = new DateTime(2002, 4, 1),
                    Position = "Sales Representative",
                    Address = "98033, 722 Moss Bay Blvd., Kirkland WA, USA",
                    Phone = "(206) 555-3412",
                    Email = "JanetLeverling@devexpress.com",
                    Notes = "Janet has a BS degree in chemistry from Boston College (2006). She has also completed a certificate program in food retailing management. Janet was hired as a sales associate in 2013 and promoted to sales representative in February 2014."
                }
            );
            Customers.Add(
                new Customer("Margaret Peacock") {
                    Id = 4,
                    BirthDate = new DateTime(1973, 9, 19),
                    HireDate = new DateTime(1993, 5, 3),
                    Position = "Sales Representative",
                    Address = "98052, 4110 Old Redmond Rd., Redmond WA, USA",
                    Phone = "(206) 555-8122",
                    Email = "MargaretPeacock@devexpress.com",
                    Notes = "Margaret holds a BA in English literature from Concordia College (1994) and an MA from the American Institute of Culinary Arts (2002). She was assigned to the London office temporarily from July through November 2008."
                }
            );
            Customers.Add(
                new Customer("Steven Buchanan") {
                    Id = 5,
                    BirthDate = new DateTime(1955, 3, 4),
                    HireDate = new DateTime(1993, 10, 17),
                    Position = "Sales Manager",
                    Address = "SW1 8JR, 14 Garrett Hill, London, UK",
                    Phone = "(71) 555-4848",
                    Email = "StevenBuchanan@devexpress.com",
                    Notes = "Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 1993.  Mr. Buchanan has completed the courses \"Successful Telemarketing\" and \"International Sales Management.\"  He is fluent in French."
                }
            );
            Customers.Add(
                new Customer("Michael Suyama") {
                    Id = 6,
                    BirthDate = new DateTime(1981, 7, 2),
                    HireDate = new DateTime(1999, 10, 17),
                    Position = "Sales Representative",
                    Address = "EC2 7JR, Coventry House Miner Rd., London, UK",
                    Phone = "(71) 555-7773",
                    Email = "MichaelSuyama@devexpress.com",
                    Notes = "Michael is a graduate of Sussex University (MA, economics, 2001) and the University of California at Los Angeles (MBA, marketing, 2004). He has also taken the courses \"Multi-Cultural Selling\" and \"Time Management for the Sales Professional.\" He is fluent in Japanese and can read and write French, Portuguese, and Spanish."
                }
            );
            Customers.Add(
                new Customer("Robert King") {
                    Id = 7,
                    BirthDate = new DateTime(1960, 5, 29),
                    HireDate = new DateTime(1994, 1, 2),
                    Position = "Sales Representative",
                    Address = "RG1 9SP, Edgeham Hollow Winchester Way, London, UK",
                    Phone = "(71) 555-5598",
                    Email = "RobertKing@devexpress.com",
                    Notes = "Robert King served in the Peace Corps and traveled extensively before completing his degree in English at the University of Michigan in 1992, the year he joined the company.  After completing a course entitled \"Selling in Europe,\" he was transferred to the London office in March 1993."
                }
            );
            Customers.Add(
                new Customer("Laura Callahan") {
                    Id = 8,
                    BirthDate = new DateTime(1985, 1, 9),
                    HireDate = new DateTime(2004, 3, 5),
                    Position = "Inside Sales Coordinator",
                    Address = "98105, 4726 - 11th Ave. N.E., Seattle WA, USA",
                    Phone = "(206) 555-1189",
                    Email = "LauraCallahan@devexpress.com",
                    Notes = "Laura received a BA in psychology from the University of Washington. She has also completed a course in business French. She reads and writes French."
                }
            );
            Customers.Add(
                new Customer("Anne Dodsworth") {
                    Id = 9,
                    BirthDate = new DateTime(1980, 1, 27),
                    HireDate = new DateTime(2004, 11, 15),
                    Position = "Sales Representative",
                    Address = "WG2 7LT, 7 Houndstooth Rd., London, UK",
                    Phone = "(71) 555-4444",
                    Email = "AnneDodsworth@devexpress.com",
                    Notes = "Anne has a BA degree in English from St. Lawrence College. She is fluent in French and German."
                }
            );
        }
    }
}
