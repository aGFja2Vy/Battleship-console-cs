using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
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
							Repeat = false;
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
								Repeat = true;
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
						} while(Broken || Repeat);
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
}
