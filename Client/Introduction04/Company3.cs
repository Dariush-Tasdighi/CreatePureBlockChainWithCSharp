namespace Client.Introduction04
{
	/// <summary>
	/// Note: We should use (_), for private fields!
	/// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
	/// </summary>
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
