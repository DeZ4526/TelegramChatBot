namespace ChatBot.DataBase
{
	internal interface IInformator
	{
		string[,] GetLessons(string group);
		string[,] GetTasks(int Id);
	}
}
