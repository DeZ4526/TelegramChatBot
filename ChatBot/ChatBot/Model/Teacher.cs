namespace ChatBot.Model
{
	class Teacher
	{
		public readonly string Name;
		public readonly string Surname;
		
		public Teacher(string Name, string Surname)
		{
			this.Name = Name;
			this.Surname = Surname;
		}

		public override string ToString() => 
			Name + ' ' + Surname;
	}
}
