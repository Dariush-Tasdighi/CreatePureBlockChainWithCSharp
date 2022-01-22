namespace Client.Introduction02
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			// **************************************************
			var person =
				new Person
				{
					Age = 49,
					FullName = "Dariush Tasdighi",
				};

			// Result: "FullName:Dariush Tasdighi|Age:49"
			// **************************************************

			// **************************************************
			string result1 = "FullName:" + person.FullName + "|Age:" + person.Age;

			System.Console.WriteLine(result1);
			// **************************************************

			// **************************************************
			string result2 =
				"FullName:" + person.FullName + "|Age:" + person.Age;

			System.Console.WriteLine(result2);
			// **************************************************

			// **************************************************
			string result3 =
				string.Format("FullName:{0}|Age:{1}", person.FullName, person.Age);

			System.Console.WriteLine(result3);
			// **************************************************

			// **************************************************
			int a = 10;
			int b = 20;
			//int c = 30;

			// "A=20,B=10,C=20"
			//string result4 =
			//	string.Format("A={1},B={0},C={1}", a, b, c);
			// همانگونه که در مثال فوق ملاحظه می‌کنید
			// اگر یک متغیر اضافه و به درد نخور هم بنویسیم
			// سامانه صرفا اخطار می‌دهد و خطا نمی‌گیرد

			string result4 =
				string.Format("A={1},B={0},C={1}", a, b);

			System.Console.WriteLine(result4);
			// **************************************************

			// **************************************************
			string result5 =
				$"FullName:{person.FullName}|Age:{person.Age}";

			System.Console.WriteLine(result5);
			// **************************************************

			// **************************************************
			string result6 =
				$"FullName:{ person.FullName }|Age:{ person.Age }";

			System.Console.WriteLine(result6);
			// **************************************************

			// **************************************************
			// بی‌دقتی می‌کنیم
			string result7 =
				$"FoolName:{ person.FullName }|Aig:{ person.Age }";

			System.Console.WriteLine(result7);
			// **************************************************

			// **************************************************
			string result8 =
				$"{ nameof(person.FullName) }:{ person.FullName }|{ nameof(person.Age) }:{ person.Age }";

			System.Console.WriteLine(result8);

			//string result9 =
			//	$"{ nameof(person.FoolName) }:{ person.FullName }|{ nameof(person.Aig) }:{ person.Age }";
			// **************************************************

			// **************************************************
			string result10 =
				$"{ nameof(person.FullName) }:{ person.FullName }" +
				"|" +
				$"{ nameof(person.Age) }:{ person.Age }";

			System.Console.WriteLine(result10);
			// **************************************************

			// **************************************************
			string result11 = string.Empty;

			result11 += "A"; // "A"
			result11 += "B"; // "AB"
			result11 += "C"; // "ABC"
			result11 += "D"; // "ABCD"
			result11 += "E"; // "ABCDE"

			System.Console.WriteLine(result11);
			// **************************************************

			// **************************************************
			var stringBuilder =
				new System.Text.StringBuilder();

			stringBuilder.Append($"{ nameof(person.FullName) }:{ person.FullName }");
			stringBuilder.Append('|');
			stringBuilder.Append($"{ nameof(person.Age) }:{ person.Age }");

			string result12 =
				stringBuilder.ToString();

			System.Console.WriteLine(result12);
			// **************************************************
		}
	}
}
