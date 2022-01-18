namespace Client.Step07
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (7)");

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
				new Contract(currentDifficulty: 2);

			Transaction transaction;

			// **************************************************
			transaction =
				new Transaction(amount: 10,
				type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(amount: 20,
				type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(amount: 5,
				type: TransactionType.Charging,
				recipientAccountAddress: saraAhmadiAccount.Address,
				senderAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			// Step (1)
			// **************************************************
			System.Console.WriteLine(contract.ToString());

			int dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// Step (2)
			// **************************************************
			//contract.Mine();

			//System.Console.WriteLine(contract.ToString());

			//int dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// Step (3)
			// **************************************************
			//contract.Mine();

			//transaction =
			//	new Transaction(amount: 15,
			//	type: TransactionType.Charging,
			//	recipientAccountAddress: dariushTasdighiAccount.Address,
			//	senderAccountAddress: aliRezaAlaviAccount.Address);

			//contract.AddTransaction(transaction);

			//System.Console.WriteLine(contract.ToString());

			//int dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// Step (4)
			// **************************************************
			//contract.Mine();

			//transaction =
			//	new Transaction(amount: 15,
			//	type: TransactionType.Charging,
			//	recipientAccountAddress: dariushTasdighiAccount.Address,
			//	senderAccountAddress: aliRezaAlaviAccount.Address);

			//contract.AddTransaction(transaction);

			//contract.Mine();

			//System.Console.WriteLine(contract.ToString());

			//int dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************
		}
	}
}
