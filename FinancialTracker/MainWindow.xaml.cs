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
using FinancialTracker.Library;
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
        InvestmentComponent FD_Demo;
        InvestmentIteration FD_Itr_Demo = new InvestmentIteration();

        public MainWindow()
        {
            InitializeComponent();

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
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2022, 5, 1), 10300));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2023, 5, 1), 10300));
            FD_Itr_Demo.Iteration.Add(new IterationUnit(new DateTime(2025, 5, 1), 10300));

            InvestmentParser obj = new InvestmentParser();

            FD_Itr_Demo.Iteration.Clear();

            FD_Itr_Demo.Iteration.AddRange(obj.Get_IterationUnits(FD_Demo));
        }

        private void buttonTrackInvestment_Click(object sender, RoutedEventArgs e)
        {
            GraphView obj = new GraphView(FD_Itr_Demo);
            obj.Show();

        }
    }
}
