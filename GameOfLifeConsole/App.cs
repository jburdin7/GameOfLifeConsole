using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class App
    {
        public void Run()
        {
            InputValidator InputValidator = new InputValidator();
            bool isRunning = true;
            int speed = 500;
            int gridSize = 0;

            while (isRunning)
            {
                bool hasInvalidMenuInput = true;

                while(hasInvalidMenuInput)
                {
                    Console.WriteLine("~Conway's Game of Life~");
                    Console.WriteLine("|----Menu-----|");
                    Console.WriteLine("| Start       |");
                    Console.WriteLine("| Close       |");
                    Console.WriteLine("|-------------|\r\n");

                    string userMenuChoice = Console.ReadLine().ToLower();
                    bool isValidUserChoice = InputValidator.ValidateString(userMenuChoice, new[] { "start", "close" });

                    if (isValidUserChoice)
                    {
                        if (userMenuChoice.Equals("start"))
                        {
                            isRunning = true;
                        }
                        else if (userMenuChoice.Equals("close"))
                        {
                            Environment.Exit(0); //NOTES: or set 'inMenu' to 'false'
                        }
                        hasInvalidMenuInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice: Please select from the menu options.\r\n");
                        Thread.Sleep(1000);
                    }
                }

                bool hasInvalidSpeed = true;

                while(hasInvalidSpeed)
                {
                    Console.WriteLine("How fast would you like the simulation to be?");
                    Console.WriteLine("Slow");
                    Console.WriteLine("Normal");
                    Console.WriteLine("Fast");

                    string userSpeedChoice = Console.ReadLine().ToLower();
                    bool isValidUserChoice = InputValidator.ValidateString(userSpeedChoice, new[] { "slow", "normal", "fast" });

                    if (isValidUserChoice)
                    {
                        hasInvalidSpeed = false;
                        if (userSpeedChoice.Equals("slow"))
                        {
                            speed = 1000;
                        }
                        else if (userSpeedChoice.Equals("fast"))
                        {
                            speed = 100;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Choice: Please select a speed.\r\n");
                        Thread.Sleep(1000);
                    }
                }

                bool hasInvalidGridSize = true;
                while(hasInvalidGridSize)
                {
                    Console.WriteLine("How big would you like the grid?\r\n");
                    string userGridChoice = Console.ReadLine();
                    bool isValidUserChoice = InputValidator.ValidateNumber(userGridChoice, ref gridSize);

                    if (!isValidUserChoice)
                    {
                        Console.WriteLine("Invalid Input: Please input a number.\r\n");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        hasInvalidGridSize = false;
                    }
                }
                
                Grid grid = new Grid(gridSize);

                while (isRunning)
                {
                    Console.Clear();
                    grid.DrawGrid();
                    grid.UpdateGrid();
                    Thread.Sleep(speed);
                }
            }
        }
    }
}
