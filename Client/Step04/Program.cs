namespace Client.Step04
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (4)");

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

			contract.AddTransactionAndMineBlock(transaction: transaction1);
			// **************************************************

			// **************************************************
			var transaction2 =
				new Transaction(id: 2, amount: 20,
				senderAccountAddress: aliRezaAlaviAccount.Address,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction: transaction2);
			// **************************************************

			// **************************************************
			var transaction3 =
				new Transaction(id: 3, amount: 5,
				senderAccountAddress: dariushTasdighiAccount.Address,
				recipientAccountAddress: saraAhmadiAccount.Address);

			contract.AddTransactionAndMineBlock(transaction: transaction3);
			// **************************************************

			System.Console.WriteLine(contract);

			// **************************************************
			int dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// حال اگر داریوش تصدیقی، به عنوان یک هکر و مانند کاری که در مرحله سه انجام دادیم
			// در جدول تراکنش‌ها که در بانک اطلاعاتی قرار دارد، تغییراتی ایجاد نماید
			// کماکان سامانه به درستی کار می‌کند و هکر به هدف خود خواهد رسید
			// لذا می‌خواهیم یک تابع در کلاس قرارداد ایجاد نماییم که از معتبر بودن زنجیره بلاک‌ها
			// اطمینان حاصل کنیم و زمانی که می‌خواهیم موجودی حساب کیف پول شخصی را بدست آوریم
			// قبل از آن ابتدا اعتبارسنجی کنیم

			// **************************************************
			// کاری که هکر در بانک اطلاعاتی انجام می‌دهد
			contract.Blocks[1].Transaction.Amount = 100;

			dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************
		}
	}
}
