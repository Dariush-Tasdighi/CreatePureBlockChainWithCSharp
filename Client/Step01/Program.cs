namespace Client.Step01
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (1)");

			var dariushTasdighiAccount =
				new Account(address: "1")
				{
					Balance = 0,
					FullName = "Dariush Tasdighi",
				};

			System.Console.WriteLine(dariushTasdighiAccount);

			// داریوش تصدیقی کیف پول خود را به اندازه ده دلار شارژ می‌کند
			dariushTasdighiAccount.Balance += 10;

			System.Console.WriteLine(dariushTasdighiAccount);

			// علی رضا علوی از کیف پول خود، مبلغ بیست دلار، به کیف پول داریوش تصدیقی واریز می‌کند
			dariushTasdighiAccount.Balance += 20;

			System.Console.WriteLine(dariushTasdighiAccount);

			// داریوش تصدیقی از کیف پول خود، مبلغ پنج دلار، به کیف پول سارا احمدی واریز می‌کند
			dariushTasdighiAccount.Balance -= 5;

			System.Console.WriteLine(dariushTasdighiAccount);

			// این طراحی ایرادهای زیادی دارد ولی

			// یکی از ایرادهایی که دارد این است که وقتی موجودی کیف پول داریوش تصدیقی
			// عدد بیست و پنج دلار را نمایش می‌دهد، ما مطلقا متوجه نخواهیم شد که در چه زمان‌هایی
			// و با چه رویدادهایی، موجودی داریوش تصدیقی به بیست و پنج دلار رسیده است
			// یعنی تاریخچه تراکنش‌ها را نداریم
		}
	}
}
