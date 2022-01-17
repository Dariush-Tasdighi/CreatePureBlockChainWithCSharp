namespace Client.Step06
{
	public class Account : object
	{
		public Account(string address) : base()
		{
			Address = address;
		}

		public string? FullName { get; set; }

		public string Address { get; protected set; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
