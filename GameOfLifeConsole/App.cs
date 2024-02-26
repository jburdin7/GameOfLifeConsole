using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class App
    {
        public void Run()
        {
            InputValidator stringInputValidator = new InputValidator(
            new[] {
                "start",
                "help",
                "close"
            });
            bool inMenu = true;

            while (inMenu)
            {
                Console.WriteLine("~Conway's Game of Life~");
                Console.WriteLine("|----Menu-----|");
                Console.WriteLine("| Start       |");
                Console.WriteLine("| About Game  |");
                Console.WriteLine("| Close       |");
                Console.WriteLine("|-------------|\r\n");

                string userInput = Console.ReadLine().ToLower();
                bool isValidUserChoice = stringInputValidator.ValidateString(userInput);
                bool isRunning = false;

                if (isValidUserChoice)
                {
                    if (userInput.Equals("start"))
                    {
                        isRunning = true;
                    }
                    else if (userInput.Equals("about game"))
                    {
                        Console.WriteLine("Explains how Conway's game of life work."); //please change this to be helpful
                    }
                    else if (userInput.Equals("close"))
                    {
                        Environment.Exit(0); //NOTES: or set 'inMenu' to 'false'
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Choice: Please select from the menu options.\r\n");
                    Thread.Sleep(1000);
                }

                Grid grid = new Grid(20);
                //TODO: Users choose dimesions of grid
                //TODO: Users choose the speed of the simulation

                while (isRunning)
                {
                    Console.Clear();
                    grid.DrawGrid();
                    grid.UpdateGrid();
                    Thread.Sleep(100);
                }
            }
        }
    }
}
