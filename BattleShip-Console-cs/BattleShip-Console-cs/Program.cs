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

            int x, y;
            int ship5, ship4, ship3, ship2;

            SetUp(out x, out y, out ship5, out ship4, out ship3, out ship2);

            char[,] Right_Board = new char[x, y];
            char[,] Left_Board = new char[x, y];
            char[,] AI_Board = new char[x, y];

            Board.Set_Board(Right_Board, x, y);
            Board.Set_Board(Left_Board, x, y);
            Board.Set_Board(AI_Board, x, y);

            Board.Set_ship(Right_Board, ship5, ship4, ship3, ship2, x, y);

            Console.Clear();
            Player.Display_Board(Left_Board, Right_Board, x, y);

            Console.WriteLine("Press ANY Key To Quit");
            Console.ReadKey();
            Console.Clear();
        }

        static void SetUp(out int x, out int y, out int ship5, out int ship4, out int ship3, out int ship2)
        {
            x = 16;
            y = 16;
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

                }while(Broken);

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
                }while(Broken);

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
                }while(Broken);

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
                }while(Broken);
            }

            do
            {
                Broken = false;

                try{
                    Console.WriteLine("Would you like to change the default board size? (Default = 15x15) (Y/N)");
                    answer = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Hey! That is not allowed. Try again.");
                    Broken = true;
                }
            }while(Broken);

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

			} while (ship2 >= 1);
        }
    }
}
