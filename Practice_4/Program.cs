namespace Practice_4
{
    interface IBroadbandPlan
    {
        int GetBroadbandPlanAmount();
    }
    class Black : IBroadbandPlan  
    {
        private readonly bool _isSubcriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;
        public Black(bool isSusbcriptionValid, int discountPercentage)

        { 
            _isSubcriptionValid = isSusbcriptionValid;
            _discountPercentage = discountPercentage;
            if(discountPercentage<0|| discountPercentage>50)
                throw new ArgumentOutOfRangeException();
        }

        public int GetBroadbandPlanAmount()
        {
            if (_isSubcriptionValid)
            {
                int discount = (PlanAmount * _discountPercentage) / 100;
                return PlanAmount - discount;
            }
            return PlanAmount;
        }
    }
    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;
        public Gold(bool isSusbcriptionValid, int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 30)
                throw new ArgumentOutOfRangeException();
            _discountPercentage = discountPercentage;
            _isSubscriptionValid = isSusbcriptionValid;
        }
        public int GetBroadbandPlanAmount()
        {
            if (_isSubscriptionValid)
            {
                int discount = (PlanAmount * _discountPercentage) / 100;
                return PlanAmount - discount;
            }
            else
            {
                return PlanAmount;
            }
        }
    }
    class SubscribedPlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribedPlan(IList<IBroadbandPlan> broadbandPlans)
        {
            _broadbandPlans = broadbandPlans;
        }
        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var result = new List<Tuple<string, int>>();
                foreach (var plan in _broadbandPlans)
                {
                    string planType = plan.GetType().Name;
                    int planAmount = plan.GetBroadbandPlanAmount();
                    result.Add(new Tuple<string, int>(planType, planAmount));
                }

                return result;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true,50),
                new Black(false,10),
                new Gold(true,30),
                new Black(true,20),
                new Gold(false,20)
            };
            var subscriptionPlans = new SubscribedPlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }
        }
    } }

