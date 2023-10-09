using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalc
{
    public enum Duration
    {
        TenYears = 10,
        FifteenYears = 15,
        ThirtyYears = 30
    }
    public class Mortgage
    {
        //prop
        public Duration MortgageDuration { get; set; }
        public double InterestRate { get; set; }
        public double PrincipalAmount { get; set; }
        public DateTime OriginationDate { get; set; }
        public List<Payment> Payments { get; private set; }

        //ctor
        public Mortgage(Duration duration, double interestRate, double principleAmount, DateTime originationDate)
        {
            MortgageDuration = duration;
            InterestRate = interestRate;
            PrincipalAmount = principleAmount;
            OriginationDate = originationDate;
            Payments = new List<Payment>();

            GenerateAmortizationSchedule();
        }

        //Methods

        //generate amortization sched. & populate payments list
        private void GenerateAmortizationSchedule()
        {
            //calc monthly interestrate
            double monthlyInterestRate = (InterestRate / 100) / 12;
            //calc total payments
            int totalPayments = (int)MortgageDuration * 12;
            //calc monthly payment using EMI
            double monthlyPayment = PrincipalAmount * monthlyInterestRate /
                                    (1 - Math.Pow(1 + monthlyInterestRate, -totalPayments));
            DateTime paymentDate = OriginationDate.AddMonths(1);
            double remainingPrincipal = PrincipalAmount;
            for(int i = 0; i < totalPayments; i++)
            {
                double interestForMonth = remainingPrincipal * monthlyInterestRate;
                double principalForMonth = monthlyPayment - interestForMonth;

                Payments.Add(new Payment
                {
                    Date = paymentDate,
                    InterestAmount = interestForMonth,
                    PrincipalAmount = principalForMonth,
                    Total = monthlyPayment
                });
            }
        }
        public DateTime GetPayoffDate()
        {
            return OriginationDate.AddYears((int)MortgageDuration);
        }
        public double RemainingPrincipalAtDate(DateTime date)
        {
            //calc remaining principal at the given date
            return 0;
        }
        public double InterestPaidAtDate(DateTime date)
        {
            //calc total interest paid up the set date
            return 0;
        }
        public List<Payment> GetAmortizationSchedule()
        {
            return Payments;
        }
        public class Payment
        {
            public DateTime Date { get; set; }
            public double PrincipalAmount { get; set; }
            public double InterestAmount { get; set; }
            public double Total { get; set; }
        }
    }
}
