using System.Linq;

namespace Client.Step08
{
	public class Contract : object
	{
		public Contract(int currentDifficulty = 0,
			decimal currentBaseFeePerGas = 0) : base()
		{
			CurrentDifficulty = currentDifficulty;
			CurrentBaseFeePerGas = currentBaseFeePerGas;

			_blocks =
				new System.Collections.Generic.List<Block>();

			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();

			//CreateGenesisBlock();
		}

		// **********
		public int CurrentDifficulty { get; set; }

		public decimal CurrentBaseFeePerGas { get; set; }
		// **********

		// **********
		public readonly System.Collections.Generic.List<Block> _blocks;

		public System.Collections.Generic.IReadOnlyList<Block> Blocks
		{
			get
			{
				return _blocks.AsReadOnly();
			}
		}
		// **********

		// **********
		private readonly System.Collections.Generic.List<Transaction> _pendingTransactions;

		public System.Collections.Generic.IReadOnlyList<Transaction> PendingTransactions
		{
			get
			{
				return _pendingTransactions.AsReadOnly();
			}
		}
		// **********

		//private Block CreateGenesisBlock()
		//{
		//	var genesisBlock =
		//		CreateEmptyBlock();

		//	return genesisBlock;
		//}

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
				new Block(blockNumber: blockNumber, difficulty: CurrentDifficulty,
				baseFeePerGas: CurrentBaseFeePerGas, parentHash: parentBlock?.MixHash);

			_blocks.Add(newBlock);

			return newBlock;
		}

		public void AddTransaction(Transaction transaction)
		{
			_pendingTransactions.Add(transaction);
		}

		public void RemoveTooOldPendingTransaction()
		{
			var oldTime =
				Infrastructure.Utility.Now.AddDays(-1);

			var transactions =
				_pendingTransactions
				.Where(current => current.Timestamp < oldTime)
				.ToList();

			foreach (var transaction in transactions)
			{
				_pendingTransactions.Remove(transaction);
			}
		}

		public Block? Mine(string minerAccountAddress)
		{
			if (_pendingTransactions == null)
			{
				return null;
			}

			//if (block.IsMined())
			//{
			//	return null;
			//}

			CreateEmptyBlock();

			var block =
				Blocks[Blocks.Count - 1];

			for (int index = _pendingTransactions.Count - 1; index >= 0; index--)
			{
				var transaction =
					_pendingTransactions[index];

				var result =
					block.AddTransaction(transaction);

				if (result)
				{
					_pendingTransactions.Remove(transaction);
				}
			}

			block.Mine();

			// **********
			var gift =
				block.GetTotalGasFee() * 90 / 100;

			var newTransaction =
				new Transaction(type: TransactionType.Mining, amount: gift,
				feePerGas: CurrentBaseFeePerGas, recipientAccountAddress: minerAccountAddress);

			AddTransaction(newTransaction);
			// **********

			return block;
		}

		public decimal GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			decimal balance = 0;

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

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
