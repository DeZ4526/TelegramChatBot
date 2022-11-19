using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Settings
{
	internal interface ISettings
	{
		string GetString(string key);
		int GetInt(string key);
		bool GetBool(string key);

		void SetString(string key, string value);
		void SetInt(string key, int value);
		void SetBool(string key, bool value);
	}
}
