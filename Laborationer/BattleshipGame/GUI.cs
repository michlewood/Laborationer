using System;

namespace BattleshipGame
{
    public class GUI
    {

        static int[] mapPositions = new int[100];
        
        public int[] MapPositions
        {
            get { return mapPositions; }
            set { mapPositions = value; }
        }

        static char[] tileType = { '#', 's', '¤' };

        public static void GameField()
        {
            Console.WriteLine("______________________");
            Console.Write("|");
            for (int i = 0; i < 100; i++)
            {
                
                Console.Write(tileType[mapPositions[i]] + " ");

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine("|");
                    if (i != 99)Console.Write("|");
                    
                }
            }

            Console.WriteLine("______________________");
        }
    }
}