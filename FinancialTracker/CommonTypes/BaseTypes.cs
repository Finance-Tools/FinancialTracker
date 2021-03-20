using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialTracker.CommonTypes.BaseTypes;

namespace FinancialTracker.CommonTypes
{
    public class BaseTypes
    {
        public enum Period_E
        {
            Day,
            Month,
            Quarter,
            BiAnnual,
            Annual
        }

        public enum InvestmentType_E
        {
            SavingsAccount,
            FixedDeposit,                           // DepositElements
            RecurringDeposit,                       // DepositElements
            RecurringDepositFlexi,
            Stock,
            MutualFunds,
            ElectronicallyTradedFunds,
            Bonds                                   // DepositElements
        }

        public enum Institute_E
        {
            ICICIBank,
            ICICIDirect,
            SBIBank
        }
    }

    public class RateOfInterest
    {

        /// <summary>
        /// Rate of Interest
        /// </summary>
        public double Interest { get; set; }

        /// <summary>
        /// Period at which the rate of interest is calculated
        /// </summary>
        public Period_E Period_Type { get; set; }

        /// <summary>
        /// Recorded date for the ROI
        /// </summary>
        public DateTime Date_Of_Record { get; set; }

        public RateOfInterest()
        {

        }

        public RateOfInterest(double interest, Period_E period_type, DateTime start_date)
        {
            Interest = interest;
            Period_Type = period_type;
            Date_Of_Record = start_date;
        }
    }
}
