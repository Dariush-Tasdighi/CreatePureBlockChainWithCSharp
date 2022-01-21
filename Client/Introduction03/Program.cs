﻿namespace Client.Introduction03
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			// **************************************************
			// **************************************************
			// **************************************************
			// سرعت بسیار بالایی دارد
			// نیاز دارد که در داخل حافظه پنج خانه پشت سر هم به اندازه اینت اشغال کند
			// بعد از این‌که آرایه ایجاد می‌شود، قابلیت تغییر سایز ندارد
			// **************************************************

			// **************************************************
			var list1 =
				new int[5];

			list1[0] = 10;
			list1[1] = 20;
			list1[2] = 30;
			list1[3] = 40;
			list1[4] = 50;
			// **************************************************

			// **************************************************
			var list2 =
				new int[] { 10, 20, 30, 40, 50 };
			// **************************************************

			// **************************************************
			int[] list3 =
				{ 10, 20, 30, 40, 50 };
			// **************************************************

			// **************************************************
			//var list4 =
			//	{ 10, 20, 30, 40, 50 }; // Compile Error!
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			// می‌باشد Link List مانند
			// **************************************************

			// **************************************************
			//var list5 =
			//	new System.Collections.ArrayList();

			//list5.Add(10);
			//list5.Add(20);
			//list5.Add(30);
			//list5.Add(40);
			//list5.Add(50);

			//foreach (int item in list5)
			//{
			//	System.Console.WriteLine(item);
			//}
			// **************************************************

			// **************************************************
			//var list6 =
			//	new System.Collections.ArrayList();

			//list6.Add(10);
			//list6.Add(20);

			// بی‌دقتی می‌کنیم - خطر مدل این کدنویسی، آن است
			// که خطا در زمان اجرا ایجاد می‌شود و نه در زمان کامپایل
			//list6.Add("Hello, World!");

			//list6.Add(40);
			//list6.Add(50);

			//foreach (int item in list6)
			//{
			//	System.Console.WriteLine(item);
			//}
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//var list7 =
			//	new System.Collections.Generic.List<int>();

			//list7.Add(10);
			//list7.Add(20);
			//list7.Add(30);
			//list7.Add(40);
			//list7.Add(50);

			//foreach (var item in list7)
			//{
			//	System.Console.WriteLine(item);
			//}
			// **************************************************

			// **************************************************
			//var list8 =
			//	new System.Collections.Generic.List<int>();

			//list8.Add(10);
			//list8.Add(20);

			//// در این روش اگر بی‌دقتی کنیم
			//// خطا در زمان کامپایل ظاهر می‌شود
			//// ما باید به عنوان یک حرفه‌ای همیشه به گونه‌ای کدنویسی
			//// کنیم که اگر برنامه ما خطایی داری در زمان کامپایل ظاهر شود و نه در زمان اجرا
			//list8.Add("Hello, World!");

			//list8.Add(40);
			//list8.Add(50);

			//foreach (var item in list8)
			//{
			//	System.Console.WriteLine(item);
			//}
			// **************************************************

			// **************************************************
			//var list9 =
			//	new System.Collections.Generic.List<Person>();

			//list9.Add(new Person { FullName = "Full Name (1)", Age = 21});
			//list9.Add(new Person { FullName = "Full Name (2)", Age = 22 });
			//list9.Add(new Person { FullName = "Full Name (3)", Age = 23 });
			//list9.Add(new Person { FullName = "Full Name (4)", Age = 24 });
			//list9.Add(new Person { FullName = "Full Name (5)", Age = 25 });

			//foreach (var item in list9)
			//{
			//	System.Console.WriteLine(item);
			//}
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
