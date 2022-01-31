namespace Client.Step02
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (2)");

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

			// ایرادی که این طراحی دارد آن است که یک هکر به راحتی و در یک زمان بسیار کوتاه، می‌تواند
			// اطلاعات یک تراکنش را در بانک اطلاعاتی تغییر دهد و مانده حساب کیف پول خود را افزایش دهد

			// در مرحله بعد، داریوش تصدیقی به عنوان یک هکر ، مبلغ انتقالی علی رضا علوی به خود را در
			// جدول تراکنش‌های بانک اطلاعاتی، از بیست دلار به مثلا صد دلار تغییر داده و مانده حساب کیف پول
			// خود را به صورت غیر قانونی، به عدد یک‌صد و پنج دلار افزایش می‌دهد

			// دقت داشته باشید که این‌گونه مشکلات در سامانه‌های انبارداری، حسابداری و سایت‌های خرید و فروش
			// به کرات رخ می‌دهد
		}
	}
}
