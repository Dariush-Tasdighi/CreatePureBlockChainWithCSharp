namespace Client.Step07
{
	public enum TransactionType : int
	{
		/// <summary>
		/// استخراج
		/// </summary>
		Mining = 0,

		/// <summary>
		/// واریز
		/// </summary>
		Charging = 1,

		/// <summary>
		/// برداشت
		/// </summary>
		Withdrawing = 2,

		/// <summary>
		/// انتقال
		/// </summary>
		Transferring = 3,
	}
}
