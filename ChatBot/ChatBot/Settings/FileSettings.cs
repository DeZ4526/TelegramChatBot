namespace ChatBot.Settings
{
	class FileSettings : ISettings
	{
		private readonly string[,] settings = { { "status", "error" } };
		readonly string FileName = "";
		public FileSettings(string FileName)
		{
			this.FileName = FileName;
			if (File.Exists(FileName))
			{
				string[] Lines = File.ReadAllLines(FileName);
				settings = new string[Lines.Length, 2];
				for(int i = 0; i < Lines.Length; i++)
				{
					string[] t = Lines[i].Split(':');
					if (t.Length == 2)
					{
						settings[i, 0] = t[0];
						settings[i, 1] = t[1];
					}
				}
			}
		}
		public bool GetBool(string key)
		{
			string val = GetString(key);
			if (val == null) return false;
			return val == "1";
		}

		public int GetInt(string key)
		{
			string val = GetString(key);
			if (val == null) return 0;
			return int.Parse(val);
		}

		public string GetString(string key)
		{
			for(int i = 0; i < settings.GetLength(0); i++)
			{
				if(settings[i, 0] == key)
					return settings[i, 1];
			}
			return null;
		}

		public void SetBool(string key, bool value) => 
			SetString(key, value ? "1" : "0");

		public void SetInt(string key, int value) =>
			SetString(key, value.ToString());

		public void SetString(string key, string value)
		{
			for (int i = 0; i < settings.GetLength(0); i++)
			{
				if (settings[i, 0] == key)
				{
					settings[i, 1] = value;
					break;
				}
			}
			Save();
		}
		private void Save()
		{
			string text = "";
			for (int i = 0; i < settings.GetLength(0); i++)
				text += settings[i, 0] + ':' + settings[i, 1] + '\n';
			File.WriteAllText(FileName, text);
		}
	}
}
