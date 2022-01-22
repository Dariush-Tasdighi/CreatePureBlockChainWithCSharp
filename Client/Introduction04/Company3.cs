namespace Client.Introduction04
{
	public class Company3 : object
	{
		public Company3(string name) : base()
		{
			Name = name;
		}

		public string Name { get; set; }

		// **********
		private System.Collections.Generic.IList<Person>? _employees;

		/// <summary>
		/// Lazy Loading = Lazy Initialization
		/// </summary>
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
	}
}
