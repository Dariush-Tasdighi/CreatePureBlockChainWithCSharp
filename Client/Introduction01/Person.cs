// **************************************************
//namespace Client.Introduction01
//{
//	public class Person : object
//	{
//		public Person() : base()
//		{
//		}

//		public int Age { get; set; }

//		public bool IsActive { get; set; }

//		public string FullName { get; set; }
//	}
//}
// **************************************************

// **************************************************
//namespace Client.Introduction01
//{
//	public class Person : object
//	{
//		public Person() : base()
//		{
//		}

//		public int Age { get; set; }

//		public bool IsActive { get; set; }

//		public string? FullName { get; set; }
//	}
//}
// **************************************************

// **************************************************
namespace Client.Introduction01
{
	public class Person : object
	{
		public Person(string fullName) : base()
		{
			FullName = fullName;
		}

		public int Age { get; set; }

		public bool IsActive { get; set; }

		public string FullName { get; set; }
	}
}
// **************************************************
