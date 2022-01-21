namespace Client.Introduction02
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			var person =
				new Person
				{
					Age = 49,
					FullName = "Dariush Tasdighi",
				};

			// Result: "FullName:Dariush Tasdighi|Age:49"

			string result1 = "FullName:" + person.FullName + "|Age:" + person.Age;

			string result2 =
				"FullName:" + person.FullName + "|Age:" + person.Age;

			string result3 =
				string.Format("FullName:{0}|Age:{1}", person.FullName, person.Age);

			int a = 10;
			int b = 20;
			int c = 30;

			string result4 =
				string.Format("A={1},B={0},C={1}", a, b, c); // "A=20,B=10,C=20"

			string result5 =
				$"FullName:{person.FullName}|Age:{person.Age}";

			string result6 =
				$"FullName:{ person.FullName }|Age:{ person.Age }";

			string result7 =
				$"FoolName:{ person.FullName }|Aig:{ person.Age }"; // بی‌دقتی می‌کنیم

			string result8 =
				$"{ nameof(person.FullName) }:{ person.FullName }|{ nameof(person.Age) }:{ person.Age }";

			//string result9 =
			//	$"{ nameof(person.FoolName) }:{ person.FullName }|{ nameof(person.Aig) }:{ person.Age }";

			// Result: "FullName:Dariush Tasdighi|Age:49"

			string result10 =
				$"{ nameof(person.FullName) }:{ person.FullName }" +
				"|" +
				$"{ nameof(person.Age) }:{ person.Age }";

			string result11;

			result11 = "A"; // "A"
			result11 += "B"; // "AB"
			result11 += "C"; // "ABC"
			result11 += "D"; // "ABCD"
			result11 += "E"; // "ABCDE"

			var result12 =
				new System.Text.StringBuilder();

			result12.Append($"{ nameof(person.FullName) }:{ person.FullName }");
			result12.Append("|");
			result12.Append($"{ nameof(person.Age) }:{ person.Age }");

			string result13 =
				result12.ToString();

			System.Console.WriteLine(result13);
		}
	}
}
