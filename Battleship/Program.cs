using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public class Program
	{
		static void Main(string[] args)
		{

			Console.SetWindowSize(130, 30);
			bool quit = false;
			bool Broken = false;
			bool PlayAgain = false;
			int Continue = 2;

			do
			{
				StartScreen();
				Rules();
				//gets the gamemode choice for the switch statment
				int answer = MainMenu();

				//sets the game to match the mode they chose (1 = classic 2 = classic++)
				switch (answer)
				{
					case 1:
						{

							do
							{
								Classic.Game();

								do
								{
									Broken = false;

									Console.WriteLine("Would you like to...");
									Console.WriteLine("1: Play Again");
									Console.WriteLine("2: Quit");

									try
									{
										Continue = Convert.ToInt32(Console.ReadLine());
									}
									catch
									{
										Console.WriteLine("Not a valid answer");
										Broken = true;
									}

								} while (Broken);

								if (Continue == 1)
									PlayAgain = true;
								else
								{
									PlayAgain = false;
									quit = true;
								}

							} while (PlayAgain);

							break;
						}

					case 2:
						{

							do
							{
								ClassicAdv.Game();

								do
								{
									Broken = false;

									Console.WriteLine("Would you like to...");
									Console.WriteLine("1: Play Again");
									Console.WriteLine("2: Quit");

									try
									{
										Continue = Convert.ToInt32(Console.ReadLine());
									}
									catch
									{
										Console.WriteLine("Not a valid answer");
										Broken = true;
									}

								} while (Broken);


								if (Continue == 1)
									PlayAgain = true;
								else
								{
									PlayAgain = false;
									quit = true;
								}

							} while (PlayAgain);

							break;
						}
				}

			} while (!quit);

			//Temp ending while I debug that pauses what is going on and clears the terminal
			Console.WriteLine("Press ANY key to continue");
			Console.ReadKey();
			Console.Clear();
		}

		static void StartScreen()
		{
			Console.Clear();
			Console.WriteLine("");
			Console.WriteLine("");
			CenterText("  !!!!!!!        !!!       !!!!!!!!   !!!!!!!!!    !!         !!!!!!!     !!!!!!!     !!    !!     !!!!!     !!!!!!!   ");
			CenterText("  !!!  !!!      !! !!         !!         !!!       !!         !!         !!!          !!    !!      !!!      !!   !!!  ");
			CenterText("  !!!!!!       !!---!!        !!         !!!       !!         !!!!!!!     !!!!!!      !!!!!!!!      !!!      !!  !!!   ");
			CenterText("  !!!  !!!    !!     !!       !!         !!!       !!         !!              !!!     !!    !!      !!!      !!        ");
			CenterText("  !!!!!!     !!       !!      !!         !!!       !!!!!!     !!!!!!!     !!!!!       !!    !!     !!!!!     !!        ");
			Console.WriteLine("");
			Console.WriteLine("");
			CenterText("Welcome to Battleship, the C# version");
			CenterText("Press any button to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public static void Rules()
		{
			Console.Clear();
			CenterText("Help Screen");
			Console.WriteLine();
			Console.WriteLine("-If a question has a (Y/N) at the end, pressing y or Y will accept all other keys will automatically deny.");
			Console.WriteLine("-If a question has a (Y/N) at the end, DO NOT hit enter after you put your input.");
			Console.WriteLine();
			CenterText("Rules and How to play:");
			Console.WriteLine("(1) The player (you) will begin by picking a game mode (press 10 for info on the game mode)");
			Console.WriteLine("(2) After you choose a game mode, you will setup the board by placing your ships");
			Console.WriteLine("(3) While you place your ships the AI will be setting up their ships");
			Console.WriteLine("(4) Once you place your ships the game will begin!)");
			Console.WriteLine("(5) To shoot enter the x and y coordinates and it will mark the board where you shot and tell you if you hit or miss.");
			Console.WriteLine("(6) once you shoot the ai will shoot and place a X for miss and a H for hit on your right board. ");
			Console.WriteLine("(7) The game will end when either all the player's ships are down or all of the AI's ships are down.");
			Console.WriteLine();
			CenterText("Press the H key to return to this menu after any round.");
			Console.WriteLine();
			CenterText("Press any button to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public static char Options(int coorx, int coory)
		{
			bool Broken = false;
			bool Repeat = false;
			char answer = 'n';
			char i = 'e';

			do
			{
				Repeat = false;
				do
				{
					Broken = false;

					Console.WriteLine();
					Console.WriteLine("Options Menu:");
					Console.WriteLine();
					Console.WriteLine("L: Launch torpedo at coordinates ({0},{1}).", coorx, coory);
					Console.WriteLine("N: Set new coordinates for shot.");
					Console.WriteLine("H: go to the rules and help menu.");
					Console.WriteLine("X: exit and quit the game.");

					try
					{
						i = Char.ToLower(Console.ReadKey(false).KeyChar);
						Console.ReadKey();
					}
					catch
					{
						Console.WriteLine("Input is invalid. Try again.");
						Broken = true;
						Console.Clear();
					}
				} while (Broken);

				switch (i)
				{
					case 'l':
						{
							Console.Clear();
							Console.WriteLine("Launching Torpedoes!");
							Console.WriteLine();
							return 'l';
						}
					case 'n':
						{
							Console.Clear();
							Console.WriteLine("Setting new coordinates.");
							Console.WriteLine();
							return 'n';
						}
					case 'x':
						{
							Console.Clear();
							CenterText("Are you sure you wish to close the game? (Y/N)");
							try
							{
								answer = Char.ToLower(Console.ReadKey(false).KeyChar);
								Console.ReadKey();
							}
							catch
							{
								System.Environment.Exit(1);
							}
							if (answer == 'y')
							{
								System.Environment.Exit(1);
							}
							else
							{
								break;
							}
							return 'x';
						}
					case 'h':
						{
							Rules();
							return 'h';
						}
					default:
						{
							Repeat = true;
							break;
						}
				}
			} while (Repeat);

			return 'e';
		}

		public static char Options()
		{
			bool Broken = false;
			bool Repeat = false;
			char answer = 'n';
			char i = 'e';

			do
			{
				Repeat = false;

				do
				{
					Broken = false;

					Console.WriteLine();
					Console.WriteLine("Options Menu:");
					Console.WriteLine();
					Console.WriteLine("N: Set coordinates for shot.");
					Console.WriteLine("H: go to the rules and help menu.");
					Console.WriteLine("X: exit and quit the game.");

					try
					{
						i = Char.ToLower(Console.ReadKey(false).KeyChar);
						Console.ReadKey();
					}
					catch
					{
						Console.WriteLine("Input is invalid. Try again.");
						Broken = true;
						Console.Clear();
					}
				} while (Broken);

				switch (i)
				{
					case 'n':
						{
							Console.Clear();
							Console.WriteLine("Setting new coordinates.");
							return 'n';
						}
					case 'x':
						{
							Console.Clear();
							CenterText("Are you sure you wish to close the game? (Y/N)");
							try
							{
								answer = Char.ToLower(Console.ReadKey(false).KeyChar);
								Console.ReadKey();
							}
							catch
							{
								System.Environment.Exit(1);
							}
							if (answer == 'y')
							{
								System.Environment.Exit(1);
							}
							else
							{
								break;
							}
							return 'x';
						}
					case 'h':
						{
							return 'h';
						}
					default:
						{
							Repeat = true;
							break;
						}
				}
			} while (Repeat);

			return 'e';
		}


		public static void CenterText(string str)
		{
			try
			{
				Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
			}
			catch
			{

			}
			Console.WriteLine(str);
		}

		static int MainMenu()
		{
			//The choice they make gets stored as answer
			int answer;

			//this loop forces the player to pick a valid game mode before It will move on
			while (true)
			{
				Console.WriteLine("Choose a game mode.");
				Console.WriteLine("1: Classic (default)");
				Console.WriteLine("2: Classic++");
				Console.WriteLine("10: Show rules and game mode explanations.");
				try
				{
					answer = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					Console.WriteLine("Input is invalid. Defaulting to Classic game mode.");
					answer = 1;
				}

				switch (answer)
				{
					case 1:
						//returns 1 for the Classic game mode
						Console.Clear();
						Console.WriteLine("You choose Classic game mode.");
						return 1;

					case 2:
						//returns 2 for the classic++ game mode
						Console.Clear();
						Console.WriteLine("You choose Classic++.");
						return 2;

					case 10:
						//tells the player what the options are and what the differences are
						Console.Clear();
						Console.WriteLine("Classic: classic Battleship with a 10x10 board and 5 ships.");
						Console.WriteLine();
						Console.WriteLine("Classic++: classic Battleship but you get to choose the number of ships and the board size.");
						Console.WriteLine();
						break;

					default:
						Console.WriteLine("Fine don't pick one then. You are now playing Classic.");
						return 1;
				}
			}
		}

		public static void SetUp(out int x, out int y, out int ship5, out int ship4, out int ship3, out int ship2)
		{
			//default values if they are not given
			x = 11;
			y = 11;
			ship5 = 1;
			ship4 = 1;
			ship3 = 2;
			ship2 = 1;

			//setup for the answer
			int answer_int = 0;
			//if this is true something is not working right
			bool Broken = false;

			Console.WriteLine("Would you like to change the number of ships? (Default = 1(# # # # #) 1(# # # #) 2(# # #) 1(# #)) (Y/N)");

			char answer = Console.ReadKey().KeyChar;
			Console.WriteLine();

			//if they reply yes to changing the number of ships start this
			if ((answer == 'Y') || (answer == 'y'))
			{
				//repeat this until there answer is valid
				do
				{
					//no longer broken until they answer again
					Broken = false;

					try
					{
						Console.WriteLine("How many 5 long ships do you want?");
						ship5 = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
					}
					catch
					{
						//stops the player from breaking the game because they enter a char or something that is not valid
						Console.WriteLine("Hey! That is not allowed. Try again.");
						Broken = true;
					}

				} while (Broken);

				//repeats the same thing as above but for the 4 long ship instead
				//there may be a way to compact this code down
				do
				{
					Broken = false;

					try
					{
						Console.WriteLine("How many 4 long ships do you want?");
						ship4 = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
					}
					catch
					{
						Console.WriteLine("Hey! That is not allowed. Try again.");
						Broken = true;
					}
				} while (Broken);

				do
				{
					Broken = false;

					try
					{
						Console.WriteLine("How many 3 long ships do you want?");
						ship3 = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
					}
					catch
					{
						Console.WriteLine("Hey! That is not allowed. Try again.");
						Broken = true;
					}
				} while (Broken);

				do
				{
					Broken = false;

					try
					{
						Console.WriteLine("How many 2 long ships do you want?");
						ship2 = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine();
					}
					catch
					{
						Console.WriteLine("Hey! That is not allowed. Try again.");
						Broken = true;
					}
				} while (Broken);
			}

			do
			{
				Broken = false;

				try
				{
					Console.WriteLine("Would you like to change the default board size? (Default = 10x10) (Y/N)");
					answer = Console.ReadKey().KeyChar;
					Console.WriteLine();
				}
				catch
				{
					Console.WriteLine("Hey! That is not allowed. Try again.");
					Broken = true;
				}
			} while (Broken);

			if ((answer == 'Y') || (answer == 'y'))
			{
				do
				{
					Broken = false;

					try
					{
						Console.WriteLine("What is the X dimension or the length of the new board size? (anything greater than 9 and less than 100 is accepted)");
						answer_int = Convert.ToInt32(Console.ReadLine());
						x = answer_int;
						Console.WriteLine();

						if ((x <= 9) || (x >= 100))
						{
							Console.WriteLine("Hey! That number is out of bounds.");
							Broken = true;
						}

					}
					catch
					{
						Console.WriteLine("Hey! That is not allowed. Try again.");
						Broken = true;
					}

				} while (Broken);

				do
				{
					Broken = false;

					try
					{
						Console.WriteLine("What is the height of the new Board or the Y dimension? (anything greater than 9 and less than 100 is accepted)");
						answer_int = Convert.ToInt32(Console.ReadLine());
						y = answer_int;
						Console.WriteLine();

						if ((y <= 9) || (y >= 100))
						{
							Console.WriteLine("Hey! that number is out of bounds.");
							Broken = true;
						}

					}

					catch
					{
						Console.WriteLine("Hey! that is not allowed. Try again");
						Broken = true;
					}

				} while (Broken);
			}
		}
	}
}
