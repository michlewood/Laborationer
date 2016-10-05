using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    public class BattleshipMain
    {
        public static bool PlayerOnesTurn { get; set; }
        
        MapGUI mapGui = new MapGUI();
        Map map = new Map();

        BattleshipMain()
        {
            PlayerOnesTurn = true;
            PlaceShips();
            GameLoop();
        }

        public void PlaceShips()
        {
            string[] ships = { "smallship", "longship", "squareship" };
            int xCoordinat;
            int yCoordinat;
            int typeOfShip = 0;

            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                if (PlayerOnesTurn) Console.WriteLine("Player one ");
                else Console.WriteLine("Player two ");
                mapGui.SetUpField();
                bool correctFormat = false;
                while (!correctFormat)
                {

                    Console.WriteLine("choose position of {0}(format: x0, y0): ", ships[typeOfShip]);
                    string input = Console.ReadLine();
                    if (input.Length == 6 && input[0] == 'x' && input[4] == 'y' && int.TryParse("" + input[1], out xCoordinat)
                    && int.TryParse("" + input[5], out yCoordinat))
                    {
                        if (map.AddShip(xCoordinat, yCoordinat, typeOfShip))
                        {
                            correctFormat = true;
                            if (!PlayerOnesTurn)
                            {
                                typeOfShip++;

                            }
                            PlayerOnesTurn = !PlayerOnesTurn;
                            Console.Clear();
                            if (!PlayerOnesTurn) Console.WriteLine("Player twos turn! (Please switch player before continuing)");
                            else Console.WriteLine("Player ones turn! (Please switch player before continuing)");

                            Console.ReadLine();
                        }


                    }
                    else Console.WriteLine("\nIncorrect format!");

                }
            }
        }

        private void GameLoop()
        {
            while (true)
            {
                Console.Clear();
                if (PlayerOnesTurn) Console.WriteLine("Player one ");
                else Console.WriteLine("Player two ");

                mapGui.GameField();

                MakeGuess();

                

                if (CheckIfPlayerWon()) return;
                
                PlayerOnesTurn = !PlayerOnesTurn;

                if (!PlayerOnesTurn) Console.WriteLine("Player twos turn! (Please switch player before continuing)");
                else Console.WriteLine("Player ones turn! (Please switch player before continuing)");
                
                Console.ReadLine();
            }
        }
        
        private void MakeGuess()
        {
            int xCoordinat;
            int yCoordinat;
            bool correctFormat = false;

            while (!correctFormat)
            {
                Console.WriteLine("Choose a target(format: x0, y0): ");
                string input = Console.ReadLine();
                Console.Clear();

                if (input.Length == 6 && input[0] == 'x' && input[4] == 'y' && int.TryParse("" + input[1], out xCoordinat)
                && int.TryParse("" + input[5], out yCoordinat))
                {

                    
                    correctFormat = map.HitShip(xCoordinat, yCoordinat);
                    
                }
                else Console.WriteLine("Incorrect format!");

                mapGui.GameField();
            }

            
        }

        private bool CheckIfPlayerWon()
        {
            if (PlayerOnesTurn)
            {
                for (int i = 0; i < Map.PlayerTwoMapPositions.Length; i++)
                {
                    if (Map.PlayerTwoMapPositions[i] == 1)
                    {
                        return false;
                    }
                }
                Console.WriteLine("Player One Wins!");
            }
            else
            {
                for (int i = 0; i < Map.PlayerOneMapPositions.Length; i++)
                {
                    if (Map.PlayerOneMapPositions[i] == 1)
                    {
                        return false;
                    }
                }
                Console.WriteLine("Player Two Wins!");

            }
            Console.ReadLine();

            return true;
        } 

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            new BattleshipMain();
        }
    }
}
