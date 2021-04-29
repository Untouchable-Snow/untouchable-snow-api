using Untouchable.Snow.Domain.Catalog;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Untouchable.Snow.Data
{
	public static class DBInitializer
	{
		public static void Initialize(StoreContext context, ILogger logger)
		{
			if (!context.Items.Any())
			{
				var items = new Item[]
				{
					new Item("T-Shirt", "Ohio STate Block O", "Nike", "/images/d1.jpg", 39.99m),
					new Item("Shorts", "Casual shorts", "Nike", "/images/d1.jpg", 49.99m)
				};
				context.Items.AddRange(items);
				context.SaveChanges();
			}
		}
	}
}