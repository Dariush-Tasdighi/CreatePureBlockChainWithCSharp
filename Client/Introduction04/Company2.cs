namespace Client.Introduction04
{
	/// <summary>
	/// 1. Remove Set
	/// 2. It is better set initial value in Constructor!
	/// 3. ReadOnly Properties can be set in Constructor!
	/// 4. It is better use IList instead of List
	/// </summary>
	public class Company2 : object
	{
		public Company2(string name) : base()
		{
			Name = name;

			Employees =
				new System.Collections.Generic.List<Person>();
		}

		public string Name { get; set; }

		//public System.Collections.Generic.IList<Person> Employees { get; } =
		//	new System.Collections.Generic.List<Person>();

		public System.Collections.Generic.IList<Person> Employees { get; }
	}
}
