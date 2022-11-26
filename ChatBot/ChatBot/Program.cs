using ChatBot.DataBase;
using ChatBot.Model;
using ChatBot.MyConsole;
using ChatBot.MyConsole.Attributes;
using Npgsql;
using System.Reflection;

namespace ChatBot
{
	internal class Program
	{
		static PostgreSQL postgre = new("127.0.0.1", "postgres", "root", "TelegramBot");
		static void Main(string[] args)
		{

			//postgre.GetLessons("ПС191");
			
			Lesson[] lessons = Informator.GetLessons("ПС191");
			for (int i = 0; i < lessons.Length; i++)
				Console.WriteLine(lessons[i].ToString());
			
			Console.WriteLine("------------------------------");
			lessons = Informator.GetLessons("ПС221");
			for (int i = 0; i < lessons.Length; i++)
				Console.WriteLine(lessons[i].ToString());

			SConsole.StartReading(new TestCmd());
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
			[ConsoleCommand("Test cmd")]
			public static void Login(string login, string psw)
			{
				SConsole.WriteLine(postgre.Login(login, psw).ToString());
			}
			[ConsoleCommand("Test cmd")]
			public static void GetIdLesson(string title)
			{
				SConsole.WriteLine(postgre.GetIdLesson(title).ToString());
			}
			[ConsoleCommand("Test cmd")]
			public static void GetIdTeacher(string name, string surname)
			{
				SConsole.WriteLine(postgre.GetIdTeacher(name, surname).ToString());
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