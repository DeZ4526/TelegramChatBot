using ChatBot.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.DataBase
{
	class PostgreSQL : IInformator, ILogin
	{
		NpgsqlConnection conn;
		NpgsqlCommand cmd;
		NpgsqlDataReader dr;
		public PostgreSQL(string server, string userId, string password, string dataBase)
		{
			// Specify connection options and open an connection
			conn = new NpgsqlConnection(
				"Server=" + server + ";User Id=" + userId + ";" +
				"Password=" + password + ";Database=" + dataBase + ";");
			conn.Open();
		}
		public void AddLesson(int Id, string title, int teacherId)
		{
			throw new NotImplementedException();
		}

		public void AddTask(int Id, string title, string text, DateOnly startDate, DateOnly endDate, string regUserName)
		{
			throw new NotImplementedException();
		}
		private string[,] GetTeachers()
		{

			cmd = new NpgsqlCommand("select Count(*) from Teachers", conn);
			dr = cmd.ExecuteReader();
			dr.Read();
			Int64 count = (Int64)dr[0];
			dr.Close();

			cmd = new NpgsqlCommand("select Name, Surname from Teachers", conn);
			dr = cmd.ExecuteReader();
			string[,] result = new string[count, 2];

			for (int i = 0; i < count; i++)
			{
				dr.Read();
				result[i, 0] = dr[0].ToString();
				result[i, 1] = dr[1].ToString();
			}
			dr.Close();
			return result;
		}
		public int GetIdLesson(string title)
		{
			cmd = new NpgsqlCommand("SELECT Lesson_id FROM Lessons WHERE Title='" + title + "';", conn);
			dr = cmd.ExecuteReader();
			dr.Read();
			int result;
			try
			{
				result = (int)dr[0];
			}
			catch
			{
				result = -1;
			}
			dr.Close();
			return result;

		}

		public int GetIdTeacher(string name, string surname)
		{
			cmd = new NpgsqlCommand("SELECT Teacher_id FROM Teachers WHERE Name='" + name + "' and Surname='" + surname + "';", conn);
			dr = cmd.ExecuteReader();
			dr.Read();
			int result;
			try
			{
				result = (int)dr[0];
			}
			catch
			{
				result = -1;
			}
			dr.Close();
			return result;

		}

		public string[,] GetLessons(string group)
		{
			int groupId = GetIdAccount(group);
			string[,] Teachers = GetTeachers();

			cmd = new NpgsqlCommand("select Count(*) from Lessons WHERE Account_id="+ groupId, conn);
			dr = cmd.ExecuteReader();
			dr.Read();
			Int64 count = (Int64)dr[0];
			dr.Close();

			cmd = new NpgsqlCommand("select * from Lessons WHERE Account_id="+ groupId, conn);
			dr = cmd.ExecuteReader();
			string[,] result = new string[count, 5];
			try
			{
				for (int i = 0; i < count; i++)
				{
					dr.Read();
					result[i, 0] = dr[0].ToString();
					result[i, 1] = dr[1].ToString();
					if (Teachers.GetLength(0) >= (int)dr[3])
					{
						result[i, 2] = Teachers[(int)dr[3] - 1, 0];
						result[i, 3] = Teachers[(int)dr[3] - 1, 1];
					}
					else
					{
						result[i, 2] = dr[3].ToString();
						result[i, 3] = dr[3].ToString();
					}
					result[i, 4] = dr[0].ToString();
				}
			}
			catch
			{
				dr.Close();
				return null;
			}
			dr.Close();
			return result;
		}

		public string[,] GetTasks(int Id)
		{
			try
			{
				cmd = new NpgsqlCommand("SELECT Count(*) FROM Tasks WHERE Lesson_id=" + Id, conn);
				dr = cmd.ExecuteReader();
				dr.Read();
				Int64 count = (Int64)dr[0];
				dr.Close();

				cmd = new NpgsqlCommand("SELECT * FROM Tasks WHERE Lesson_id=" + Id, conn);
				dr = cmd.ExecuteReader();
				string[,] result = new string[count, 5];
				try
				{
					for (int i = 0; i < count; i++)
					{
						dr.Read();
						result[i, 0] = dr[1].ToString();
						result[i, 1] = dr[2].ToString();
						result[i, 2] = dr[3].ToString();
						result[i, 3] = dr[4].ToString();
						result[i, 4] = dr[5].ToString();
					}
				}
				catch
				{
					dr.Close();
					return null;
				}
				dr.Close();
				return result;
			}
			catch
			{
				return null;
			}
		}
		private int GetIdAccount(string Login)
		{
			
			cmd = new NpgsqlCommand("SELECT Account_id FROM Accounts WHERE Login='" + Login + "';", conn);
			dr = cmd.ExecuteReader();
			dr.Read();
			int result;
			try
			{
				result = (int)dr[0];
			}
			catch
			{
				result = -1;
			}
			dr.Close();
			return result;
		}
		public bool Login(string Login, string Password)
		{
			try
			{				
				cmd = new NpgsqlCommand("SELECT count(*) FROM Accounts WHERE Login='" + Login + "' and Password='" + Password + "';", conn);
				dr = cmd.ExecuteReader();
				dr.Read();
				bool result = (Int64)dr[0] > 0;
				dr.Close();
				return result;
			}
			catch
			{
				return false;
			}
		}
	}
}
