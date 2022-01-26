﻿namespace Client.Step05
{
	public class Contract : object
	{
		public Contract() : base()
		{
			_blocks =
				new System.Collections.Generic.List<Block>();
		}

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

		public void AddTransactionAndMineBlock(Transaction transaction)
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
				transaction: transaction, parentHash: parentBlock?.MixHash);

			_blocks.Add(newBlock);

			newBlock.Mine();
		}

		public int GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			int balance = 0;

			foreach (var block in Blocks)
			{
				if (block.Transaction.RecipientAccountAddress == accountAddress)
				{
					balance +=
						block.Transaction.Amount;
				}

				if (block.Transaction.SenderAccountAddress == accountAddress)
				{
					balance -=
						block.Transaction.Amount;
				}
			}

			return balance;
		}

		public bool IsValid()
		{
			for (int index = 1; index <= Blocks.Count - 1; index++)
			{
				var currentBlock = Blocks[index];
				var parentBlock = Blocks[index - 1];

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
