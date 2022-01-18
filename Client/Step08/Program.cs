namespace Client.Step08
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
				new Contract(currentDifficulty: 2,
				currentBaseFeePerGas: (decimal)0.5);

			Transaction transaction;

			// **************************************************
			transaction =
				new Transaction(amount: 10,
				feePerGas: (decimal)0.5,
				type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(amount: 20,
				feePerGas: (decimal)0.6,
				type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(amount: 5,
				feePerGas: (decimal)0.4,
				type: TransactionType.Charging,
				recipientAccountAddress: saraAhmadiAccount.Address,
				senderAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			// Step (1)
			// **************************************************
			//System.Console.WriteLine(contract.ToString());

			//decimal dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance.ToString("#,##0.00")}");
			// **************************************************

			// **************************************************
			// Step (2)
			// **************************************************
			//contract.Mine(dariushTasdighiAccount.Address);

			//System.Console.WriteLine(contract.ToString());

			//decimal dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance.ToString("#,##0.00")}");
			// **************************************************

			// **************************************************
			// Step (3)
			// **************************************************
			//contract.Mine(dariushTasdighiAccount.Address);

			//transaction =
			//	new Transaction(amount: 15,
			//	feePerGas: (decimal)0.7,
			//	type: TransactionType.Charging,
			//	recipientAccountAddress: dariushTasdighiAccount.Address,
			//	senderAccountAddress: aliRezaAlaviAccount.Address);

			//contract.AddTransaction(transaction);

			//System.Console.WriteLine(contract.ToString());

			//decimal dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance.ToString("#,##0.00")}");
			// **************************************************

			// **************************************************
			// Step (4)
			// **************************************************
			contract.Mine(dariushTasdighiAccount.Address);

			transaction =
				new Transaction(amount: 15,
				feePerGas: (decimal)0.7,
				type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransaction(transaction);

			contract.Mine(dariushTasdighiAccount.Address);

			System.Console.WriteLine(contract.ToString());

			decimal dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance.ToString("#,##0.00")}");
			// **************************************************
		}
	}
}
