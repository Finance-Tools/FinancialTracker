using FinancialTracker.CommonTypes;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialTracker
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : Window
    {
        public GraphView()
        {
            InitializeComponent();

            this.DataContext = this;
        }
        public GraphView(InvestmentIteration col)
        {
            InitializeComponent();

            CartesianMapper<IterationUnit> config = new CartesianMapper<IterationUnit>()
                .X(point => point.Iteration_Date.Ticks)
                .Y(point => point.Opening_Balance);

            this.SeriesCollection = new SeriesCollection(config);
            SeriesCollection.Add(new LineSeries
            {
                Title = col.Detail.Name
            });
            foreach (var item in SeriesCollection)
            {
                if (item.GetType() == typeof(LineSeries) && item.Title.Equals(col.Detail.Name))
                {
                    item.Values = new ChartValues<IterationUnit>();
                    foreach (IterationUnit itr in col.Iteration)
                    {
                        item.Values.Add(itr);
                    }
                }
            }
            this.Formatter = value => new DateTime((long)value).ToString("M-yy");

            this.DataContext = this;
        }


        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        public Func<double, string> Formatter { get; set; }
    }
}
