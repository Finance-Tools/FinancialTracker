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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinancialTracker.CommonTypes;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using static FinancialTracker.CommonTypes.BaseTypes;

namespace FinancialTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection temp_collection;

        InvestmentComponent FD_Demo;
        InvestmentIteration FD_Itr_Demo = new InvestmentIteration();

        public MainWindow()
        {
            InitializeComponent();

            temp_collection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 3, 5, 7, 4 }
                }
                //new ColumnSeries
                //{
                //    Values = new ChartValues<decimal> { 5, 6, 2, 70 }
                //}
            };

            //graphInvestmentOverview.Series = temp_collection;


            FD_Demo = new InvestmentComponent
            {
                Name = "SBI_FD_10K",
                Type = InvestmentType_E.FixedDeposit,
                Deposit_Elements = new DepositElements(10000, 1, 5.6, true, DateTime.Now, Period_E.Month),
                Institute = Institute_E.ICICIBank
            };

            FD_Itr_Demo.Detail = FD_Demo;

            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2021, 1, 1), 10010));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2021, 2, 1), 10030));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2021, 3, 1), 10080));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2021, 4, 1), 10150));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2021, 5, 1), 10300));

        }

        private void buttonTrackInvestment_Click(object sender, RoutedEventArgs e)
        {
#if null
            CartesianMapper<IterationUnit> config = new CartesianMapper<IterationUnit>()
                .X(point => point.Iteration_Date.Ticks)
                .Y(point => point.Opening_Balance);

            temp_collection.Clear();
            temp_collection = new SeriesCollection(config);
            temp_collection.Add(new LineSeries
            {
                Title = FD_Itr_Demo.Detail.Name,
                
            });
            foreach (var item in temp_collection)
            {
                if (item.GetType() == typeof(LineSeries) && item.Title.Equals(FD_Itr_Demo.Detail.Name))
                {
                    //foreach (var val in item.Values)
                    //{

                    //    var a = item;
                    //}
                    //item.Values.Clear();
                    item.Values = new ChartValues<IterationUnit>();
                    foreach (IterationUnit itr in FD_Itr_Demo.Iteration)
                    {
                        item.Values.Add(itr);


                    }
                        //graphInvestmentOverview.AxisX
                }
            }

            graphInvestmentOverview.Series.Clear();
            graphInvestmentOverview.Series  = temp_collection;
            //graphInvestmentOverview.AxisX.Where(x => x.Title.Equals(FD_Itr_Demo.Detail.Name)).FirstOrDefault<Axis>().LabelFormatter = value => new DateTime((long)value).ToString("yyyy-MM:dd HH:mm:ss");
            //var aa = graphInvestmentOverview.AxisX.Where(x => x.Title.Equals(FD_Itr_Demo.Detail.Name)).FirstOrDefault<Axis>();
            Labels = new[]
            {
                "Shea Ferriera",
                "Maurita Powel",
                "Scottie Brogdon",
                "Teresa Kerman",
                "Nell Venuti",
                "Anibal Brothers",
                "Anderson Dillman"
            };
#endif


            CartesianMapper<IterationUnit> config = new CartesianMapper<IterationUnit>()
                .X(point => point.Iteration_Date.Ticks)
                .Y(point => point.Opening_Balance);

            temp_collection = new SeriesCollection(config);
            temp_collection.Add(new LineSeries
            {
                Title = FD_Itr_Demo.Detail.Name,

            });
            foreach (var item in temp_collection)
            {
                if (item.GetType() == typeof(LineSeries) && item.Title.Equals(FD_Itr_Demo.Detail.Name))
                {
                    item.Values = new ChartValues<IterationUnit>();
                    foreach (IterationUnit itr in FD_Itr_Demo.Iteration)
                    {
                        item.Values.Add(itr);


                    }
                }
            }

            GraphView obj = new GraphView(FD_Itr_Demo);
            obj.InitializeComponent();
            obj.Show();

        }

        //public string[] Labels { get; set; }
    }
}
