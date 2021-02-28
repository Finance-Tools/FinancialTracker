using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialTracker.CommonTypes.BaseTypes;

namespace FinancialTracker.CommonTypes
{
    class InvestmentComponent
    {

        /// <summary>
        /// Name of investment
        /// </summary>
        public string Name { get; set; }


        public InvestmentType_E Type { get; set; }


        public DepositElements Deposit_Elements { get; set; }

        public Institute_E Institute { get; set; }

    }

    class DepositElements
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

        /// <summary>
        /// Is the Deposit Automatically renewed
        /// </summary>
        public bool Is_Auto_Renewed { get; set; }
    }
}
