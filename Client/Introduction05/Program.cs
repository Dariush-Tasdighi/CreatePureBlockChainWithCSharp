namespace Client.Introduction05
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			// **************************************************
			//var result01 =
			//	System.Text.Json.JsonSerializer.Serialize<object?>(value: null);

			//System.Console.WriteLine(result01);
			// **************************************************

			// **************************************************
			//var result02 =
			//	System.Text.Json.JsonSerializer.Serialize(value: 12345);

			//System.Console.WriteLine(result02);
			// **************************************************

			// **************************************************
			//var person01 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//var result03 =
			//	System.Text.Json.JsonSerializer.Serialize(value: person01);

			//System.Console.WriteLine(result03);
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//var person02 =
			//	new Person
			//	{
			//		Age = 49,
			//		FullName = "Dariush Tasdighi",
			//	};

			//var person03 =
			//	new Person
			//	{
			//		Age = 59,
			//		FullName = "Ali Reza Alavi",
			//	};

			//var company01 =
			//	new Company(name: "Sematec Ins.");

			//company01.Hire(person: person02);
			//company01.Hire(person: person03);
			// **************************************************

			// **************************************************
			//var result04 =
			//	System.Text.Json.JsonSerializer.Serialize(value: company01);

			//System.Console.WriteLine(result04);
			// **************************************************

			// **************************************************
			//var options01 =
			//	new System.Text.Json.JsonSerializerOptions
			//	{
			//		WriteIndented = true,
			//	};

			//var result05 =
			//	System.Text.Json.JsonSerializer.Serialize(value: company01, options: options01);

			//System.Console.WriteLine(result05);
			// **************************************************

			// **************************************************
			//System.Console.WriteLine(person02);
			////System.Console.WriteLine(person02.ToString());

			//System.Console.WriteLine(company01);
			////System.Console.WriteLine(company01.ToString());
			// **************************************************

			// **************************************************
			//string jsonString =
			//	person02.ToString();

			//var person04 =
			//	System.Text.Json.JsonSerializer.Deserialize<Person>(json: jsonString);

			//string? fullName =
			//	person04?.FullName;

			//System.Console.WriteLine(fullName);
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
