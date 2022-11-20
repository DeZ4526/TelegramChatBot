using ChatBot.MyConsole.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.MyConsole
{
	static class SConsole
	{
		public static void WriteError(string message)
		{
			WriteError(message, null);
		}
		public static void WriteError(string message, object? args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			WriteLine(message, args);
			Console.ResetColor();
		}
		public static void WriteLine(string message, object? args)
		{
			Console.WriteLine('[' + DateTime.Now.ToString() + "] - " + message, args);
		}
		public static void StartReading(ConsoleCommandsList consoleCommandsList)
		{
			Type type = consoleCommandsList.GetType();

			while (true)
			{
				string? cmd = Console.ReadLine();
				if (cmd != null)
				{
					if (cmd == "help")
					{
						MethodInfo[]? methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
						string info = "";
						for (int i = 0; i < methods.Length; i++)
						{
							var atr = methods[i].GetCustomAttribute(typeof(ConsoleCommandAttribute));
							if (atr != null)
							{
								var param = methods[i].GetParameters();
								info += methods[i].Name;
								for (int j = 0; j < param.Length; j++)
									info += " [" + param[j].Name + "(" + param[j].ParameterType.Name + ")" + "] ";
								info += " - " + ((ConsoleCommandAttribute)atr).Info + '\n';
								
							}
						}
						Console.WriteLine(info);
					}
					else
					{
						string[] param = cmd.Split(' ');
						if (param.Length > 0)
						{
							MethodInfo? method = type.GetMethod(param[0], BindingFlags.Public | BindingFlags.Static);
							if (method != null)
							{
								var atr = method.GetCustomAttribute(typeof(ConsoleCommandAttribute));
								var t = method.GetParameters();
								if (param.Length - 1 == t.Length && atr != null)
								{
									try
									{
										object[] args = new object[t.Length];
										for (int i = 0; i < t.Length; i++)
										{
											if (t[i].ParameterType == typeof(int))
												args[i] = int.Parse(param[i + 1]);
											else if (t[i].ParameterType == typeof(bool))
											{
												try
												{
													args[i] = bool.Parse(param[i + 1]);
												}
												catch
												{
													args[i] = (bool)(param[i + 1] == "1");
												}
											}
											else if (t[i].ParameterType == typeof(string))
												args[i] = param[i + 1];
											else WriteError("Invalid Type of argument [" + i + ']');

										}
										method.Invoke(consoleCommandsList, args);
									}
									catch (Exception ex)
									{
										WriteError(ex.Message);
									}
								}
								else WriteError("Invalid number of arguments");
							}
							else WriteError("Command not found");
						}
						else WriteError("Command not found");
					}
				}
			}
		}
	}
}
