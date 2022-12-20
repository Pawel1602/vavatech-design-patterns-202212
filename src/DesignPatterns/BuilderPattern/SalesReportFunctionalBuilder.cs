using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class SalesReportFunctionalBuilder : FunctionalBuilder<SalesReport, SalesReportFunctionalBuilder>, ISimplyFluentSalesReportBuilder
    {
        private readonly IEnumerable<Order> orders;

        public SalesReportFunctionalBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }

        public ISimplyFluentSalesReportBuilder AddFooter()
        {
            throw new NotImplementedException();
        }

        public ISimplyFluentSalesReportBuilder AddGenderSection() => Do(salesReport => AddGenderSection(salesReport));

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


        public ISimplyFluentSalesReportBuilder AddHeader(string title) => Do(salesReport => AddHeader(salesReport, title));

        private ISimplyFluentSalesReportBuilder AddHeader(SalesReport salesReport, string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }


        public ISimplyFluentSalesReportBuilder AddProductSection()
        {
            throw new NotImplementedException();
        }
    }
}
