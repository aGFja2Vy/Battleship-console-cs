using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	class Program
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

	public class Classic
	{
		public static void Game()
		{
			//Sets the defaults
			//there may be a way to use constructors for this instead
			int x = 10, y = 10;
			int ship5 = 1, ship4 = 1, ship3 = 2, ship2 = 1;
			bool Player_Alive = true;
			bool AI_Alive = true;

			//creates the Board arrays with default values
			char[,] Right_Board = new char[x, y];
			char[,] Left_Board = new char[x, y];
			char[,] AI_Board = new char[x, y];

			//sets all the Board arrays to spaces
			Board.Set_Board(Right_Board, x, y);
			Board.Set_Board(Left_Board, x, y);
			Board.Set_Board(AI_Board, x, y);

			//lets them place there ships
			Board.Set_ship(Right_Board, ship5, ship4, ship3, ship2, x, y);
			AI.AI_Setup(AI_Board, x, y, ship5, ship4, ship3, ship2);

			//repeats until one of the players loses and runs out of ships
			do
			{
				//Console.Clear();
				Player.Attack(Left_Board, AI_Board, Right_Board, x, y);
				Console.WriteLine();
				AI.Attack(AI_Board, Right_Board, x, y);

			} while (Player_Alive && AI_Alive);

		}

	}

	public class ClassicAdv
	{
		public static void Game()
		{
			//sets the default values
			//I think this can be moved somewhere so I dont must re declare these values every 10 fucking lines
			int x = 11, y = 11;
			int ship5 = 1, ship4 = 1, ship3 = 2, ship2 = 1;
			bool Player_Alive = true;
			bool AI_Alive = true;

			//allows the player to pick the Board size and the number of ships
			// gets all the values back for future use
			Program.SetUp(out x, out y, out ship5, out ship4, out ship3, out ship2);

			//sets the board with regards to the dimensions they gave
			char[,] Right_Board = new char[x, y];
			char[,] Left_Board = new char[x, y];
			char[,] AI_Board = new char[x, y];

			//makes all the Board arrays spaces so they can place their ships
			Board.Set_Board(Right_Board, x, y);
			Board.Set_Board(Left_Board, x, y);
			Board.Set_Board(AI_Board, x, y);

			//lets them choose where they want to place their ships
			Player.Display_Board(Left_Board, Right_Board, x, y);
			Board.Set_ship(Right_Board, ship5, ship4, ship3, ship2, x, y);
			AI.AI_Setup(AI_Board, x, y, ship5, ship4, ship3, ship2);

			//repeats until someone runs out of ships
			do
			{
				//Console.Clear();
				Player.Display_Board(Left_Board, Right_Board, x, y);
				Player.Attack(Left_Board, AI_Board, Right_Board, x, y);
				Console.WriteLine();
				AI.Attack(AI_Board, Right_Board, x, y);

			} while (Player_Alive && AI_Alive);
		}
	}

	public class Player
	{
		public static int[,] LastShots = new int[2, 5];
		public static int[,] CurrentShot = new int[2, 1];

		public static void Display_Board(char[,] board, char[,] right_board, int arrx, int arry)
		{

			//This is the x part of the board (top part)
			for (int x = 0; x < 2; x++)
			{
				Console.Write("\t  |  ");

				for (int left = 1; left < arrx + 1; left++)
				{
					Console.Write(left + " ");

					if (left < 10)
						Console.Write(" ");
				}
			}

			Console.WriteLine();

			for (int x = 0; x < 2; x++)
			{
				Console.Write("\t--|");

				for (int seperator = 1; seperator < arrx + 1; seperator++)
					Console.Write("---");
			}

			//End of top part

			//This is the y part of the board and the actual board
			Console.WriteLine();

			for (int i = 0; i < arry; i++)
			{
				//the if statement adds a space to the left side numbers so it stays aligned
				if (i < 9)
					Console.Write("\t" + (i + 1) + " |  ");
				else
					Console.Write("\t" + (i + 1) + "|  ");

				//prints the Board array with a space between each char
				for (int j = 0; j < arrx; j++)
					Console.Write(board[j, i] + "  ");

				// space for the right Board
				Console.Write("\t");

				//same thing as above but for the right Board
				if (i < 9)
					Console.Write((i + 1) + " |  ");
				else
					Console.Write((i + 1) + "|  ");

				for (int j = 0; j < arrx; j++)
					Console.Write(right_board[j, i] + "  ");

				Console.WriteLine();
			}
		}

		public static void Display_Board(char[,] board, int arrx, int arry)
		{

			//This is the x part of the board
			Console.Write("\t  |  ");

			for (int left = 1; left < arrx + 1; left++)
			{
				Console.Write(left + " ");

				if (left < 10)
					Console.Write(" ");
			}

			Console.WriteLine();
			Console.Write("\t--|");

			for (int seperator = 1; seperator < arrx + 1; seperator++)
				Console.Write("---");

			//End of top part

			//This is the y part of the board and the actual board
			Console.WriteLine();
			for (int i = 0; i < arry; i++)
			{
				if (i < 9)
					Console.Write("\t" + (i + 1) + " |  ");
				else
					Console.Write("\t" + (i + 1) + "|  ");

				for (int j = 0; j < arrx; j++)
					Console.Write(board[j, i] + "  ");

				Console.WriteLine();
			}
		}

		public static void Attack(char[,] Player_Board, char[,] AI_Board, char[,] Right_Board, int dix, int diy)
		{
			bool Repeat = false;
			bool loaded = false;
			bool Broken = false;
			int x = 1;
			int y = 1;

			do
			{
				Broken = false;
				Repeat = false;

				try
				{
					if (!loaded)
					{
						do
						{
							Player.Display_Board(Player_Board, Right_Board, dix, diy);
							char answer = Program.Options();
							Broken = false;

							if (answer == 'n')
							{
								Player.Display_Board(Player_Board, Right_Board, dix, diy);
								Console.WriteLine();
								Console.WriteLine("Where would you like to shoot (X)?");
								x = Convert.ToInt32(Console.ReadLine()) - 1;
								Console.WriteLine("Where would you like to shoot (Y)?");
								y = Convert.ToInt32(Console.ReadLine()) - 1;

								CurrentShot[0, 0] = x + 1;
								CurrentShot[1, 0] = y + 1;

								loaded = true;
								Repeat = true;
								Console.Clear();

							}
							else if (answer == 'h')
							{
								Program.Rules();
							}
							else
							{
								Broken = true;
							}

						} while (Broken);
					}
					else
					{
						do
						{
							Player.Display_Board(Player_Board, Right_Board, dix, diy);
							char answer = Program.Options(CurrentShot[0, 0], CurrentShot[1, 0]);
							Broken = false;

							if (answer == 'n')
							{
								Player.Display_Board(Player_Board, Right_Board, dix, diy);
								Console.WriteLine();
								Console.WriteLine("Where would you like to shoot (X)?");
								x = Convert.ToInt32(Console.ReadLine()) - 1;
								Console.WriteLine("Where would you like to shoot (Y)?");
								y = Convert.ToInt32(Console.ReadLine()) - 1;

								CurrentShot[0, 0] = x + 1;
								CurrentShot[1, 0] = y + 1;

								Console.Clear();

							}
							else if (answer == 'l')
							{
								bool validAI = Board.Check_Valid(AI_Board, x, y);
								bool validPL = Board.Check_Valid(Player_Board, x, y);
								bool hit = Board.Check_Hit(AI_Board, x, y);

								if (!validAI || !validPL)
								{
									Console.WriteLine("Not a valid shot. Please choose new x, and y values.");
									Broken = true;
								}

								if (hit && validAI && validPL)
								{
									Console.WriteLine("Hit");
									Player_Board[x, y] = 'H';
								}
								else if (!hit && validAI && validPL)
								{
									Console.WriteLine("Miss");
									Player_Board[x, y] = 'X';
								}

								loaded = false;

								if (!Broken)
									return;

							}
							else if (answer == 'h')
							{
								Program.Rules();
							}
							else
							{
								Broken = true;
							}
						} while (Broken);
					}
				}
				catch
				{
					Console.Clear();
					Program.CenterText("Something went wrong... Please try again.");
					Broken = true;
				}

			} while (Broken || Repeat);
		}
	}


	class Board
	{

		public static void Set_Board(char[,] board, int x, int y)
		{
			for (int i = 0; i < y; i++)
			{
				for (int j = 0; j < x; j++)
					board[j, i] = ' ';
			}
		}

		public static void Set_ship(char[,] board, int ship5, int ship4, int ship3, int ship2, int arrx, int arry)
		{
			bool Broken = false;
			int veiw = 0;
			int coorx = 0;
			int coory = 0;

			do
			{
				Player.Display_Board(board, arrx, arry);

				do
				{
					Broken = false;

					do
					{
						Broken = false;

						try
						{

							Console.WriteLine("Where do you want to place your '# # # # #' ship? (x)");
							coorx = Convert.ToInt32(Console.ReadLine()) - 1;
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
							Console.WriteLine("Where do you want to place your '# # # # #' ship? (y)");
							coory = Convert.ToInt32(Console.ReadLine()) - 1;
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
							Console.WriteLine("How would you like your ship placed?");
							Console.WriteLine("Top to Bottom: 1");
							Console.WriteLine("Left to Right: 2");
							veiw = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("Hey! That is not allowed. Try again.");
							Broken = true;
						}
					} while (Broken);

					if (!Check_Placement(board, coorx, coory, veiw, 5))
					{
						Console.WriteLine("This is invalid placement according to the Check_Placement function");
						Broken = true;
					}

					if ((coorx >= arrx) || (coorx < 0) || (coorx - 4 >= arry))
					{
						Console.WriteLine("Your length value (X) is invalid. Try again.");
						Broken = true;
					}

					if ((coory >= arry) || (coory < 0) || (coory - 4 >= arry))
					{
						Console.WriteLine("Your height value (Y) is invalid. Try again.");
						Broken = true;
					}

					if ((veiw != 1) && (veiw != 2))
					{
						Console.WriteLine("Invalid rotation");
						Broken = true;
					}

				} while (Broken);

				if (veiw == 1)
				{
					board[coorx, coory] = '#';
					board[coorx, (coory + 1)] = '#';
					board[coorx, (coory + 2)] = '#';
					board[coorx, (coory + 3)] = '#';
					board[coorx, (coory + 4)] = '#';
				}
				else
				{
					board[coorx, coory] = '#';
					board[(coorx + 1), coory] = '#';
					board[(coorx + 2), coory] = '#';
					board[(coorx + 3), coory] = '#';
					board[(coorx + 4), coory] = '#';
				}

				ship5--;
				Console.Clear();

			} while (ship5 >= 1);

			do
			{
				Player.Display_Board(board, arrx, arry);

				do
				{
					Broken = false;

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place your '# # # #' ship? (x)");
							coorx = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place your '# # # #' ship? (y)");
							coory = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("How would you like your ship placed?");
							Console.WriteLine("Top to Bottom: 1");
							Console.WriteLine("Left to Right: 2");
							veiw = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					if (!Check_Placement(board, coorx, coory, veiw, 4))
					{
						Console.WriteLine("This is invalid placement according to the Check_Placement function");
						Broken = true;
					}

					if ((coorx >= arrx) || (coorx < 0) || (coorx - 3 >= arry))
					{
						Console.WriteLine("Your length value (X) is invalid. Try again.");
						Broken = true;
					}

					if ((coory >= arry) || (coory < 0) || (coory - 3 >= arry))
					{
						Console.WriteLine("Your height value (Y) is invalid. Try again.");
						Broken = true;
					}

					if ((veiw != 1) && (veiw != 2))
					{
						Console.WriteLine("Invalid rotation");
						Broken = true;
					}

				} while (Broken);

				if (veiw == 1)
				{
					board[coorx, coory] = '#';
					board[coorx, (coory + 1)] = '#';
					board[coorx, (coory + 2)] = '#';
					board[coorx, (coory + 3)] = '#';
				}
				else
				{
					board[coorx, coory] = '#';
					board[(coorx + 1), coory] = '#';
					board[(coorx + 2), coory] = '#';
					board[(coorx + 3), coory] = '#';
				}

				ship4--;
				Console.Clear();

			} while (ship4 >= 1);

			do
			{
				Player.Display_Board(board, arrx, arry);

				do
				{
					Broken = false;

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place '# # #' ship? (x)");
							coorx = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place your '# # #' ship? (y)");
							coory = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("How would you like your ship placed?");
							Console.WriteLine("Top to Bottom: 1");
							Console.WriteLine("Left to Right: 2");
							veiw = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					if (!Check_Placement(board, coorx, coory, veiw, 3))
					{
						Console.WriteLine("This is invalid placement according to the Check_Placement function");
						Broken = true;
					}

					if ((coorx >= arrx) || (coorx < 0) || (coorx - 2 >= arry))
					{
						Console.WriteLine("Your length value (X) is invalid. Try again.");
						Broken = true;
					}

					if ((coory >= arry) || (coory < 0) || (coory - 2 >= arry))
					{
						Console.WriteLine("Your height value (Y) is invalid. Try again.");
						Broken = true;
					}

					if ((veiw != 1) && (veiw != 2))
					{
						Console.WriteLine("Invalid rotation");
						Broken = true;
					}
				} while (Broken);

				if (veiw == 1)
				{
					board[coorx, coory] = '#';
					board[coorx, (coory + 1)] = '#';
					board[coorx, (coory + 2)] = '#';
				}
				else
				{
					board[coorx, coory] = '#';
					board[(coorx + 1), coory] = '#';
					board[(coorx + 2), coory] = '#';
				}

				ship3--;
				Console.Clear();

			} while (ship3 >= 1);

			do
			{
				Player.Display_Board(board, arrx, arry);

				do
				{
					Broken = false;

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place your '# #' ship? (x)");
							coorx = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("Where do you want to place your '# #' ship? (y)");
							coory = Convert.ToInt32(Console.ReadLine()) - 1;
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					do
					{
						Broken = false;

						try
						{
							Console.WriteLine("How would you like your ship placed?");
							Console.WriteLine("Top to Bottom: 1");
							Console.WriteLine("Left to Right: 2");
							veiw = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine();
						}
						catch
						{
							Console.WriteLine("There was a problem with that input. Try again.");
							Broken = true;
						}
					} while (Broken);

					if (!Check_Placement(board, coorx, coory, veiw, 2))
					{
						Console.WriteLine("This is invalid placement according to the Check_Placement function");
						Broken = true;
					}

					if ((coorx >= arrx) || (coorx < 0) || (coorx - 1 >= arry))
					{
						Console.WriteLine("Your length value (X) is invalid. Try again.");
						Broken = true;
					}

					if ((coory >= arry) || (coory < 0) || (coory - 1 >= arry))
					{
						Console.WriteLine("Your height value (Y) is invalid. Try again.");
						Broken = true;
					}

					if ((veiw != 1) && (veiw != 2))
					{
						Console.WriteLine("Invalid rotation");
						Broken = true;
					}
				} while (Broken);

				if (veiw == 1)
				{
					board[coorx, coory] = '#';
					board[coorx, (coory + 1)] = '#';
				}
				else
				{
					board[coorx, coory] = '#';
					board[(coorx + 1), coory] = '#';
				}

				ship2--;
				Console.Clear();

			} while (ship2 >= 1);

		}

		public static bool Check_Hit(char[,] board, int x, int y)
		{
			try
			{
				if (board[x, y] == '#')
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool Check_Valid(char[,] board, int x, int y)
		{
			try
			{
				if (board[x, y] == ' ')
					return true;
				else if (board[x, y] == 'X')
					return false;
				else if (board[x, y] == 'H')
					return false;
				else if (board[x, y] == '#')
					return true;
				return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool Check_Placement(char[,] board, int x, int y, int view, int size)
		{
			try
			{
				if (view == 1)
				{
					if (board[x, y] == ' ')
					{
						if (board[x, y + 1] == ' ')
						{
							if (size >= 3)
							{
								if (board[x, y + 2] == ' ')
								{
									if (size >= 4)
									{
										if (board[x, y + 3] == ' ')
										{
											if (size == 5)
											{
												if (board[x, y + 4] == ' ')
												{
													return true;
												}
												return false;
											}
											return true;
										}
										return false;
									}
									return true;
								}
								return false;
							}
							return true;
						}
						return false;
					}
					return false;
				}

				else if (view == 2)
				{
					if (board[x, y] == ' ')
					{
						if (board[x + 1, y] == ' ')
						{
							if (size >= 3)
							{
								if (board[x + 2, y] == ' ')
								{
									if (size >= 4)
									{
										if (board[x + 3, y] == ' ')
										{
											if (size == 5)
											{
												if (board[x + 4, y] == ' ')
												{
													return true;
												}
												return false;
											}
											return true;
										}
										return false;
									}
									return true;
								}
								return false;
							}
							return true;
						}
						return false;
					}
					return false;
				}

				else
					return false;
			}
			catch
			{
				return false;
			}
		}
	}

	class AI
	{
		private static readonly Random rand = new Random();

		private static int Hitx;
		private static int Hity;
		private static bool Hit = false;
		private static int attempt = 0;

		public static void Random_Coor(out int x, out int y, int arrx, int arry)
		{
			x = rand.Next(0, (arrx - 1));
			y = rand.Next(0, (arry - 1));

		}

		public static void Random_View(out int view)
		{
			view = rand.Next(1, 3);
		}

		public static bool Ship_Placement(char[,] board, int x, int y, int view, int ship_Size)
		{
			bool valid = Board.Check_Placement(board, x, y, view, ship_Size);

			if (!valid)
				return false;

			if (view == 1)
			{
				board[x, y] = '#';
				board[x, y + 1] = '#';

				if (ship_Size >= 3)
				{
					board[x, y + 2] = '#';

					if (ship_Size >= 4)
					{
						board[x, y + 3] = '#';

						if (ship_Size == 5)
							board[x, y + 4] = '#';
					}
				}
				return true;
			}
			else
			{
				board[x, y] = '#';
				board[x + 1, y] = '#';

				if (ship_Size >= 3)
				{
					board[x + 2, y] = '#';

					if (ship_Size >= 4)
					{
						board[x + 3, y] = '#';

						if (ship_Size == 5)
							board[x + 4, y] = '#';
					}
				}
				return true;
			}
		}

		public static void AI_Setup(char[,] board, int arrx, int arry, int ship5, int ship4, int ship3, int ship2)
		{
			int x = 0, y = 0;
			int view = 0;
			int total_Ships = ship5 + ship4 + ship3 + ship2;
			bool worked = true;

			do
			{
				while (ship5 > 0)
				{
					Random_Coor(out x, out y, arrx, arry);
					Random_View(out view);
					worked = Ship_Placement(board, x, y, view, 5);
					if (worked)
						ship5--;
				}
				while (ship4 > 0)
				{
					Random_Coor(out x, out y, arrx, arry);
					Random_View(out view);
					worked = Ship_Placement(board, x, y, view, 4);
					if (worked)
						ship4--;
				}
				while (ship3 > 0)
				{
					Random_Coor(out x, out y, arrx, arry);
					Random_View(out view);
					worked = Ship_Placement(board, x, y, view, 3);
					if (worked)
						ship3--;
				}
				while (ship2 > 0)
				{
					Random_Coor(out x, out y, arrx, arry);
					Random_View(out view);
					worked = Ship_Placement(board, x, y, view, 2);
					if (worked)
						ship2--;
				}
				total_Ships = ship5 + ship4 + ship3 + ship2;
			} while (total_Ships > 0);

		}

		public static void Attack(char[,] AI_Board, char[,] Right_Board, int arrx, int arry)
		{
			bool Broken = false;
			bool valid = false;
			bool hit = false;
			int fu = 0;

			do
			{
				Broken = false;

				try
				{
					int x, y;
					if (Hit)
					{
						switch (attempt)
						{
							case 1:
								//testing to the north
								Hity++;
								valid = Board.Check_Valid(Right_Board, Hitx, Hity);
								hit = Board.Check_Hit(Right_Board, Hitx, Hity);
								if (hit && valid)
								{
									Right_Board[Hitx, Hity] = 'H';
									attempt = 1;
									return;
								}
								else if (!hit && valid)
								{
									Right_Board[Hitx, Hity] = 'X';
									Hity--;
									attempt++;
									return;
								}
								else
								{
									Hity--;
									throw new System.ArgumentException();
								}

							case 2:
								//testing to the east
								Hitx++;
								valid = Board.Check_Valid(Right_Board, Hitx, Hity);
								hit = Board.Check_Hit(Right_Board, Hitx, Hity);
								if (hit && valid)
								{
									Right_Board[Hitx, Hity] = 'H';
									attempt = 2;
									return;
								}
								else if (!hit && valid)
								{
									Right_Board[Hitx, Hity] = 'X';
									Hitx--;
									attempt++;
									return;
								}
								else
								{
									Hitx--;
									throw new System.ArgumentException();
								}
							case 3:
								//testing to the south
								Hity--;
								valid = Board.Check_Valid(Right_Board, Hitx, Hity);
								hit = Board.Check_Hit(Right_Board, Hitx, Hity);
								if (hit && valid)
								{
									Right_Board[Hitx, Hity] = 'H';
									attempt = 3;
									return;
								}
								else if (!hit && valid)
								{
									Right_Board[Hitx, Hity] = 'X';
									Hity++;
									attempt++;
									return;
								}
								else
								{
									Hity++;
									throw new System.ArgumentException();
								}
							case 4:
								//testing to the west
								Hitx--;
								valid = Board.Check_Valid(Right_Board, Hitx, Hity);
								hit = Board.Check_Hit(Right_Board, Hitx, Hity);
								if (hit && valid)
								{
									Right_Board[Hitx, Hity] = 'H';
									attempt = 4;
									return;
								}
								else if (!hit && valid)
								{
									Right_Board[Hitx, Hity] = 'X';
									Hitx++;
									attempt = 1;
									Hit = false;
									return;
								}
								else
								{
									Hitx++;
									attempt = 0;
									fu++;
									if (fu >= 2)
									{
										attempt = 5;
									}
									Console.WriteLine("FU is: " + fu + " attempt is: " + attempt);
									throw new System.ArgumentException();
								}
							default:
								Console.WriteLine("Default");
								Hit = false;
								break;
						}
					}
					Random_Coor(out x, out y, arrx, arry);

					valid = Board.Check_Valid(Right_Board, x, y);
					hit = Board.Check_Hit(Right_Board, x, y);

					if (!valid)
						Broken = true;

					if (hit && valid)
					{
						Console.WriteLine("AI Hit");
						Right_Board[x, y] = 'H';
						Hitx = x;
						Hity = y;
						Hit = true;
						attempt = 1;
					}
					else if (!hit && valid)
					{
						Console.WriteLine("AI Missed");
						Right_Board[x, y] = 'X';
					}
				}
				catch
				{
					attempt++;
					Broken = true;
				}
			} while (Broken);
		}
	}
}
