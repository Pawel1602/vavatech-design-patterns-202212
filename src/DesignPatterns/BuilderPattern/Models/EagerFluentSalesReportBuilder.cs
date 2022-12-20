using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    // Concrete builder (eager)
    public class EagerFluentSalesReportBuilder : IFluentSalesReportBuilder, IHeader, ISection, ISectionOrFooter, IBuild
    {
        private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        protected EagerFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            salesReport = new SalesReport();
            this.orders = orders;
        }

        public static IHeader Create(IEnumerable<Order> orders)
        {
            return new EagerFluentSalesReportBuilder(orders);
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




}