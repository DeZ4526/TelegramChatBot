using ChatBot.DataBase;

namespace ChatBot.Model
{
	static class Informator
	{
		private static readonly Plug plug = new();
		private static readonly IInformator informator = plug;
		private static readonly ILogin LoginMachine = plug;

		public static bool Login(string group, string password) => 
			LoginMachine.Login(group, password);

		public static Lesson[] GetLessons(string group)
		{
			string[,] Lessons = informator.GetLessons(group);
			if(Lessons != null)
			{
				Lesson[] result = new Lesson[Lessons.GetLength(0)];
				for(int i = 0; i < Lessons.GetLength(0); i++)
				{
					string[,] stadyTasksStr = informator.GetTasks(int.Parse(Lessons[0, 0]));
					StudyTask[] studyTasks = new StudyTask[stadyTasksStr.GetLength(0)];
					for (int j = 0; j < studyTasks.Length; j++)
					{
						studyTasks[j] = new StudyTask(stadyTasksStr[j, 0], 
							stadyTasksStr[j, 1], 
							DateOnly.Parse(stadyTasksStr[j, 2]), 
							DateOnly.Parse(stadyTasksStr[j, 3]), 
							stadyTasksStr[j, 4]);
					}
					result[i] = new Lesson(Lessons[i, 1], 
						new Teacher(Lessons[i, 2], Lessons[i, 3]), 
						studyTasks);
				}
				return result;
			}
			else throw new InformatorException("Group not found");
		}

		public static void AddLesson(Lesson lesson) =>
			informator.AddLesson(
				informator.GetIdLesson(lesson.Title), 
				lesson.Title, 
				informator.GetIdTeacher(lesson.Teacher.Name, lesson.Teacher.Surname));
	}
	class InformatorException : Exception
	{
		public InformatorException(string message)
		{
		}
	}
}
