namespace Client.Step02
{
	public class Account : object
	{
		public Account(string address) : base()
		{
			Address = address;
		}

		// در این طراحی، موجودی نهایی کیف پول را در مدل کاربر ذخیره نمی‌کنیم
		// بلکه هر بار که بخواهیم موجودی کیف پول کاربر را بدست آوریم
		// کلیه تراکنش‌هایی که این کاربر در آن دخیل بوده است را بررسی کرده
		// و موجودی حساب وی را بدست می‌آوریم
		// در مایکروسرویس‌ها را در ذهن ما تداعی می‌کند Event Sourcing این طراحی، تا حدودی طراحی
		//public int Balance { get; set; }

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
