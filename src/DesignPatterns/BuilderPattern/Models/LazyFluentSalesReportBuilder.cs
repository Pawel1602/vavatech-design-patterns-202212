using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class LazyFluentSalesReportBuilder : ISimplyFluentSalesReportBuilder
    {
        private readonly IEnumerable<Order> orders;

        private List<Func<SalesReport, SalesReport>> actions = new List<Func<SalesReport, SalesReport>>();

        public LazyFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }

        public ISimplyFluentSalesReportBuilder AddHeader(string title)
        {
            return AddAction(salesReport => AddHeader(salesReport, title));
        }

        private ISimplyFluentSalesReportBuilder AddHeader(SalesReport salesReport, string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }


       

        public ISimplyFluentSalesReportBuilder AddGenderSection()
        {
            return AddAction(salesReport => AddGenderSection(salesReport));
        }

        private ISimplyFluentSalesReportBuilder AddGenderSection(SalesReport salesReport)
        {
            salesReport.GenderDetails = orders
                    .GroupBy(o => o.Customer.Gender)
                    .Select(g => new GenderReportDetail(
                                g.Key,
                                g.Sum(x => x.Details.Sum(d => d.Quantity)),
                                g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
            
        }

        public ISimplyFluentSalesReportBuilder AddProductSection()
        {
            return AddAction(salesReport => AddProductSection(salesReport));
        }

        private ISimplyFluentSalesReportBuilder AddProductSection(SalesReport salesReport)
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public ISimplyFluentSalesReportBuilder AddFooter()
        {
            return AddAction(salesReport => AddFooter(salesReport));    
        }

      

        private ISimplyFluentSalesReportBuilder AddFooter(SalesReport salesReport)
        {
            salesReport.Footer = "Created by Sales Report Builder";

            return this;
        }

        private ISimplyFluentSalesReportBuilder AddAction(Action<SalesReport> action)
        {
            actions.Add(salesReport => { action(salesReport); return salesReport; });

            return this;
        }

        public SalesReport Build()
        {
            // SalesReport salesReport = new SalesReport();

            //foreach(var action in actions)
            //{
            //    action.Invoke(salesReport);
            //}


            var salesReport = actions.Aggregate(new SalesReport(), (salesReport, action) => action(salesReport));

            return salesReport;
        }
    }




}