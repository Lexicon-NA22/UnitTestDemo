using System;

namespace UnitTestDemo
{
    public class Account
    {
        private readonly string name;
        private int pointBalance;

        public string Name { get { return name; } }
        public int PointBalance { get { return pointBalance; } }

        public Account(string name, int startingPoints)
        {
            this.name = name;

            if (startingPoints < 0)
            {
                this.pointBalance = 0;
            }
            else
            {
                this.pointBalance = startingPoints;
            }
        }


        public void SpendPoints(int nrOfPoints)
        {
            if (nrOfPoints > PointBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(nrOfPoints), "Amount of points spent is more than current point balance.");
            }
            if (nrOfPoints < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nrOfPoints));
            }

            pointBalance -= nrOfPoints;
        }

        public void SpendMoney(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            pointBalance += Convert.ToInt32(Math.Floor(amount / 100));
        }
    }
}
