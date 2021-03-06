using System;
using Model;

namespace ChessConsoleApp {
    
    // a class that checks for all of the commands and runs them
    //It also has all the command functions
    //Note all strings should be stored in a config file
    //That will come in a future update

    public class commands {

        virtual public bool checkCommands(BasePiece [,] currentBoard, string command) {

            if (command.Equals("current board")) {
                currentBoard.ToConsole();
                return true;
            }

            if (command.Equals("help")) {
                helpMsg();
                return true;
            }

            if (command.Equals("exit")) {
                Environment.Exit(1);
                return true;
            }

            return false;
        }

        //all commands that it can do at the start of the game
        //current boards would crash it
        public void startCommands(string command) {
            if (command.Equals("help")) {
                helpMsg();
            }
            if (command.Equals("exit")) {
                Environment.Exit(1);
            } 
        }
        public void helpMsg() {
            Console.WriteLine("Welcome to Help:");
            Console.WriteLine("help: A List of All The Commands and Their Function");
            Console.WriteLine("current board: displays the current board");
            Console.WriteLine("exit: closes the app");
            Console.WriteLine("Option Number: moves the piece as shown in the image \n");
            Console.WriteLine("Enter Anything To Leave");

            Console.ReadLine();
        }

        //should be moved from commands to its own file
        //will done later
        public int createPlayers(Game game) {
            
            string color = Console.ReadLine();

            Console.WriteLine("Please Provide The Number Of Human Players That Are Playing: ");
            int numOfPlayers = playerIntChecker();

            if (numOfPlayers.Equals(1)) {
                if (color.Equals("white") ) {
                    game.Players.Enqueue(new humanPlayer() { Name = "player1", Color = Color.White });
                    game.Players.Enqueue(new BasePlayer(){ Name = "player2", Color = Color.Black });
                    return 1;
                } 
                if (color.Equals("black")) {
                    game.Players.Enqueue(new BasePlayer() { Name = "player1", Color = Color.White  });
                    game.Players.Enqueue(new humanPlayer(){ Name = "player2", Color = Color.Black }); 
                    return 1;
                } 
            }
            else {
                game.Players.Enqueue(new humanPlayer() { Name = "player1", Color = Color.White  });
                game.Players.Enqueue(new humanPlayer(){ Name = "player2", Color = Color.Black });
                return 1;
            }
           
            
            Console.WriteLine("Invalid Color: Please Provide A Valid Color ");
            return createPlayers(game); 

        }

        public int playerIntChecker() {
            
            int inputAsInt;
            String input = Console.ReadLine();
            
            //error handling
            if (Int32.TryParse(input, out inputAsInt)) {
                if (inputAsInt.Equals(1) | inputAsInt.Equals(2)) {
                    return inputAsInt; 
                }
            }

            Console.WriteLine("Please Provide A Either 1 or 2 For The Number of Players: ");
            
            return playerIntChecker();
        }

    }
}