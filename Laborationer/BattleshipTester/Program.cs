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
            //BattleshipMain.PlaceShip(3,5);
        }

        private void TestGUI()
        {
            //Printa ut en 10x10 spelplan
            GUI.GameField();
        }
    }
}
