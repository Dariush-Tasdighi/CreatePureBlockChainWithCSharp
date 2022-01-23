namespace Client.Introduction05
{
	public class Company : object
	{
		public Company(string name) : base()
		{
			Name = name;

			_employees =
				new System.Collections.Generic.List<Person>();
		}

		public string Name { get; set; }

		// **********
		[System.Text.Json.Serialization.JsonPropertyName(nameof(Employees))]
		private readonly System.Collections.Generic.List<Person> _employees;

		public System.Collections.Generic.IReadOnlyList<Person> Employees
		{
			get
			{
				return _employees.AsReadOnly();
			}
		}
		// **********

		public void Hire(Person person)
		{
			if (person.Age < 20)
			{
				return;
			}

			_employees.Add(person);
		}

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
