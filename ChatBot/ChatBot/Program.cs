using ChatBot.Model;
using ChatBot.MyConsole;
using ChatBot.MyConsole.Attributes;
using System.Reflection;

namespace ChatBot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Lesson[] lessons = Informator.GetLessons("ПС191");
			MethodInfo[] inf =  typeof(Program).GetMethods();
			
			SConsole.StartReading(new TestCmd());
			
			for (int i = 0; i < lessons.Length; i++)
				Console.WriteLine(lessons[i].ToString());
			Console.ReadLine();
		}
		
		class TestCmd : ConsoleCommandsList
		{
			[ConsoleCommand("Test cmd")]
			public static void CMD(string test, bool t)
			{
				if(t) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(test);
				Console.ResetColor();
			}
			[ConsoleCommand("Exit")]
			public static void Exit()
			{
				Console.WriteLine("Exit");
			}

			[ConsoleCommand("Test")]
			public static void Test(string z)
			{
				Console.WriteLine("Test");
			}
		}
	}
}