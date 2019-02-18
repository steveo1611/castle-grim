using System;
using CastleGrimtol.Project;
//using static CastleGrimtol.Project.Story;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
           Game game = new Game();
            game.GameOn = false;
            game.Setup();
            game.Help();
            Console.WriteLine("Enter 'start' to begin the adventure or 'quit' to end game");
            string gameStart = Console.ReadLine();
            if (gameStart != null && gameStart.ToLower() == "start")
            {
                Console.Clear();
               Player player = new Player();
                game.CurrentPlayer = player;
                Console.WriteLine($" \r\n Howdy {player.Name} \r\n Welcome to the game...now let's get started:\n                ");
                Console.WriteLine("After picking yourself up from the landing after you fell into the oversized rabbit hole \r\n  ");
                Console.WriteLine(game.CurrentRoom.Description);
                game.GameOn = true;
            }
            else if (gameStart != null && gameStart.ToLower() == "quit")
            {
                return;
            }
            else
            {
            Console.Clear();
               
            Console.WriteLine("Please select 'start' when you are ready to begin game");
            }


            while (game.GameOn)
                {
             //   Console.WriteLine(game.CurrentRoom.Description);
                string userCommand = game.GetInput().ToLower();
                string[] userSelection = userCommand.Split(" ");
                Room nextRoom;

                game.CurrentRoom.exits.TryGetValue(userSelection[0], out nextRoom );

                if (userSelection[0] == "g" || userSelection[0] == "go")
                {
                    game.MoveRoom(userSelection[1]);
                    Console.WriteLine(game.CurrentRoom.Description);
                }

                else if (userSelection[0] == "l" || userSelection[0] == "look")
                {
                    game.Look(game.CurrentRoom);
                }
                else if ((userSelection[0] == "t" || userSelection[0] == "take") && userSelection.Length > 1 && userSelection[1] != null)
                    {
                    game.TakeItem(userSelection[1]);
                    }

                else if ((userSelection[0] == "u" || userSelection[0] == "use" ) && userSelection.Length > 1 && userSelection[1] != null) 
                    {
                    game.UseItem(userSelection[1]);
                    }
                else if (userSelection[0] == "i" || userSelection[0] == "inventory")
                    {
                    game.CurrentPlayer.ListInventory(game.CurrentPlayer);
                    }
                else if (userSelection[0] == "h" || userSelection[0] == "help")
                    {
                    game.Help();
                    }
                else if (userSelection[0] =="reset")
                {
                    game.Reset();
                }
                else if (userSelection[0] == "q" || userSelection[0] == "quit")
                    {
                    game.Quit();
                    }   
                else if (nextRoom != null)
                    {
                    game.CurrentRoom = nextRoom;
                    game.Look(game.CurrentRoom);
                     }
                else
                    {
                //game.Look(game.CurrentRoom);
                Console.Clear();
                Console.Write(" Uh ok that didn't work, want to try something else?...\n");
                    }
            }
            }
        }
    }

