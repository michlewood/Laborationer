using System;

namespace BattleshipGame
{
    public class MapGUI
    {

        string[] tileType = { "#", "#", "¤", "X" };
        string[] tileTypeSetUp = { "#", "s"};

        internal void SetUpField()
        {
            int yValue = 0;
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 x");
            Console.Write(yValue + " ");

            for (int i = 0; i < 100; i++)
            {

                if (!BattleshipMain.PlayerOnesTurn) Console.Write(tileTypeSetUp[Map.PlayerTwoMapPositions[i]] + " ");
                else Console.Write(tileTypeSetUp[Map.PlayerOneMapPositions[i]] + " ");

                if ((i + 1) % 10 == 0 && i != 99)
                {
                    Console.WriteLine();
                    yValue += 1;
                    Console.Write(yValue + " ");
                }
                if (i == 99)
                {
                    Console.WriteLine();
                    Console.WriteLine("y");
                }

            }
        }

        public void GameField()
        {
            int yValue = 0;
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 x");
            Console.Write(yValue + " ");

            for (int i = 0; i < 100; i++)
            {
                
                if (BattleshipMain.PlayerOnesTurn) Console.Write(tileType[Map.PlayerTwoMapPositions[i]] + " ");
                else Console.Write(tileType[Map.PlayerOneMapPositions[i]] + " ");

                if ((i + 1) % 10 == 0 && i != 99)
                {
                    Console.WriteLine();
                    yValue += 1;
                    Console.Write(yValue + " ");
                }
                if (i == 99)
                {
                    Console.WriteLine();
                    Console.WriteLine("y");
                }   
                
            }
        }
        
    }
}