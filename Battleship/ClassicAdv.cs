using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
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
}
