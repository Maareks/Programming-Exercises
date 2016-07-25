using System;
using System.IO;

namespace Program1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			




			int pinNumber = 1234;
			int operatorPinNumber = 4321;
			int currentBalance = 1000;
			int atmMoney = 800;
		Start:
			Console.WriteLine("Type:\n1 - User\n2 - Operator");
			int option = Convert.ToInt32(Console.ReadLine());
			switch (option)
			{
				case 1:
					Console.Write("Enter your PIN number: ");
					int typedPinNumber = Convert.ToInt32(Console.ReadLine());
					if (typedPinNumber != pinNumber)
					{
						Console.WriteLine("You have entered the wrong PIN, your card is locked until you unlock it by bank.");
						Console.ReadKey();
					}
					else 
					{
						while (true)
						{
							Console.WriteLine("Type:\n1 - display current balance\n2 - withdraw money\n3 - charge the card with the money inserted into ATM\n4 - LogOut");
							int choosenOption = Convert.ToInt32(Console.ReadLine());
							switch (choosenOption)
							{
								case 1:
									Console.WriteLine("Your current balance is: " + currentBalance + " $");

									break;
								case 2:
									Console.WriteLine("How much do You want to withdraw?");
									int withdrawedMoney = Convert.ToInt32(Console.ReadLine());
									if (withdrawedMoney > atmMoney)
									{
										Console.WriteLine("There is not enough money at an ATM.");
									}
									else if (withdrawedMoney > currentBalance)
									{
										Console.WriteLine("You do not have enough money on your account.");
									}
									else
									{
										currentBalance = currentBalance - withdrawedMoney;
										atmMoney = atmMoney - withdrawedMoney;
										Console.WriteLine("You withdrew " + withdrawedMoney + " $");
										CreateLog("Withdraw", withdrawedMoney);

									}
									break;
								case 3:
									Console.WriteLine("How much do You want to deposit?");
									int depositedMoney = Convert.ToInt32(Console.ReadLine());
									Console.WriteLine("Insert money and press Enter");

									currentBalance = currentBalance + depositedMoney;
									atmMoney = atmMoney + depositedMoney;
									CreateLog("Deposit", depositedMoney);


									break;
								case 4:
									goto Start;

							}

						}
					}
				break;
				case 2:
					Console.Write("Put cashbox into ATM and enter Operator PIN number: ");
					int typedOperatorPinNumber = Convert.ToInt32(Console.ReadLine());
					if (typedOperatorPinNumber != operatorPinNumber)
					{
						Console.WriteLine("You have entered the wrong PIN number.");
						Console.ReadKey();
					}
					else
					{
						atmMoney = atmMoney + 1000;
						Console.WriteLine("1000$ has been added to ATM.");
						CreateLog("Operator puts money", 1000);
						goto Start;
					}
				break;
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
