using CommandPattern.Contracts;
using CommandPattern.Enums;

namespace CommandPattern.Core
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }


        public void ExecuteAction()
        {
            if (this.priceAction == PriceAction.Increase)
            {
                this.product.IncreasePrice(this.amount);
            }
            else 
            {
                this.product.DecreasePrice(this.amount);
            }
        }
    }
}
