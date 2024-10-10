using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.TreeView.Data;

public static class ReportLibraryData {
    public static ReportLibraryNode Generate() {
        var root = new ReportLibraryNode();

        var customers = new ReportLibraryNode() { Name = "Customers", IsFolder = true };
        var orders = new ReportLibraryNode() { Name = "Orders", IsFolder = true };
        orders.AddNode(new ReportLibraryNode() { Name = "Detail.pdf", IsFolder = false });
        orders.AddNode(new ReportLibraryNode() { Name = "Summary.pdf", IsFolder = false });
        customers.AddNode(orders);
        customers.AddNode(new ReportLibraryNode() { Name = "Balance sheet.pdf", IsFolder = false });
        customers.AddNode(new ReportLibraryNode() { Name = "Revenue by company.pdf", IsFolder = false });

        var employees = new ReportLibraryNode() { Name = "Employees", IsFolder = true };
        employees.AddNode(new ReportLibraryNode() { Name = "Arrival card.pdf", IsFolder = false });
        employees.AddNode(new ReportLibraryNode() { Name = "Employee comparison.pdf", IsFolder = false });
        employees.AddNode(new ReportLibraryNode() { Name = "Employee location.pdf", IsFolder = false });
        employees.AddNode(new ReportLibraryNode() { Name = "Employee performance review.pdf", IsFolder = false });
        employees.AddNode(new ReportLibraryNode() { Name = "Letter.pdf", IsFolder = false });

        var marketResearch = new ReportLibraryNode() { Name = "Market Research", IsFolder = true };
        marketResearch.AddNode(new ReportLibraryNode() { Name = "Market share.pdf", IsFolder = false });
        marketResearch.AddNode(new ReportLibraryNode() { Name = "Polling.pdf", IsFolder = false });
        marketResearch.AddNode(new ReportLibraryNode() { Name = "Population.pdf", IsFolder = false });
        marketResearch.AddNode(new ReportLibraryNode() { Name = "Profit and loss.pdf", IsFolder = false });

        var products = new ReportLibraryNode() { Name = "Products", IsFolder = true };
        var barCodes = new ReportLibraryNode() { Name = "Bar Codes", IsFolder = true };
        barCodes.AddNode(new ReportLibraryNode() { Name = "All product labels.pdf", IsFolder = false });
        barCodes.AddNode(new ReportLibraryNode() { Name = "Code types.pdf", IsFolder = false });
        barCodes.AddNode(new ReportLibraryNode() { Name = "Product label.pdf", IsFolder = false });
        var crossBand = new ReportLibraryNode() { Name = "Cross Band", IsFolder = true };
        crossBand.AddNode(new ReportLibraryNode() { Name = "Invoice.pdf", IsFolder = false });
        crossBand.AddNode(new ReportLibraryNode() { Name = "Product list.pdf", IsFolder = false });
        var realLife = new ReportLibraryNode() { Name = "Real-Life", IsFolder = true };
        realLife.AddNode(new ReportLibraryNode() { Name = "Restaurant menu.pdf", IsFolder = false });
        realLife.AddNode(new ReportLibraryNode() { Name = "Roll paper.pdf", IsFolder = false });
        products.AddNode(barCodes);
        products.AddNode(crossBand);
        products.AddNode(realLife);
        products.AddNode(new ReportLibraryNode() { Name = "Sorting products.pdf", IsFolder = false });

        var sales = new ReportLibraryNode() { Name = "Sales", IsFolder = true };
        var northwindTraders = new ReportLibraryNode() { Name = "Northwind Traders", IsFolder = true };
        northwindTraders.AddNode(new ReportLibraryNode() { Name = "Catalog.pdf", IsFolder = false });
        northwindTraders.AddNode(new ReportLibraryNode() { Name = "Invoice.pdf", IsFolder = false });
        northwindTraders.AddNode(new ReportLibraryNode() { Name = "Product list.pdf", IsFolder = false });
        sales.AddNode(northwindTraders);
        sales.AddNode(new ReportLibraryNode() { Name = "ACME order overview.pdf", IsFolder = false });
        sales.AddNode(new ReportLibraryNode() { Name = "Multi-table order list.pdf", IsFolder = false });
        sales.AddNode(new ReportLibraryNode() { Name = "Order details.pdf", IsFolder = false });
        sales.AddNode(new ReportLibraryNode() { Name = "Single-table order list.pdf", IsFolder = false });
        sales.AddNode(new ReportLibraryNode() { Name = "Summary by year.pdf", IsFolder = false });

        root.AddNode(customers);
        root.AddNode(employees);
        root.AddNode(marketResearch);
        root.AddNode(products);
        root.AddNode(sales);

        return root;
    }
}
public class ReportLibraryNode : NotificationObject {
    public static string GetFileName(ReportLibraryNode node) {
        if(node.IsFolder) return "";
        var branch = GetPath(node);
        var path = branch.Select(x => x.Name).Where(x => x != null).ToArray();
        var fileName = @"Reports\" + string.Join(@"\", path);
        return fileName;

        static IEnumerable<ReportLibraryNode> GetPath(ReportLibraryNode node) {
            List<ReportLibraryNode> res = new();
            var n = node;
            while (n != null) {
                res.Add(n);
                n = n.Parent;
            }
            return res.AsEnumerable().Reverse();
        }
    }

    public bool IsFolder { get; set; }
    public string Name { get; set; }
    public bool? IsChecked { get => isChecked; set => SetProperty(ref isChecked, value); }

    public ObservableCollection<ReportLibraryNode> Nodes { get; }
    public ReportLibraryNode Parent { get; private set; }

    public ReportLibraryNode() {
        Nodes = new();
    }
    public void AddNode(ReportLibraryNode node) {
        Nodes.Add(node);
        node.Parent = this;
    }
    public void DeleteNode(ReportLibraryNode node) {
        if (node != null) {
            Nodes.Remove(node);
            node.Parent = null;
        }
    }
    public void DeleteSelf() {
        Parent?.DeleteNode(this);
    }

    bool? isChecked = false;
}