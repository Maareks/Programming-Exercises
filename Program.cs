using System;
using System.IO;

namespace FirstConsoleProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			



			//StreamWriter w = File.AppendText("log.txt");
			int pinNumber = 1234;
			int currentBalance = 1000;
			int atmMoney = 800;
			Console.Write("Enter your PIN number: ");
			int typedPinNumber = Convert.ToInt32(Console.ReadLine());
			if (typedPinNumber != pinNumber)
			{
				Console.WriteLine("Wpisałeś błędny PIN, twoja karta została zablokowana do momentu odblokowania jej przez bank");
				Console.ReadKey();
			}
			else 
			{
				while (true)
				{
					Console.WriteLine("Type:\n1 - display current balance\n2 - withdraw money\n3 - charge the card with the money inserted into ATM");
					int choosenOption = Convert.ToInt32(Console.ReadLine());
					switch (choosenOption)
					{
						case 1:
							Console.WriteLine("Your current balance is: " + currentBalance + " $");

							break;
						case 2:
							Console.WriteLine("How much Do you want to withdraw?");
							int withdrawedMoney = Convert.ToInt32(Console.ReadLine());
							if (withdrawedMoney > atmMoney) 
							{
								Console.WriteLine("Nie ma tyle pieniędzy w bankomacie.");
							}
							else if (withdrawedMoney > currentBalance)
							{
								Console.WriteLine("Nie masz tylu środków na koncie");
							}
							else 
							{
								currentBalance = currentBalance - withdrawedMoney;
								atmMoney = atmMoney - withdrawedMoney;
								Console.WriteLine("Wybrałes " + withdrawedMoney + " $");
								CreateLog("Withdraw", withdrawedMoney);
								Console.ReadKey();
							}
							break;
						case 3:
							Console.WriteLine("How much do You want to deposit?");
							int depositedMoney = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Insert money and press Enter");

							currentBalance = currentBalance + depositedMoney;
							atmMoney = atmMoney + depositedMoney;
							CreateLog("Deposit", depositedMoney);
							Console.ReadKey();

						break;

					}
				}

			}
		}

	

		public static void Log( TextWriter w, string operation, int amount)
		{
			w.Write("\r\nLog Entry : ");
			w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
				DateTime.Now.ToLongDateString());
			w.WriteLine("  :{0}", operation);
			w.WriteLine("  :{0}", amount);
			w.WriteLine("-------------------------------");
		}

		public static void CreateLog(string operation,int amount)
		{
			using (StreamWriter w = File.AppendText("log.txt"))
			{
				Log( w, operation,amount);
			}
		}
	}
}
