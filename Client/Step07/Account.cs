namespace Client.Step07
{
	public class Account : object
	{
		public Account(string address) : base()
		{
			Address = address;
		}

		public string Address { get; }

		public string? FullName { get; set; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
