using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            int xAI = 0;
            int yAI = 0;
            int direction = 0;
            int turn_counter = 0;
            int[] ships = new int[5] {5,4,4,3,2};
            char[,] Right_Board = new char[16,16];
            char[,] Left_Board = new char[16,16];
            char[,] AI_board = new char[16,16];

            Set_Board(Right_Board);
            Set_Board(Left_Board);
            Set_Board(AI_board);

            Display_Board(Left_Board, Right_Board);

            Console.WriteLine("Press ANY Key To Quit");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Set_Board(char[,] board)
        {
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    board[x,y] = ' ';
                }
            }
        }

        private static void Display_Board(char[,] board, char[,] right_board)
        {
            
            string s = "\t  |  01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 \t  |  01 02 03 04 05 06 07 08 09 10 11 12 13 14 15";
            string s2 = "\t--|-----------------------------------------------\t--|-----------------------------------------------";

            Console.WriteLine(s);
            Console.WriteLine(s2);

            //Lines 1-9 because 2 digit numbers messup the pattern
            for(int x = 0; x < 15; x++)
            {
                if(x < 9)
                Console.Write("\t" + (x + 1) + " |  ");
                else
                Console.Write("\t" + (x + 1) + "|  ");

                for(int y = 0; y < 15; y++)
                {
                    Console.Write(board[x,y] + "  ");
                }

                Console.Write("\t");

                if(x < 9)
                Console.Write((x + 1) + " |  ");
                else
                Console.Write((x + 1) + "|  ");

                for(int y = 0; y < 15; y++)
                {
                    Console.Write(right_board[x,y] + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}

