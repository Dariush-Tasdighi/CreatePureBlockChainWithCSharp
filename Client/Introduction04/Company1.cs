namespace Client.Introduction04
{
	public class Company1 : object
	{
		public Company1(string name) : base()
		{
			Name = name;
		}

		public string Name { get; set; }

		public System.Collections.Generic.List<Person>? Employees { get; set; }
	}
}
