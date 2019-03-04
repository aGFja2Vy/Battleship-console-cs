using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public class Player
	{
		public static char[,] Right_Board = new char[16, 16];
		public static char[,] Left_Board = new char[16, 16];

		public static void Display_Board(char[,] board, char[,] right_board)
		{

			string s = "\t  |  01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 \t  |  01 02 03 04 05 06 07 08 09 10 11 12 13 14 15";
			string s2 = "\t--|-----------------------------------------------\t--|-----------------------------------------------";

			Console.WriteLine(s);
			Console.WriteLine(s2);

			//Lines 1-9 because 2 digit numbers messup the pattern
			for (int x = 0; x < 15; x++)
			{
				if (x < 9)
					Console.Write("\t" + (x + 1) + " |  ");
				else
					Console.Write("\t" + (x + 1) + "|  ");

				for (int y = 0; y < 15; y++)
				{
					Console.Write(board[x, y] + "  ");
				}

				Console.Write("\t");

				if (x < 9)
					Console.Write((x + 1) + " |  ");
				else
					Console.Write((x + 1) + "|  ");

				for (int y = 0; y < 15; y++)
				{
					Console.Write(right_board[x, y] + "  ");
				}

				Console.WriteLine();
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			int direction = 0;
			int turn_counter = 0;
			string[] ships = new string[5] {"#####","####","####","###","##" };

			Board.Set_Board(Player.Right_Board);
			Board.Set_Board(Player.Left_Board);
			Board.Set_Board(AI.board);

			Player.Display_Board(Player.Left_Board, Player.Right_Board);

			Console.WriteLine("Press ANY Key To Quit");
			Console.ReadKey();
			Console.Clear();
		}
	}

	class Board
	{
		public static void Set_Board(char[,] board)
		{
			for (int x = 0; x < 15; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					board[x, y] = ' ';
				}
			}
		}

		public static void Set_ship(char[,] board, int ships, int x2, int y2)
		{
			bool Broken = false;
			int veiw = 0;
			do
			{
				Console.WriteLine("Where do you want to place your ship (" + ships[);
				x2 = Console.Read();

				Console.WriteLine("Where do you want to place your ship on the coordante plane? (y)");
				y2 = Console.Read();

				Console.WriteLine("How wouldd you like your ship placed?");
				Console.WriteLine("Top to Bottom: 1");
				Console.WriteLine("Right to Left: 2");
				veiw = Console.Read();

				if ((x2 >= 15) || (x2 < 1))
					Broken = true;
				if ((y2 >= 15) || (y2 < 1))
					Broken = true;
				if ((veiw != 1) || (veiw != 2))
					Broken = true;

			} while (Broken);



		}
	}

	class AI
	{
		public static char[,] board = new char[16, 16];
		public int x = 0;
		public int y = 0;
	}
}


