namespace ChatBot.DataBase
{
	internal interface IInformator
	{
		string[,] GetLessons(string group);
		string[,] GetTasks(int Id);
		void AddTask(int Id, string title, string text, DateOnly startDate, DateOnly endDate, string regUserName);
		void AddLesson(int Id, string title, int teacherId);
		int GetIdTeacher(string name, string surname);
		int GetIdLesson(string title);
	}
}
