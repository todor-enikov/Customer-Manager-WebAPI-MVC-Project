namespace CustomerManager.Common.Models
{
    public class OrderModel
    {
        public decimal Total { get; set; }

        public int ProductsCount { get; set; }

        public bool IsProductInProduction { get; set; }

        public bool IsThereEnoughUnitsInStock { get; set; }
    }
}
