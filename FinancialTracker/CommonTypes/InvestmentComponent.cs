using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialTracker.CommonTypes.BaseTypes;

namespace FinancialTracker.CommonTypes
{
    public class InvestmentComponent
    {

        /// <summary>
        /// Name of investment
        /// </summary>
        public string Name { get; set; }


        public InvestmentType_E Type { get; set; }


        public DepositElements Deposit_Elements { get; set; }

        public int Stock_Element { get; set; }  // TODO: to be described as Deposit_Elements, but for securities - Stock, MF, ETF, etc.

        public Institute_E Institute { get; set; }

    }
    public class InvestmentIteration
    {
        public InvestmentComponent Detail { get; set; }
        public List<IterationUnit> Iteration { get; set; }

        public InvestmentIteration()
        {
            Detail = null;
            Iteration = new List<IterationUnit>();
        }
    }

    public class IterationUnit
    {

        public DateTime Iteration_Date { get; set; }

        public double Opening_Balance { get; set; }

        public IterationUnit(DateTime date, double balance)
        {
            this.Iteration_Date = date;
            this.Opening_Balance = balance;
        }

    }

    public class DepositElements
    {

        /// <summary>
        /// Amount of initial/recurring investment
        /// </summary>
        public int Principal { get; set; }

        /// <summary>
        /// Period for the Deposit to mature
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Rate of interest for the Deposit
        /// </summary>
        public List<RateOfInterest> Rate_Of_Interest_List { get; set; }

        public DateTime Creation_Date { get; set; }

        /// <summary>
        /// Is the Deposit Automatically renewed
        /// </summary>
        public bool Is_Auto_Renewed { get; set; }

        public DepositElements(int principal, int period, double roi, bool auto_renew, DateTime start_date, Period_E period_type)
        {
            Principal = principal;
            Period = period;
            Rate_Of_Interest_List = new List<RateOfInterest>();
            Rate_Of_Interest_List.Add(new RateOfInterest(roi, period_type, start_date));
            Creation_Date = DateTime.Today;
            Is_Auto_Renewed = auto_renew;
        }
    }
}
