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
            //defaults for the game board and the number of ships
            int x = 11, y = 11;
            int ship5 = 1, ship4 = 1, ship2 = 1, ship3 = 2;

            //gets the gamemode choice for the switch statment
            int answer = MainMenu();

            //sets the game to match the mode they chose (1 = classic 2 = classic++ 3 = warfare 4 = warfare++)
            //Temp idea but it wont work... I think it would work if I used new classes for the different gamemodes
            switch (answer)
            {
              case 1:

                Classic.Game();

                break;

              case 2:

                ClassicAdv.Game();

                break;
            }


            //Temp ending while I debug that pauses what is going on and clears the terminal
            Console.WriteLine("Press ANY Key To Quit");
            Console.ReadKey();
            Console.Clear();
        }

        static int MainMenu()
        {
            //The choice they make gets stored as answer
            int answer;

            //this loop forces the player to pick a valid gamemode before It will move on
            while (true)
            {
                Console.WriteLine("Choose a gamemode.");
                Console.WriteLine("1: Classic (default)");
                Console.WriteLine("2: Classic++");
                Console.WriteLine("3: Warfare");
                Console.WriteLine("4: Warfare++");
                Console.WriteLine("10: Show rules and gamemode explinations.");

                answer = 1;
                answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        //returns 1 for the Clasic gamemode
                        Console.Clear();
                        Console.WriteLine("You chose Classic gamemode.");
                        return 1;

                    case 2:
                        //returns 2 for the classic++ gamemode
                        Console.Clear();
                        Console.WriteLine("You chose Classic++.");
                        return 2;

                    case 3:
                        //returns 1 for the classic gamemode until the warefare gamemode is finsihed
                        Console.Clear();
                        Console.WriteLine("You chose Warfare gamemode.");
                        Console.WriteLine("This gamemode is still under development. Defaulting to classic");
                        return 1;

                    case 4:
                        //returns 2 for the classic++ gamemode until the warfare gamemode is finsihed
                        Console.Clear();
                        Console.WriteLine("You chose Warfare++ gamemode.");
                        Console.WriteLine("This gamemode is still under development. Defaulting to classic++");
                        return 2;

                    case 10:
                        //tells the player what the options are and what the differences are
                        Console.Clear();
                        Console.WriteLine("Classic: classic BattleShip with a 10x10 board and 5 ships.");
                        Console.WriteLine("Classic++: classic BattleShip but you get to choose the number of ships and the board size.");
                        Console.WriteLine("Warfare: Battleship with abilies like peek(lets you see the oppenents board but if they catch you, you will automaticly lose the game) and the AI will try harder. ");
                        Console.WriteLine("Warfare++: warfare but you can choose the number of ships and the board size.");
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Fine don't pick one then. You are now playing Classic.");
                        return 1;
                }
            }
        }

        static void SetUp(out int x, out int y, out int ship5, out int ship4, out int ship3, out int ship2)
        {
            x = 11;
            y = 11;
            int answer_int = 0;
            ship5 = 1;
            ship4 = 1;
            ship3 = 2;
            ship2 = 1;
            bool Broken = false;

            Console.WriteLine("Would you like to change the number of ships? (Default = 1(# # # # #) 1(# # # #) 2(# # #) 1(# #)) (Y/N)");

            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if ((answer == 'Y') || (answer == 'y'))
            {
                do
                {
                    Broken = false;

                    try
                    {
                        Console.WriteLine("How many 5 long ships do you want?");
                        ship5 = Convert.ToInt32(Console.ReadLine());
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

                try {
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
                        Console.WriteLine("What is the X dimention or the length of the new board size? (anything greater then 9 and less then 100 is accepted)");
                        answer_int = Convert.ToInt32(Console.ReadLine());
                        x = answer_int + 1;
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
                        Console.WriteLine("What is the height of the new Board or the Y dimention? (anything greater then 9 and less then 100 is accepted)");
                        answer_int = Convert.ToInt32(Console.ReadLine());
                        y = answer_int + 1;
                        Console.WriteLine();

                        if ((y <= 9) || (y >= 100))
                        {
                            Console.WriteLine("Hey! that number is out of bounds.");
                            Broken = true;
                        }

                    }

                    catch
                    {
                        Console.WriteLine("Hey! that is not allowed.Try again");
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
            int x = 11, y = 11;
            int ship5 = 1, ship4 = 1, ship3 = 2, ship2 = 1;

            char[,] Right_Board = new char[x, y];
            char[,] Left_Board = new char[x, y];
            char[,] AI_Board = new char[x, y];

            Board.Set_Board(Right_Board, x, y);
            Board.Set_Board(Left_Board, x, y);
            Board.Set_Board(AI_Board, x, y);
        }

    }

    public class ClassicAdv
    {
        public static void Game()
        {
            int x = 11, y = 11;
            int ship5 = 1, ship4 = 1, ship3 = 2, ship2 = 1;
            bool Player_Alive = true;
            bool AI_Alive = true;

            char[,] Right_Board = new char[x, y];
            char[,] Left_Board = new char[x, y];
            char[,] AI_Board = new char[x, y];

            Board.Set_Board(Right_Board, x, y);
            Board.Set_Board(Left_Board, x, y);
            Board.Set_Board(AI_Board, x, y);

            Board.Set_ship(Right_Board, ship5, ship4, ship3, ship2, x, y);

            Console.Clear();
            Player.Display_Board(Left_Board, Right_Board, x, y);

            do
            {
                Console.Clear();
                Player.Display_Board(Left_Board, Right_Board, x, y);
                Player.Attack(Left_Board, AI_Board);

            } while (Player_Alive && AI_Alive);

            Player.Attack(Right_Board, AI_Board);


        }

    }

    public class Warfare
    { 
        public static void Game()
        {

        }

    }

    public class WarfareAdv
    {


    }


public class Player
    {
        public static void Display_Board(char[,] board, char[,] right_board, int arrx, int arry)
        {

			//This is the x part of the board
			for (int x = 0; x < 2; x++)
			{
				Console.Write("\t  |");

				for (int left = 1; left < arrx; left++)
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

				for (int seperator = 1; seperator < arrx; seperator++)
					Console.Write("---");
			}

            //End of top part

            //This is the y part of the board and the actual board
            Console.WriteLine();

            for (int i = 0; i < (arry - 1); i++)
            {
				if (i < 9)
					Console.Write("\t" + (i + 1) + " |  ");
				else
					Console.Write("\t" + (i + 1) + "|  ");

				for (int j = 0; j < (arrx - 1); j++)
					Console.Write(board[j, i] + "  ");

				Console.Write("\t");

				if (i < 9)
					Console.Write("\t" + (i + 1) + " |  ");
				else
					Console.Write("\t" + (i + 1) + "|  ");

				for (int j = 0; j < (arrx - 1); j++)
                    Console.Write(right_board[j, i] + "  ");

                Console.WriteLine();
            }
        }

		public static void Display_Board(char[,] board, int arrx, int arry)
		{

			//This is the x part of the board
			Console.Write("\t  |");

			for (int left = 1; left < arrx; left++)
			{
				Console.Write(left + " ");

				if (left < 10)
					Console.Write(" ");
			}

			Console.WriteLine();
			Console.Write("\t ---");

			for (int seperator = 1; seperator < arrx; seperator++)
				Console.Write("---");

			//End of top part

			//This is the y part of the board and the actual board
			Console.WriteLine();
			for (int i = 0; i < (arry - 1); i++)
			{
				if (i < 9)
					Console.Write("\t" + (i + 1) + " |  ");
				else
					Console.Write("\t" + (i + 1) + "|  ");

				for (int j = 0; j < (arrx - 1); j++)
					Console.Write(board[j, i] + "  ");

				Console.WriteLine();
			}
		}

        public static void Attack(char[,] playerboard, char[,] aiboard)
        {
            Console.WriteLine("Where would you like to shoot (X)?");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Where would you like to shoot (Y)?");
            int y = Convert.ToInt32(Console.ReadLine());

            bool hit = Board.CheckHit(aiboard, x, y);

            if (hit)
            {
                Console.WriteLine("Hit");
                aiboard[x, y] = 'H';
            }
            else
            {
                Console.WriteLine("Miss");
                playerboard[x, y] = 'X';
            }


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
                do
                {
                    Broken = false;

                    do
                    {
                        Broken = false;

                        try
                        {

                            Console.WriteLine("Where do you want to place your '# # # # #' ship? (x)");
                            coorx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Hey! That is not allowed. Try again.");
                            Broken = true;
                        }
                    }while(Broken);

                    do {
                        try
                        {
                            Console.WriteLine("Where do you want to place your '# # # # #' ship? (y)");
                            coory = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Hey! That is not allowed. Try again.");
                            Broken = true;
                        }
                }while(Broken);

                do{
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
                }while(Broken);

                    if ((coorx >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((coory >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coorx - 4) >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coory - 4) >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((veiw != 1) && (veiw != 2))
                    {
                        Console.WriteLine("Invalid rotaion");
                        Broken = true;
                    }

                }while (Broken == true);

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
				Player.Display_Board(board, arrx, arry);

			} while (ship5 >= 1);

            do
            {
                do
                {
                    Broken = false;

                    do
                    {
                        Broken = false;
                        try
                        {
                            Console.WriteLine("Where do you want to place your '# # # #' ship? (x)");
                            coorx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("There was a problem with that input. Try agian.");
                            Broken = true;
                        }
                }while(Broken);

                do
                {
                    Broken = false;
                    try
                    {
                        Console.WriteLine("Where do you want to place your '# # # #' ship? (y)");
                        coory = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

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
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

                    if ((coorx >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((coory >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coorx - 3) >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coory - 3) >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((veiw != 1) && (veiw != 2))
                    {
                        Console.WriteLine("Invalid rotaion");
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
				Player.Display_Board(board, arrx, arry);

			} while (ship4 >= 1);

            do
            {
                do
                {
                    Broken = false;

                    do
                    {
                        Broken = false;

                        try
                        {
                            Console.WriteLine("Where do you want to place '# # #' ship? (x)");
                            coorx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("There was a problem with that input. Try agian.");
                            Broken = true;
                        }
                }while(Broken);

                do
                {
                    Broken = false;
                    try{
                        Console.WriteLine("Where do you want to place your '# # #' ship? (y)");
                        coory = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

                do
                {
                    Broken = false;
                    try{
                        Console.WriteLine("How would you like your ship placed?");
                        Console.WriteLine("Top to Bottom: 1");
                        Console.WriteLine("Left to Right: 2");
                        veiw = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

                    if ((coorx >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((coory >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coorx - 2) >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coory - 2) >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((veiw != 1) && (veiw != 2))
                    {
                        Console.WriteLine("Invalid rotaion");
                        Broken = true;
                    }

                } while (Broken == true);

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
				Player.Display_Board(board, arrx, arry);

			} while (ship3 >= 1);

            do
            {
                do
                {
                    Broken = false;

                    do
                    {
                        Broken = false;
                        try
                        {
                            Console.WriteLine("Where do you want to place your '# #' ship? (x)");
                            coorx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("There was a problem with that input. Try agian.");
                            Broken = true;
                        }
                }while(Broken);

                do
                {
                    Broken = false;

                    try
                    {
                        Console.WriteLine("Where do you want to place your '# #' ship? (y)");
                        coory = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

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
                        Console.WriteLine("There was a problem with that input. Try agian.");
                        Broken = true;
                    }
                }while(Broken);

                    if ((coorx >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((coory >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coorx - 1) >= (arrx - 1)) || (coorx < 1))
                    {
                        Console.WriteLine("Your length value (X) is invalid. Try again.");
                        Broken = true;
                    }

                    if (((coory - 1) >= (arry - 1)) || (coory < 1))
                    {
                        Console.WriteLine("Your height value (Y) is invalid. Try again.");
                        Broken = true;
                    }

                    if ((veiw != 1) && (veiw != 2))
                    {
                        Console.WriteLine("Invalid rotaion. Try again.");
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
				Player.Display_Board(board, arrx, arry);

			}while (ship2 >= 1);

        }

        public static bool CheckHit(char[,] board, int x, int y)
        {
            if (board[x, y] == '#')
                return true;

            return false;
        }
    }
}
