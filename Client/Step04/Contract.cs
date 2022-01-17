﻿namespace Client.Step04
{
	/// <summary>
	/// BlockChain
	/// </summary>
	public class Contract : object
	{
		public Contract() : base()
		{
			Blocks =
				new System.Collections.Generic.List<Block>();
		}

		public System.Collections.Generic.IList<Block> Blocks { get; }

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

			Blocks.Add(newBlock);

			newBlock.Mine();
		}

		public int GetAccountBalance(string accountAddress)
		{
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

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
