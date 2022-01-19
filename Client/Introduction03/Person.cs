namespace Client.Introduction03
{
	public class Person : object
	{
		public Person() : base()
		{
		}

		public int Age { get; set; }

		public bool IsActive { get; set; }

		public string FullName { get; set; }

		public System.Collections.Generic.IList<string> FavoriteColors { get; set; }
	}
}
