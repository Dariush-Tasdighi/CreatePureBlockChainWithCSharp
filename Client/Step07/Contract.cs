namespace Client.Step07
{
	public class Contract : object
	{
		public Contract(int currentDifficulty = 0, int maxTransactionCountPerBlock = 2) : base()
		{
			CurrentDifficulty = currentDifficulty;
			MaxTransactionCountPerBlock = maxTransactionCountPerBlock;

			Blocks =
				new System.Collections.Generic.List<Block>();

			CreateGenesisBlock();
		}

		public int CurrentDifficulty { get; set; }

		// **********
		public int MaxTransactionCountPerBlock { get; set; }
		// **********

		public System.Collections.Generic.IList<Block> Blocks { get; }

		public void AddTransaction(Transaction transaction)
		{
			var block =
				GetNotMinedBlock();

			if ((block == null) ||
				(block.Transactions.Count >= MaxTransactionCountPerBlock))
			{
				block =
					CreateEmptyBlock();
			}

			block.Transactions.Add(transaction);
		}

		private Block CreateGenesisBlock()
		{
			var genesisBlock =
				CreateEmptyBlock();

			return genesisBlock;
		}

		private Block? GetNotMinedBlock()
		{
			var result =
				Blocks
				.Where(current => current.IsMined() == false)
				.OrderBy(current => current.BlockNumber)
				.FirstOrDefault();

			return result;
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

			Blocks.Add(newBlock);

			return newBlock;
		}

		public int GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			int balance = 0;

			// **********
			var blocks =
				Blocks
				.Where(current => current.IsMined())
				.ToList()
				;
			// **********

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
			// **********
			var blocks =
				Blocks
				.Where(current => current.IsMined())
				.ToList()
				;
			// **********

			for (int index = 1; index <= blocks.Count - 1; index++)
			{
				var currentBlock = blocks[index];
				var parentBlock = blocks[index - 1];

				if (currentBlock.MixHash != currentBlock.CalculateMixHash())
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

		public Block? MineTheFirstNotMinedBlock()
		{
			var block =
				GetTheFirstNotMinedBlock();

			if(block == null)
			{
				return null;
			}

			block.ParentHash = 
		}

		private Block? GetTheFirstNotMinedBlock()
		{
			var result =
				Blocks
				.Where(current => current.IsMined() == false)
				.FirstOrDefault();

			return result;
		}

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
