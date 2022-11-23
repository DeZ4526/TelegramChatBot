namespace ChatBot.DataBase
{
	class Plug : IInformator, ILogin
	{
		public void AddLesson(int Id, string title, int teacherId)
		{
			
		}

		public void AddTask(int Id, string title, string text, DateOnly startDate, DateOnly endDate, string regUserName)
		{
			
		}


		public int GetIdLesson(string title)
		{
			return 0;
		}

		public int GetIdTeacher(string name, string surname)
		{
			return 0;
		}

		public string[,] GetLessons(string group)
		{
			string[,] lessons = new string[1, 5];
			lessons[0, 0] = "0";
			lessons[0, 1] = "Информатика";
			lessons[0, 2] = "Иван";
			lessons[0, 3] = "Иванович";
			lessons[0, 4] = "5";
			return lessons;
		}
		public string[,] GetTasks(int Id)
		{
			string[,] Tasks = new string[2, 5];
			Tasks[0, 0] = "Прочитать";
			Tasks[0, 1] = "Прочитать параграф 10";
			Tasks[0, 2] = "20/12/2022";
			Tasks[0, 3] = "25/12/2022";
			Tasks[0, 4] = "Egor";

			Tasks[1, 0] = "Прочитать";
			Tasks[1, 1] = "Прочитать параграф 11";
			Tasks[1, 2] = "25/12/2022";
			Tasks[1, 3] = "30/12/2022";
			Tasks[1, 4] = "Egor";
			return Tasks;
		}

		public bool Login(string Login, string Password)
		{
			return true;
		}
	}
}
