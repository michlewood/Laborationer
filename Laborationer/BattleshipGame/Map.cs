using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Map
    {
        static int[] playerOneMapPositions = new int[100];
        public static int[] PlayerOneMapPositions
        {
            get { return playerOneMapPositions; }
            set { playerOneMapPositions = value; }
        }

        static int[] playerTwoMapPositions = new int[100];
        public static int[] PlayerTwoMapPositions
        {
            get { return playerTwoMapPositions; }
            set { playerTwoMapPositions = value; }
        }

        public bool AddShip(int xCoordinat, int yCoordinat, int typeOfShip)
        {
            if (typeOfShip == 0) return addsmallShip(xCoordinat, yCoordinat);

            else if (typeOfShip == 1) return addLongShip(xCoordinat, yCoordinat);

            else return addSquareShip(xCoordinat, yCoordinat);
            
        }



        private bool addSquareShip(int xCoordinat, int yCoordinat)
        {
            if (yCoordinat < 9 && xCoordinat < 9)
            {
                if (BattleshipMain.PlayerOnesTurn)
                {
                    PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 1 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 10 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 11 + 10 * yCoordinat] = 1;
                    
                }
                else
                {
                    PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 1 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 10 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 11 + 10 * yCoordinat] = 1;
                    
                }
                return true;
            }
            else return false;
        }

        internal bool HitShip(int xCoordinat, int yCoordinat)
        {
            if (BattleshipMain.PlayerOnesTurn && PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] == 1)
            {
                PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hit!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            else if (!BattleshipMain.PlayerOnesTurn && PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] == 1)
            {
                PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hit!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            else if (BattleshipMain.PlayerOnesTurn && PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] == 0)
            {
                PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Miss!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }

            else if (!BattleshipMain.PlayerOnesTurn && PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] == 0)
            {
                PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Miss!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid target");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

        }

        private bool addLongShip(int xCoordinat, int yCoordinat)
        {
            if (xCoordinat < 6)
            {
                if (BattleshipMain.PlayerOnesTurn)
                {
                    PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 1 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 2 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 3 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 4 + 10 * yCoordinat] = 1;
                }
                else
                {
                    PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 1 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 2 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 3 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 4 + 10 * yCoordinat] = 1;
                }
                return true;
            }
            else return false;
        }

        private bool addsmallShip(int xCoordinat, int yCoordinat)
        {
            if (yCoordinat < 8)
            {
                if (BattleshipMain.PlayerOnesTurn)
                {
                    PlayerOneMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 10 + 10 * yCoordinat] = 1;
                    PlayerOneMapPositions[xCoordinat + 20 + 10 * yCoordinat] = 1;
                }
                else
                {
                    PlayerTwoMapPositions[xCoordinat + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 10 + 10 * yCoordinat] = 1;
                    PlayerTwoMapPositions[xCoordinat + 20 + 10 * yCoordinat] = 1;
                }

                return true;
            }
            else return false;
        }

    }
}
