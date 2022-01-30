﻿namespace Client.Step01
{
	/// <summary>
	/// User
	/// </summary>
	public class Account : object
	{
		public Account(string address) : base()
		{
			Address = address;
		}

		public int Balance { get; set; }

		/// <summary>
		/// Id
		/// باشد Guid در پروژه‌های واقعی بهتر است که
		/// </summary>
		public string Address { get; }

		public string? FullName { get; set; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
