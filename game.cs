using System;
using TicTacToe;

namespace Game
{
    class game
    {
        private static void play()
        {
            tictactoe ttt = new tictactoe();
            while(ttt.PlayTicTacToe())
            {
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n");
            }
        }

        public static void Main(string[] args)
        {
            string input;
            int answer;
            while(true){
                Console.WriteLine("1. New Game\n2. About the author\n3. Exit");
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out answer)){
                    switch(answer)
                    {
                        case 1:
                            play();
                            continue;
                        case 2:
                            Console.WriteLine("<Author of Fabulous tictactoe>\nName: Zhenia\nStatus: Alive\nDescription: Never gonna give you up, never gonna let you down.");
                            Console.Write("[Press Enter to return to main menu...]");
                            Console.ReadLine();
                            continue;
                        case 3:
                            Console.Write("Are you sure you want to quit? [y/n] ");
                            input = Console.ReadLine();
                            if (input == "y"){
                                return;
                            }
                            continue;
                        default:
                            break;
                    }
                }
                Console.WriteLine("Sorry, your input is invalid.");
            }
        }
    }
}