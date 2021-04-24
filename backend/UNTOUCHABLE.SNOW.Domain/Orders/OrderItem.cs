using Untouchable.Snow.Domain.Catalog;

namespace Untouchable.Snow.Domain.Order
{
	public class OrderItem
	{
		public int Id { get; set; }
		public Item Item { get; set; }
		public int Quantity { get; set; }
		public decimal Price => Item.Price * Quantity;
	}
}