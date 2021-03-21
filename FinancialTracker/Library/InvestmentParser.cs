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
        public List<IterationUnit> Get_IterationUnits(InvestmentComponent details, int iteration_for_period, Period_E type_of_Period)
        {
            List<IterationUnit> output_unit_list = new List<IterationUnit>();

            if (InvestmentType_E.FixedDeposit == details.Type)
            {
                int principal = details.Deposit_Elements.Principal;
                int period = details.Deposit_Elements.Period;
                DateTime start_date = details.Deposit_Elements.Creation_Date;
                RateOfInterest roi = details.Deposit_Elements.Rate_Of_Interest_List.OrderByDescending(x => x.Date_Of_Record).First();
                double current_value = principal;
                int period_in_months = 0;

                if (Period_E.Annual == type_of_Period)
                {
                    period_in_months = 12;
                }
                else if (Period_E.BiAnnual == type_of_Period)
                {
                    period_in_months = 4;
                }
                else if (Period_E.Quarter == type_of_Period)
                {
                    period_in_months = 6;
                }
                else // if(Period_E.Month == type_of_Period)
                {
                    period_in_months = 1;
                }

                output_unit_list.Add(new IterationUnit(start_date, current_value));
                for (int i = 1; i <= iteration_for_period; i++)
                {
                    current_value = Financial.FV(Rate: (double)(roi.Interest / 100) / 12,
                                                 NPer: (double)period_in_months,
                                                 Pmt: (double)0,
                                                 PV: (double)-current_value);

                    output_unit_list.Add(new IterationUnit(start_date.AddMonths(i * period_in_months), current_value));
                }
            }

            return output_unit_list;
        }
    }
}
