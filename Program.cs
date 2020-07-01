using System;

namespace MarketStore
{
    abstract class DiscountCard
    {
        protected string cardOwner;
        protected float turnover;
        protected float discountRate;
        protected float purchaseValue;
        abstract public float CalculateDiscount(float valueOfPurchase);
        abstract public float NewDiscountRate();
        public float TotalPurchaseValue()
        {
            return purchaseValue - CalculateDiscount(purchaseValue);
        }

        public float GetDiscountRate()
        {
            return discountRate;
        }

        public float GetPurchaseValue()
        {
            return purchaseValue;
        }
    }

    class Bronze : DiscountCard
    {
        public Bronze(string cardOwner, float turnover, float purchaseValue, float discountRate = 0F)
        {
            this.cardOwner = cardOwner;
            this.turnover = turnover;
            this.purchaseValue = purchaseValue;
            this.discountRate = discountRate;
        }

        override public float NewDiscountRate()
        {
            if (turnover < 100)
            {
                discountRate = 0F;
            }
            else if (turnover >= 100 && turnover <= 300)
            {
                discountRate = 0.01F;
            }
            else
            {
                discountRate = 0.025F;
            }

            return discountRate;
        }

        override public float CalculateDiscount(float valueOfPurchase)
        {
            return valueOfPurchase * NewDiscountRate();
        }
    }

    class Silver : DiscountCard
    {
        public Silver(string cardOwner, float turnover, float purchaseValue, float discountRate = 0.02F)
        {
            this.cardOwner = cardOwner;
            this.turnover = turnover;
            this.purchaseValue = purchaseValue;
            this.discountRate = discountRate;
        }

        override public float NewDiscountRate()
        {
            if (turnover > 300)
            {
                discountRate = 0.035F;
            }

            return discountRate;
        }

        override public float CalculateDiscount(float valueOfPurchase)
        {
            return valueOfPurchase * NewDiscountRate();
        }
    }

    class Gold : DiscountCard
    {
        public Gold(string cardOwner, float turnover, float purchaseValue, float discountRate = 0.02F)
        {
            this.cardOwner = cardOwner;
            this.turnover = turnover;
            this.purchaseValue = purchaseValue;
            this.discountRate = discountRate;
        }

        override public float NewDiscountRate()
        {
            if (turnover >= 100 && turnover < 200)
            {
                discountRate = 0.03F;
            }
            else if (turnover >= 200 && turnover < 300)
            {
                discountRate = 0.04F;
            }
            else if (turnover >= 300 && turnover < 400)
            {
                discountRate = 0.05F;
            }
            else if (turnover >= 400 && turnover < 500)
            {
                discountRate = 0.06F;
            }
            else if (turnover >= 500 && turnover < 600)
            {
                discountRate = 0.07F;
            }
            else if (turnover >= 600 && turnover < 700)
            {
                discountRate = 0.08F;
            }
            else if (turnover >= 700 && turnover < 800)
            {
                discountRate = 0.09F;
            }
            else if (turnover >= 800)
            {
                discountRate = 0.1F;
            }

            return discountRate;
        }

        override public float CalculateDiscount(float valueOfPurchase)
        {
            return valueOfPurchase * NewDiscountRate();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bronze bronzeCard = new Bronze("Owner 2", 0, 150);
            float bronzePurchaseValue = bronzeCard.GetPurchaseValue();

            Console.WriteLine("Bronze:");
            Console.WriteLine("Purchase value: $" + bronzeCard.GetPurchaseValue());
            Console.WriteLine("Discount rate: " + bronzeCard.NewDiscountRate() * 100 + "%");
            Console.WriteLine("Discount: $" + bronzeCard.CalculateDiscount(bronzePurchaseValue));
            Console.WriteLine("Total value: $" + bronzeCard.TotalPurchaseValue());
            Console.WriteLine("");

            Silver silverCard = new Silver("Owner 2", 600, 850);
            float silverPurchaseValue = silverCard.GetPurchaseValue();

            Console.WriteLine("Silver:");
            Console.WriteLine("Purchase value: $" + silverCard.GetPurchaseValue());
            Console.WriteLine("Discount rate: " + silverCard.NewDiscountRate() * 100 + "%");
            Console.WriteLine("Discount: $" + silverCard.CalculateDiscount(silverPurchaseValue));
            Console.WriteLine("Total value: $" + silverCard.TotalPurchaseValue());
            Console.WriteLine("");

            Gold goldCard = new Gold("Owner 3", 1500, 1300);
            float goldPurchaseValue = goldCard.GetPurchaseValue();

            Console.WriteLine("Gold:");
            Console.WriteLine("Purchase value: $" + goldCard.GetPurchaseValue());
            Console.WriteLine("Discount rate: " + goldCard.NewDiscountRate() * 100 + "%");
            Console.WriteLine("Discount: $" + goldCard.CalculateDiscount(goldPurchaseValue));
            Console.WriteLine("Total value: $" + goldCard.TotalPurchaseValue());
        }
    }
}
