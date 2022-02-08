namespace Client.Step08
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			System.Console.WriteLine("Step (8)");

			// **************************************************
			var saraAhmadiAccount =
				new Account(address: "1")
				{
					FullName = "Sara Ahmadi",
				};

			var aliRezaAlaviAccount =
				new Account(address: "2")
				{
					FullName = "Ali Reza Alavi",
				};

			var dariushTasdighiAccount =
				new Account(address: "3")
				{
					FullName = "Dariush Tasdighi",
				};
			// **************************************************

			// **************************************************
			var contract =
				new Contract
				(initialDifficulty: 2,
				currentMiningReward: 6.25,
				currentMinimumTransactionFee: 0.1);

			// **************************************************
			// **************************************************
			// **************************************************
			Transaction transaction;
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(fee: 0.11,
				amount: 100, type: TransactionType.Charging,
				recipientAccountAddress: saraAhmadiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(fee: 0.12,
				amount: 200, type: TransactionType.Charging,
				recipientAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************

			// **************************************************
			transaction =
				new Transaction(fee: 0.13,
				amount: 300, type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction);
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// Step (1)
			// **************************************************
			System.Console.WriteLine(contract);

			double dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine
				($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************

			// **************************************************
			// Step (2)
			// **************************************************
			//contract.Mine(dariushTasdighiAccount.Address);

			//System.Console.WriteLine(contract);

			//double dariushTasdighiBalance =
			//	contract.GetAccountBalance
			//	(accountAddress: dariushTasdighiAccount.Address);

			//System.Console.WriteLine
			//	($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************
		}
	}
}
