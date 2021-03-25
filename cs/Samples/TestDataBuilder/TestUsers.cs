namespace Samples.TestDataBuilder
{
	public class TestUsers
	{
		public static User ARegularUser() //Что за ссылка на User?
		{
			return new User("Triniti", "tri", "asdasd", "ROLE_USER");
		}

		public static User AnAdmin()
		{
			return new User("Agent Smith", "smith", "qweqwe", "ROLE_ADMIN");
		}
	}
}