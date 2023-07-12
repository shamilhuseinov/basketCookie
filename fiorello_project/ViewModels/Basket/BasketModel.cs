using System;
namespace fiorello_project.ViewModels.Basket
{
	public class BasketModel
	{
		public int Id { get; set; }

        public string Title { get; set; }

        public int Count { get; set; }

		public int StockQuantity { get; set; }

		public double Price { get; set; }

		public string PhotoName { get; set; }
	}
}

