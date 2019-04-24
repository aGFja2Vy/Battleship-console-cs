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
			bool Player_Alive = true;
			bool AI_Alive = true;

			//creates the Board arrays with default values
			char[,] Right_Board = new char[Program.ArryValues[0], Program.ArryValues[1]];
			char[,] Left_Board = new char[Program.ArryValues[0], Program.ArryValues[1]];
			char[,] AI_Board = new char[Program.ArryValues[0], Program.ArryValues[1]];

			//sets all the Board arrays to spaces
			Board.Set_Board(Right_Board, Program.ArryValues[0], Program.ArryValues[1]);
			Board.Set_Board(Left_Board, Program.ArryValues[0], Program.ArryValues[1]);
			Board.Set_Board(AI_Board, Program.ArryValues[0], Program.ArryValues[1]);

			//lets them place there ships
			Board.Set_ship(Right_Board, Program.ArryValues[0], Program.ArryValues[1]);
			AI.AI_Setup(AI_Board, Program.ArryValues[0], Program.ArryValues[1]);

			//repeats until one of the players loses and runs out of ships
			do
			{
				//Console.Clear();
				Player.Attack(Left_Board, AI_Board, Right_Board, Program.ArryValues[0], Program.ArryValues[1]);
				Console.WriteLine();
				AI.Attack(AI_Board, Right_Board, Program.ArryValues[0], Program.ArryValues[1]);
				Player_Alive = Board.CheckGame(Right_Board, Program.ArryValues[0], Program.ArryValues[1]);
				AI_Alive = Board.CheckGame(AI_Board, Program.ArryValues[0], Program.ArryValues[1]);

			} while (Player_Alive && AI_Alive);

			if (!Player_Alive)
			{
				Console.Clear();
				Console.WriteLine();
				Program.CenterText("LOSER!");
				Program.CenterText("Press any key to continue...");
				Console.ReadKey();
			}
			if (!AI_Alive)
			{
				Console.Clear();
				Console.WriteLine();
				Program.CenterText("YOU WIN!");
				Program.CenterText("Press any key to continue...");
				Console.ReadKey();
			}
		}
	}
}
