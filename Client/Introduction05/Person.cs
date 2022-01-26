namespace Client.Introduction05
{
	public class Person : object
	{
		public Person() : base()
		{
		}

		public int Age { get; set; }

		public string? FullName { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		public string? Description { get; set; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
