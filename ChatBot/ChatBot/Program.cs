using ChatBot.Model;

namespace ChatBot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Lesson[] lessons = Informator.GetLessons("ПС191");
			
			for (int i = 0; i < lessons.Length; i++)
				Console.WriteLine(lessons[i].ToString());
			Console.ReadLine();
		}
	}
}