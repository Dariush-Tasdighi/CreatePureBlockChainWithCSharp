namespace Client.Step05
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (5)");

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

			var contract =
				new Contract();

			// **************************************************
			var transaction1 =
				new Transaction(id: 1, amount: 10,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction1);
			// **************************************************

			// **************************************************
			var transaction2 =
				new Transaction(id: 2, amount: 20,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransactionAndMineBlock(transaction2);
			// **************************************************

			// **************************************************
			var transaction3 =
				new Transaction(id: 3, amount: 5,
				recipientAccountAddress: saraAhmadiAccount.Address,
				senderAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction3);
			// **************************************************

			System.Console.WriteLine(contract.ToString());

			// **************************************************
			int dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// کاری که هکر انجام می‌دهد
			// **************************************************
			transaction2.Amount = 100;

			// **************************************************
			dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// حال برای این‌که هکر بتواند به نتیجه برسد، نسبتا کار سختی پیش رو دارد
			// اول آن‌که باید پس از تغییر مبلغ در تراکنش، مجددا هش تراکنش را محاسبه کرده
			// و در فیلد مربوطه قرار دهد و دوم باید این عمل را برای کل زنجیره و از بلاک
			// مربوطه تا انتها انجام دهد
			// با توجه به این‌که امروزه سخت‌افزارها به شدت قدرتمند شده‌اند، این عملیات می‌تواند
			// با سرعت نسبتا خوبی انجام شود و لذا هکر مذکور می‌تواند با کمی تلاش به نتیجه
			// مورد نظر برسد، به همین دلیل می‌خواهیم سختی این کار وی را دو چندان نماییم
			// برای این منظور از مفهومی به نام سخت کردن عملیات هش استفاده می‌کنیم
		}
	}
}
