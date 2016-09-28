using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipGame;

namespace BattleshipTester
{
    class Program
    {
        BattleshipMain bm = new BattleshipMain();
        MapGUI gui = new MapGUI();
        Program()
        {
            
            TestGUI();
            TestPlaceraUtSkepp();
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            new Program();
        }

        private void TestPlaceraUtSkepp()
        {
            //placera ett skepp på plats x3 y5
            bm.PlaceShip(3,5);

            TestGUI();
        }

        private void TestGUI()
        {
            //Printa ut en 10x10 spelplan
            gui.GameField();
        }
    }
}
