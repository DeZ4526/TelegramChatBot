namespace ChatBot.MyConsole.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	internal class ConsoleCommandAttribute : Attribute 
	{
		private readonly string info;
		public string Info
		{
			get => info;
		}

		public ConsoleCommandAttribute(string info) => this.info = info;
	}
}
