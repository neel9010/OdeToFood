using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetRestaurantsByName(string name);

		Restaurant GetById(int id);
	}

	public class InMemoryRestaurantData : IRestaurantData
	{
		private readonly List<Restaurant> restaurants;

		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>()
			{
				new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Georgia", Cuisine = CuisineType.Italian},
				new Restaurant { Id = 2, Name = "Taste of India", Location="India", Cuisine = CuisineType.Indian},
				new Restaurant { Id = 3, Name = "Mexicano Taco", Location="California", Cuisine = CuisineType.Mexican}
			};
		}

		public Restaurant GetById(int id)
		{
			return restaurants.SingleOrDefault(x => x.Id == id);
		}

		public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
		{
			if (name == null)
			{
				return restaurants.OrderBy(x => x.Name);
			}

			return restaurants.
				Where(x => x.Name.StartsWith(name)).
				OrderBy(x => x.Name);
		}
	}
}