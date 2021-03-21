using System;
using System.Collections.Generic;
using System.IO;
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
using FinancialTracker.Library;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using static FinancialTracker.CommonTypes.BaseTypes;

namespace FinancialTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //InvestmentComponent FD_Demo;
        //InvestmentIteration FD_Itr_Demo = new InvestmentIteration();

        public MainWindow()
        {
            InitializeComponent();

            //FD_Demo = new InvestmentComponent
            //{
            //    Name = "SBI_FD_10K",
            //    Type = InvestmentType_E.FixedDeposit,
            //    Deposit_Elements = new DepositElements(10000, 1, 5.6, true, DateTime.Now, Period_E.Month),
            //    Institute = Institute_E.ICICIBank
            //};

            //FD_Itr_Demo.Detail = FD_Demo;

            //InvestmentParser obj = new InvestmentParser();
            //FD_Itr_Demo.Iteration.AddRange(obj.Get_IterationUnits(FD_Demo, 30, Period_E.Annual));

            Overall_Summary = new List<InvestmentComponent>();
        }

        private void buttonTrackInvestment_Click(object sender, RoutedEventArgs e)
        {
            if (Overall_Summary.Count > 0)
            {
                InvestmentIteration Itr_Demo = new InvestmentIteration();

                Itr_Demo.Detail = Overall_Summary.FirstOrDefault();

                InvestmentParser objParser = new InvestmentParser();
                Itr_Demo.Iteration.AddRange(
                                            objParser.Get_IterationUnits(Itr_Demo.Detail,
                                                                         30,
                                                                         Period_E.Annual)
                                           );

                GraphView obj = new GraphView(Itr_Demo);
                obj.Show();
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            switch (item.Header.ToString())
            {
                case "_Open":
                    using(StreamReader sr = new StreamReader(".\\..\\..\\Demo_Config\\OverallSummary.json"))
                    {
                        Overall_Summary.Clear();
                        Overall_Summary.AddRange(JsonConvert.DeserializeObject<List<InvestmentComponent>>(sr.ReadToEnd()));
                    }
                    break;

                case "_Save":
                    string output = JsonConvert.SerializeObject(Overall_Summary);
                    using (StreamWriter sw = new StreamWriter(".\\..\\..\\Demo_Config\\OverallSummary.json"))
                    {
                        sw.Write(output);
                        sw.Close();
                    }
                    break;

                default:
                    break;
            }
        }

        public List<InvestmentComponent> Overall_Summary { get; set; }
    }
}
