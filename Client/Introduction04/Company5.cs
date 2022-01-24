namespace Client.Introduction04
{
	public class Company5 : object
	{
		public Company5(string name) : base()
		{
			Name = name;

			_employees =
				new System.Collections.Generic.List<Person>();
		}

		public string Name { get; set; }

		// **********
		//private System.Collections.Generic.IList<Person> _employees; // Compile Error!

		//private System.Collections.Generic.List<Person> _employees; // Note: It is better make it readonly!

		private readonly System.Collections.Generic.List<Person> _employees;

		/// <summary>
		/// ندارد Lazy Loading متاسفانه این روش
		/// و در هر صورت لیست ایجاد می‌شود
		/// </summary>
		public System.Collections.Generic.IReadOnlyList<Person> Employees
		{
			get
			{
				//return _employees;
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

			// **************************************************
			//Employees.Add(person);

			//_employees?.Add(person);

			_employees.Add(person);
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//string fullName =
			//	company.ManagementOffice.Ceo.FullName;
			// **************************************************

			// **************************************************
			//string fullName = null;

			//if(company != null)
			//{
			//	if(company.ManagementOffice != null)
			//	{
			//		if (company.ManagementOffice.Ceo != null)
			//		{
			//			fullName =
			//				company.ManagementOffice.Ceo.FullName;
			//		}
			//	}
			//}
			// **************************************************

			// **************************************************
			//string fullName = null;

			//if ((company != null) &&
			//	(company.ManagementOffice != null) &&
			//	(company.ManagementOffice.Ceo != null))
			//{
			//	fullName =
			//		company.ManagementOffice.Ceo.FullName;
			//}
			// **************************************************

			// **************************************************
			//string fullName =
			//	company?.ManagementOffice?.Ceo?.FullName;
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
