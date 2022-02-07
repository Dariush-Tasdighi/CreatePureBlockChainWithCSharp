namespace Client.Step08
{
	public class Contract : object
	{
		public Contract
			(int initialDifficulty = 0,
			double currentMiningReward = 0,
			double currentMinimumTransactionFee = 0) : base()
		{
			_blocks =
				new System.Collections.Generic.List<Block>();

			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();

			CurrentDifficulty = initialDifficulty;
			CurrentMiningReward = currentMiningReward;
			CurrentMinimumTransactionFee = currentMinimumTransactionFee;
		}

		public int CurrentDifficulty { get; set; }

		// **********
		public double CurrentMiningReward { get; set; }

		public double CurrentMinimumTransactionFee { get; set; }
		// **********

		// **********
		private readonly System.Collections.Generic.List<Block> _blocks;

		public System.Collections.Generic.IReadOnlyList<Block> Blocks
		{
			get
			{
				return _blocks.AsReadOnly();
			}
		}
		// **********

		// **********
		private System.Collections.Generic.List<Transaction> _pendingTransactions;

		public System.Collections.Generic.IReadOnlyList<Transaction> PendingTransactions
		{
			get
			{
				return _pendingTransactions.AsReadOnly();
			}
		}
		// **********

		// **********
		public bool AddTransaction(Transaction transaction)
		{
			if (transaction.Fee < CurrentMinimumTransactionFee)
			{
				return false;
			}

			switch (transaction.Type)
			{
				case TransactionType.Withdrawing:
				case TransactionType.Transferring:
				{
					double senderBalance =
						GetAccountBalance(accountAddress: transaction.SenderAccountAddress!);

					if (senderBalance < transaction.Amount)
					{
						return false;
					}

					break;
				}
			}

			_pendingTransactions.Add(transaction);

			return true;
		}
		// **********

		private Block GetNewBlock()
		{
			Block? parentBlock = null;
			int blockNumber = Blocks.Count;

			if (blockNumber != 0)
			{
				parentBlock =
					Blocks[blockNumber - 1];
			}

			var newBlock =
				new Block(blockNumber: blockNumber,
				difficulty: CurrentDifficulty, parentHash: parentBlock?.MixHash);

			return newBlock;
		}

		public Block Mine(string accountAddress)
		{
			var block =
				GetNewBlock();

			// **************************************************
			double totalTransactionFee = 0;

			foreach (var currentTransaction in PendingTransactions)
			{
				block.AddTransaction(currentTransaction);
				totalTransactionFee += currentTransaction.Fee;
			}

			double totalAmountForMiner =
				CurrentMiningReward + totalTransactionFee;

			var minerTransaction =
				new Transaction(fee: 0,
				amount: totalAmountForMiner,
				type: TransactionType.Mining,
				recipientAccountAddress: accountAddress);

			block.AddTransaction(minerTransaction);
			// **************************************************

			block.Mine();

			_blocks.Add(block);

			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();

			return block;
		}

		public bool IsValid()
		{
			for (int index = 1; index <= _blocks.Count - 1; index++)
			{
				var currentBlock = _blocks[index];
				var parentBlock = _blocks[index - 1];

				var currentMixHash =
					currentBlock.CalculateMixHash();

				if (currentBlock.MixHash != currentMixHash)
				{
					return false;
				}

				if (currentBlock.ParentHash != parentBlock.MixHash)
				{
					return false;
				}
			}

			return true;
		}

		public double GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			double balance = 0;

			foreach (var block in _blocks)
			{
				foreach (var transaction in block.Transactions)
				{
					if (transaction.RecipientAccountAddress == accountAddress)
					{
						balance +=
							transaction.Amount;
					}

					if (transaction.SenderAccountAddress == accountAddress)
					{
						balance -=
							transaction.Amount;
					}
				}
			}

			// **********
			// مهم
			// **********
			foreach (var transaction in _pendingTransactions)
			{
				if (transaction.SenderAccountAddress == accountAddress)
				{
					balance -=
						transaction.Amount;
				}
			}
			// **********

			return balance;
		}

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
