using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
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
}
