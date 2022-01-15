using System;

namespace TicTacToe
{
    class tictactoe
    {
        private int[] score = {0, 0};   
        public bool PlayTicTacToe(){
            int i = 0;

            int pos, moves_made = 0;

            string outcome;

            const char[] whose_move = {'O', 'X'};

            char[] board = new char[9];
            for(i=0;i<9;i++)
            {
                board[i]=' ';
            }

            while (true)
            {
                moves_made++;
                print_board(board);
                while (true)
                {   
                    Console.Write("\n{0} -> ", whose_move[moves_made%2]);
                    if (int.TryParse(Console.ReadLine(), out pos))
                    {
                        if ((pos >= 1) && (pos <= 9))
                        {
                            pos--;
                            if (board[pos] == ' '){
                                board[pos] = whose_move[moves_made%2];
                                break;
                            }
                        }   
                    }
                    Console.WriteLine("You specified an illegal Move! Please try again.");
                }
                if (check_victory(board))
                {
                    score[moves_made%2]++;
                    outcome = whose_move[moves_made%2] + " Won!";
                    break;
                }
                else if(moves_made >= 9){
                    outcome = "Draw";
                    break;
                }
            }
            Console.WriteLine("Game Over\n");
            Console.WriteLine("Game outcome: {0}!", outcome);
            Console.WriteLine("Final Score\n'X' : 'O'\n {0}  :  {1}\n", score[1], score[0]);
            print_board(board);
            Console.Write("\n[Type y to keep playing or press Enter return to main menu...]");
            if(Console.ReadLine() == "y")
            { 
                return true;
            }
            else
            {  
                return false;
            }
                 
        }
        private void print_board(char[] board)
        {
            for(int i=0;i<9;i++)
            {
                if (i == 8)
                {
                    Console.Write(" {0} ", board[i]);
                }
                else if(i%3 == 2)
                {
                    Console.WriteLine(" {0} ", board[i]);
                    Console.WriteLine("---+---+---");
                }
                else
                {
                    Console.Write(" {0} |", board[i]);
                }
            }
        }

        private bool check_horizontal(char[] board)
        {
            for(int row=0;row<3;row++)
            {
                if ((board[3*row]!=' ')&&(board[3*row]==board[3*row+1])&&(board[3*row]==board[3*row+2]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool check_vertical(char[] board)
        {
            for(int col=0;col<3;col++)
            {
                if ((board[col]!=' ')&&(board[col]==board[3+col])&&(board[col]==board[6+col]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool check_diagonal(char[] board)
        {
            return (board[4]!=' ')&&(((board[0]==board[4])&&(board[0]==board[8])) || ((board[2]==board[4])&&(board[2]==board[6])));
        }
        private bool check_victory(char[] board)
        {
            return check_horizontal(board) || check_vertical(board) || check_diagonal(board);
        }
    }
}