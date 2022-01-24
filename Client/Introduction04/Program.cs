namespace Client.Introduction04
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			// **************************************************
			// !در روش ذیل همیشه چهار ستون بدنمان می‌لرزد
			// **************************************************
			//var company1 =
			//	new Company1(name: "Aien Co.");

			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//// ایراد اول
			////company1.Employees.Add(person01); // Runtime Error!

			//if (company1.Employees == null)
			//{
			//	// ایراد دوم
			//	company1.Employees =
			//		new System.Collections.Generic.List<Person>();
			//}

			//company1.Employees.Add(person01);

			//foreach (var person in company1.Employees)
			//{
			//	System.Console.WriteLine(person);
			//}
			// **************************************************

			// **************************************************
			// در روش ذیل چهار ستون بدنمان نمی‌لرزد
			// ولی ممکن است که در شرایطی، ما نیازی به فهرست کارکنان
			// نداشته باشیم، ولی بی‌جهت لیست ایجاد می‌شود
			// **************************************************
			//var company2 =
			//	new Company2(name: "Aien Co.");

			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			////company2.Employees =
			////	new System.Collections.Generic.List<Person>(); // Compile Error!

			//company2.Employees.Add(person01);

			//foreach (var person in company2.Employees)
			//{
			//	System.Console.WriteLine(person);
			//}
			// **************************************************

			// **************************************************
			// در روش ذیل، هم چهار ستون بدنمان نمی‌لرزد
			// و هم وقتی که نیازی به لیست کارکنان نداریم
			// بی‌جهت ایجاد نمی‌شود
			// حال می‌خواهیم به صورت مدیریت شده، یک شخص را
			// در شرکت استخدام کنیم، یعنی اگر سن شخص کمتر از بیست سال
			// بود، امکان استخدام وجود نداشته باشد
			// **************************************************
			//var company3 =
			//	new Company3(name: "Aien Co.");

			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//company3.Employees.Add(person01);

			//var person02 =
			//	new Person
			//	{
			//		Age = 16,
			//		FullName = "Ali Reza Alavi",
			//	};

			//company3.Employees.Add(person02);

			//foreach (var person in company3.Employees)
			//{
			//	System.Console.WriteLine(person);
			//}
			// **************************************************

			// **************************************************
			//var company4 =
			//	new Company4(name: "Aien Co.");

			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//company4.Hire(person01);

			//var person02 =
			//	new Person
			//	{
			//		Age = 16,
			//		FullName = "Ali Reza Alavi",
			//	};

			//company4.Hire(person02);

			//foreach (var person in company4.Employees)
			//{
			//	System.Console.WriteLine(person);
			//}
			// **************************************************

			// **************************************************
			// هر چند که با استفاده از تابع استخدام، استخدام‌های ما
			// مدیریت شده می‌باشد، ولی ممکن است که برنامه‌نویس بی‌دقتی
			// کرده و به جای استفاده از این تابع، از خود لیست برای استخدام استفاده کند
			// **************************************************
			//var company4 =
			//	new Company4(name: "Aien Co.");

			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//company4.Hire(person01);

			//var person02 =
			//	new Person
			//	{
			//		Age = 16,
			//		FullName = "Ali Reza Alavi",
			//	};

			//company4.Hire(person02);

			//company4.Employees.Add(person02);

			//foreach (var person in company4.Employees)
			//{
			//	System.Console.WriteLine(person);
			//}
			// **************************************************

			// **************************************************
			var company5 =
				new Company5(name: "Aien Co.");

			var person01 =
				new Person
				{
					Age = 49,
					FullName = "Dariush Tasdighi",
				};

			company5.Hire(person01);

			var person02 =
				new Person
				{
					Age = 16,
					FullName = "Ali Reza Alavi",
				};

			company5.Hire(person02);

			//company5.Employees.Add(person02); // Compile Error!

			foreach (var person in company5.Employees)
			{
				System.Console.WriteLine(person);
			}
			// **************************************************
		}
	}
}
