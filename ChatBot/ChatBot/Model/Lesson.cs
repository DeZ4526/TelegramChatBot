namespace ChatBot.Model
{
	internal class Lesson
	{
		public readonly string Title;
		public readonly Teacher Teacher;
		public readonly StudyTask[] Tasks;

		public Lesson(string title, Teacher teacher, StudyTask[] tasks)
		{
			Title = title;
			Teacher = teacher;
			Tasks = tasks;
		}

		public override string ToString()
		{
			string result = "Lesson title:" + Title +
				"\nTeacher:" + Teacher.ToString();
			if(Tasks != null)
				for (int i = 0; i < Tasks.Length; i++)
					result += '\n' + Tasks[i].ToString();
			return result;
		}
	}
}
