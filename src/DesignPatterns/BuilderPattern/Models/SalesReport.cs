using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    // Abstract builder
    public interface ISalesReportBuilder
    {
        void AddHeader(string title);
        void AddGenderSection();
        void AddProductSection();
        void AddFooter();

        // Product
        SalesReport Build();
    }




    // Concrete builder
    public class SalesReportBuilder : ISalesReportBuilder
    {
        private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        public SalesReportBuilder(IEnumerable<Order> orders)
        {
            salesReport = new SalesReport();
            this.orders = orders;
        }

        public void AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);
        }

        public void AddGenderSection()
        {
            salesReport.GenderDetails = orders
                   .GroupBy(o => o.Customer.Gender)
                   .Select(g => new GenderReportDetail(
                               g.Key,
                               g.Sum(x => x.Details.Sum(d => d.Quantity)),
                               g.Sum(x => x.Details.Sum(d => d.LineTotal))));
        }

        public void AddProductSection()
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
        }

        public void AddFooter()
        {
            salesReport.Footer = "Created by Sales Report Builder";
        }

        public SalesReport Build()
        {
            return salesReport;
        }
    }

    // Abstract builder
    public interface IFluentSalesReportBuilder
    {
        ISection AddHeader(string title);
        ISectionOrFooter AddGenderSection();
        ISectionOrFooter AddProductSection();
        IBuild AddFooter();

        // Product
        SalesReport Build();
    }

    public interface ISection
    {
        ISectionOrFooter AddGenderSection();
        ISectionOrFooter AddProductSection();
    }

    public interface ISectionOrFooter : ISection, IFooter
    {
    }

    public interface IHeader
    {
        ISection AddHeader(string title);
    }
   
    public interface IFooter
    {
        IBuild AddFooter();
    }

    public interface IBuild
    {
        SalesReport Build();
    }

    public class FluentSalesReportBuilder : IFluentSalesReportBuilder, IHeader, ISection, ISectionOrFooter, IBuild
    {
        private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        protected FluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            salesReport = new SalesReport();
            this.orders = orders;
        }

        public static IHeader Create(IEnumerable<Order> orders)
        {
            return new FluentSalesReportBuilder(orders);
        }

        public IBuild AddFooter()
        {
            salesReport.Footer = "Created by Sales Report Builder";

            return this;
        }

        public ISection AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public ISectionOrFooter AddGenderSection()
        {
            salesReport.GenderDetails = orders
                .GroupBy(o => o.Customer.Gender)
                .Select(g => new GenderReportDetail(
                            g.Key,
                            g.Sum(x => x.Details.Sum(d => d.Quantity)),
                            g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }

       

        public ISectionOrFooter AddProductSection()
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public SalesReport Build()
        {
            return salesReport;
        }
    }

    public class SalesReport
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalSalesAmount { get; set; }

        public IEnumerable<ProductReportDetail> ProductDetails { get; set; }
        public IEnumerable<GenderReportDetail> GenderDetails { get; set; }

        public string Footer { get; set; }


        public override string ToString()
        {
            string output = string.Empty;

            output += "------------------------------\n";

            output += $"{Title} {CreateDate}\n";
            output += $"Total Sales Amount: {TotalSalesAmount:c2}\n";

            output += "------------------------------\n";

            output += "Total By Products:\n";
            foreach (var detail in ProductDetails)
            {
                output += $"- {detail.Product.Name} {detail.Quantity} {detail.TotalAmount:c2}\n";
            }
            output += "Total By Gender:\n";
            foreach (var detail in GenderDetails)
            {
                output += $"- {detail.Gender} {detail.Quantity} {detail.TotalAmount:c2}\n";
            }


            output += Footer;

            return output;
        }
    }




}