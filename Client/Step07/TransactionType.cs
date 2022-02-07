namespace Client.Step07
{
	public enum TransactionType : int
	{
		/// <summary>
		/// استخراج
		/// </summary>
		Mining = 0,

		/// <summary>
		/// پرداخت
		/// </summary>
		Charging = 1,

		/// <summary>
		/// دریافت
		/// </summary>
		Withdrawing = 2,

		/// <summary>
		/// انتقال
		/// </summary>
		Transferring = 3,
	}
}
