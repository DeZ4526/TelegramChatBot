namespace ChatBot.Model
{
	class StudyTask
	{
		public readonly string Title;
		public readonly string Text;
		public readonly DateTime StartDate;
		public readonly DateTime EndDate;
		public readonly string RegUserName;

		public StudyTask(string title, string text, DateTime startDate, DateTime endDate, string regUserName)
		{
			Title = title;
			Text = text;
			StartDate = startDate;
			EndDate = endDate;
			RegUserName = regUserName;
		}

		public override string ToString() => 
			"Title:" + Title +
			"\nText:" + Text +
			"\nStartDate:" + StartDate +
			"\nEndDate:" + EndDate +
			"\nUserName:" + RegUserName;
	}
}
