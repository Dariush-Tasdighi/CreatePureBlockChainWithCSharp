namespace Client.Step07
{
	public class Contract : object
	{
		public Contract(int currentDifficulty = 0) : base()
		{
			CurrentDifficulty = currentDifficulty;

			_blocks =
				new System.Collections.Generic.List<Block>();

			// **********
			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();
			// **********

			CreateGenesisBlock();
		}

		public int CurrentDifficulty { get; set; }

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

		private Block CreateGenesisBlock()
		{
			var genesisBlock =
				CreateEmptyBlock();

			return genesisBlock;
		}

		private Block CreateEmptyBlock()
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

			_blocks.Add(newBlock);

			return newBlock;
		}

		public void AddTransaction(Transaction transaction)
		{
			_pendingTransactions.Add(transaction);
		}

		public Block? Mine()
		{
			var block =
				Blocks[Blocks.Count - 1];

			if (block.IsMined())
			{
				return null;
			}

			foreach (var transaction in PendingTransactions)
			{
				block.Transactions.Add(transaction);
			}

			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();

			block.Mine();

			CreateEmptyBlock();

			return block;
		}

		public int GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			var blocks =
				Blocks
				.Where(current => current.IsMined())
				.ToList()
				;

			int balance = 0;

			foreach (var block in blocks)
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

			return balance;
		}

		public bool IsValid()
		{
			var blocks =
				Blocks
				.Where(current => current.IsMined())
				.ToList()
				;

			for (int index = 1; index <= blocks.Count - 1; index++)
			{
				var currentBlock = blocks[index];
				var parentBlock = blocks[index - 1];

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

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
