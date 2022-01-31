namespace Client.Step03
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (3)");

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

			var transactions =
				new System.Collections.Generic.List<Transaction>();

			// **************************************************
			var transaction1 =
				new Transaction(id: 1, amount: 10,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			transactions.Add(transaction1);
			// **************************************************

			// **************************************************
			var transaction2 =
				new Transaction(id: 2, amount: 20,
				senderAccountAddress: aliRezaAlaviAccount.Address,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			transactions.Add(transaction2);
			// **************************************************

			// **************************************************
			var transaction3 =
				new Transaction(id: 3, amount: 5,
				senderAccountAddress: dariushTasdighiAccount.Address,
				recipientAccountAddress: saraAhmadiAccount.Address);

			transactions.Add(transaction3);
			// **************************************************

			// **************************************************
			// !کاری که یک هکر انجام می‌دهد
			transaction2.Amount = 100;
			// **************************************************

			// **************************************************
			int dariushTasdighiBalance = 0;

			foreach (var transaction in transactions)
			{
				if (transaction.RecipientAccountAddress == dariushTasdighiAccount.Address)
				{
					dariushTasdighiBalance += transaction.Amount;
				}

				if (transaction.SenderAccountAddress == dariushTasdighiAccount.Address)
				{
					dariushTasdighiBalance -= transaction.Amount;
				}
			}
			// **************************************************

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");

			// حال با استفاده از معماری بلاک‌جین، می‌خواهیم عملیات را برای هکر سخت نماییم
			// برای این منظور و قبل از ورود به مرحله بعد، به عکسی
			// قرار داده شده است توجه نمایید Word که در فایل
		}
	}
}
