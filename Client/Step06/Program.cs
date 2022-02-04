namespace Client.Step06
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (6)");

			// **************************************************
			var dariushTasdighiAccount =
				new Account(address: "1")
				{
					FullName = "Dariush Tasdighi",
				};

			var aliRezaAlaviAccount =
				new Account(address: "2")
				{
					FullName = "Ali Reza Alavi",
				};

			var saraAhmadiAccount =
				new Account(address: "3")
				{
					FullName = "Sara Ahmadi",
				};
			// **************************************************

			// **************************************************
			var contract =
				new Contract();

			//var contract =
			//	new Contract(currentDifficulty: 1);

			//var contract =
			//	new Contract(currentDifficulty: 2);

			//var contract =
			//	new Contract(currentDifficulty: 3);
			// **************************************************

			// **************************************************
			var transaction1 =
				new Transaction(amount: 10,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction1);
			// **************************************************

			// **************************************************
			var transaction2 =
				new Transaction(amount: 20,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransactionAndMineBlock(transaction2);
			// **************************************************

			// **************************************************
			// !روی دستگاه من، تقریبا دو دقیقه طول می‌کشد
			// **************************************************
			//contract.CurrentDifficulty = 3;
			// **************************************************

			// **************************************************
			var transaction3 =
				new Transaction(amount: 5,
				recipientAccountAddress: saraAhmadiAccount.Address,
				senderAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction3);
			// **************************************************

			System.Console.WriteLine(contract);

			// **************************************************
			int dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// از آن‌جایی که هزینه و زمان استخراج قابل توجه می‌باشد، شاید صرفی نداشته باشد
			// تا در هر بلاک صرفا یک تراکنش قرار دهیم و شاید بهتر باشد که در داخل هر بلاک
			// تعدادی تراکنش قرار دهیم

			// واقعیت آن است که معمولا در بلاک‌چین‌هایی مانند اتریوم و بین‌کین و غیره
			// در داخل هر بلاک، صرفا یک تراکنش قرار نمی‌دهند

			// حال می‌خواهیم تراکنش موجود در بلاک خود را به فهرستی از تراکنش‌ها تبدیل کرده
			// و مثلا بعد از درج شدن چند تراکنش، نسبت به استخراج آن اقدام نماییم
			// **************************************************
		}
	}
}
