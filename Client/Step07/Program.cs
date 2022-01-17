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

			// **************************************************
			var transaction1 =
				new Transaction(id: 1,
				amount: 10, type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction1);
			// **************************************************

			// **************************************************
			var transaction2 =
				new Transaction(id: 2,
				amount: 20, type: TransactionType.Charging,
				recipientAccountAddress: dariushTasdighiAccount.Address,
				senderAccountAddress: aliRezaAlaviAccount.Address);

			contract.AddTransaction(transaction2);
			// **************************************************

			// **************************************************
			var transaction3 =
				new Transaction(id: 3,
				amount: 5, type: TransactionType.Charging,
				recipientAccountAddress: saraAhmadiAccount.Address,
				senderAccountAddress: dariushTasdighiAccount.Address);

			contract.AddTransaction(transaction3);
			// **************************************************

			System.Console.WriteLine(contract.ToString());

			// **************************************************
			int dariushTasdighiBalance =
				contract.GetAccountBalance
				(accountAddress: dariushTasdighiAccount.Address);

			System.Console.WriteLine($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
			// **************************************************
		}
	}
}
