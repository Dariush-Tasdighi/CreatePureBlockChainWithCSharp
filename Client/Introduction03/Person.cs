namespace Client.Introduction03
{
	public class Person : object
	{
		public Person() : base()
		{
		}

		public int Age { get; set; }

		public string? FullName { get; set; }

		//public override string ToString()
		//{
		//	return base.ToString();
		//}

		public override string ToString()
		{
			var stringBuilder =
				new System.Text.StringBuilder();

			stringBuilder.Append($"{ nameof(FullName) }:{ FullName }");
			stringBuilder.Append("|");
			stringBuilder.Append($"{ nameof(Age) }:{ Age }");

			var result =
				stringBuilder.ToString();

			return result;
		}
	}
}
