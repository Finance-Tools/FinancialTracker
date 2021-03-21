using FinancialTracker.CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialTracker.CommonTypes.BaseTypes;
using Microsoft.VisualBasic;

namespace FinancialTracker.Library
{
    public class InvestmentParser
    {
        public List<IterationUnit> Get_IterationUnits(InvestmentComponent details)
        {
            List<IterationUnit> output_unit_list = new List<IterationUnit>();

            if (InvestmentType_E.FixedDeposit == details.Type)
            {
                int principal = details.Deposit_Elements.Principal;
                int period = details.Deposit_Elements.Period;
                DateTime start_date = details.Deposit_Elements.Creation_Date;
                RateOfInterest roi = details.Deposit_Elements.Rate_Of_Interest_List.OrderByDescending(x => x.Date_Of_Record).First();
                double current_value = principal;

                if (roi.Period_Type == Period_E.Month)
                {
                    output_unit_list.Add(new IterationUnit(start_date, current_value));

                    for (int i = 0; i < 30; i++)
                    {
                        current_value = Financial.FV(Rate: (double)(roi.Interest / 100) / 12, NPer: (double)12, 0, (double)-current_value);

                        output_unit_list.Add(new IterationUnit(start_date.AddYears(i), current_value));
                    }
                }

            }

            return output_unit_list;
        }
    }
}
