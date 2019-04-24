using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
	public class AI
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

		public static void AI_Setup(char[,] board, int arrx, int arry)
		{
			int Ship5 = 1;
			int Ship4 = 1;
			int Ship3 = 2;
			int Ship2 = 1;
			int x = 0, y = 0;
			int view = 0;
			bool worked = false;

			while (Ship5 > 0)
			{
				Random_Coor(out x, out y, arrx, arry);
				Random_View(out view);
				worked = Ship_Placement(board, x, y, view, 5);
				if (worked)
					Ship5--;
			}
			while (Ship4 > 0)
			{
				Random_Coor(out x, out y, arrx, arry);
				Random_View(out view);
				worked = Ship_Placement(board, x, y, view, 4);
				if (worked)
					Ship4--;
			}
			while (Ship3 > 0)
			{
				Random_Coor(out x, out y, arrx, arry);
				Random_View(out view);
				worked = Ship_Placement(board, x, y, view, 3);
				if (worked)
					Ship3--;
			}
			while (Ship2 > 0)
			{
				Random_Coor(out x, out y, arrx, arry);
				Random_View(out view);
				worked = Ship_Placement(board, x, y, view, 2);
				if (worked)
					Ship2--;
			}

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
