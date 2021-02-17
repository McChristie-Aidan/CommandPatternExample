using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace AidanCommandPattern
{
    class CommandExample
    {
        Vector2 playerPos = new Vector2(0, 0);
        Stack<Vector2> previousMoves = new Stack<Vector2>();

        public CommandExample()
        {
            Console.WriteLine("use w, a, s, and d to move");
            Console.WriteLine("use l to see all the stored moventes");
            Console.WriteLine("use u to undo moves \n");

            while (true)
            {
                Console.WriteLine("Player position: " + playerPos);

                CheckInput();
            }
        }

        void CheckInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "w":
                    StoreCurrentPos();
                    playerPos.Y++;
                    break;
                case "s":
                    StoreCurrentPos();
                    playerPos.Y--;
                    break;
                case "d":
                    StoreCurrentPos();
                    playerPos.X++;
                    break;
                case "a":
                    StoreCurrentPos();
                    playerPos.X--;
                    break;
                case "l":
                    ListPreviousMoves();
                    break;
                case "u":
                    UndoMove();
                    break;
                default:
                    Console.WriteLine("Unrecognized command. Try again.");
                    CheckInput();
                    break;
            }
        }

        void StoreCurrentPos()
        {
            previousMoves.Push(playerPos);
        }
        void ListPreviousMoves()
        {
            foreach(Vector2 v in previousMoves)
            {
                Console.WriteLine("Previous position:" + v);
            }
        }
        void UndoMove()
        {
            if (previousMoves.Count == 0)
            {
                Console.WriteLine("Cannot undo. No previous moves \n");
            }
            else
            {
                playerPos = previousMoves.Pop();
            }
        }
    }
}
