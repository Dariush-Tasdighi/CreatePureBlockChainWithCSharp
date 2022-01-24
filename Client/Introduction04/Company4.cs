namespace Client.Introduction04
{
	public class Company4 : object
	{
		public Company4(string name) : base()
		{
			Name = name;
		}

		public string Name { get; set; }

		// **********
		private System.Collections.Generic.IList<Person>? _employees;

		public System.Collections.Generic.IList<Person> Employees
		{
			get
			{
				if (_employees == null)
				{
					_employees =
						new System.Collections.Generic.List<Person>();
				}

				return _employees;
			}
		}
		// **********

		public void Hire(Person person)
		{
			//if (person == null)
			//{
			//	return;
			//}

			if (person.Age < 20)
			{
				return;
			}

			Employees.Add(person);
			//_employees.Add(person);
		}
	}
}
