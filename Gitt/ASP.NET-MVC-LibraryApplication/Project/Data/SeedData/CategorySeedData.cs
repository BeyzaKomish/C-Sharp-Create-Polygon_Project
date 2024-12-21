using Project.Models;

namespace Project.Data.SeedData
{
	public class CategorySeedData
	{
		// I have explained the similar codes int the AuthorSeed data 

		public static List<Category> GetCategory()
		{
			return new List<Category>
			{

				new Category{Id=1,Name="Reference"},
				new Category{Id=2,Name="TextBook"},
				new Category{Id=3,Name="BestSeller"}


			};
		}

	}
}
