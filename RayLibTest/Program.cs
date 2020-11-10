using System;
using Raylib_cs;
using System.Collections.Generic;

namespace RayLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Snake");

            Color myColor = new Color(0, 255, 128, 255);

            Random generator = new Random();

            Queue<Rectangle> playerQueue = new Queue<Rectangle>();

            float x = 400;
            float y = 300;

            float fruitX = 50;
            float fruitY = 50;
            bool oneFruit = false;

            Rectangle fruit = new Rectangle((int)fruitX, (int)fruitY, 15, 15);
            Rectangle playerHead = new Rectangle((int)x, (int)y, 20, 20);

            playerQueue.Enqueue(playerHead);

            int moveTimer = 0; //Start number for the timer
            int moveTimerMax = 7; //Max number for the timer.

            Raylib.SetTargetFPS(60); //Locks the FPS to 60

            while (!Raylib.WindowShouldClose())
            {
                Raylib.DrawRectangleRec(fruit, Color.RED); //Draws a red ractangle fruit
                foreach (Rectangle rect in playerQueue) //Draws every rectangle that the snake consists of
                {
                    Raylib.DrawRectangleRec(rect, Color.SKYBLUE);
                    Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.BLACK);
                }

                while (oneFruit == false || fruit.y >= 595 || fruit.x >= 795 || fruit.x <= 5 || fruit.y <= 5)//Checks if the fruit is in the visable area, if not, try again.
                {
                    fruit.x = generator.Next(5, 795);
                    fruit.y = generator.Next(5, 595);
                    oneFruit = true;
                }

                moveTimer -= 1; //Timer goes back with -1

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && moveTimer < 0) //Moves "player" right
                {
                    x += 20;
                    // player.x += 0.07f;
                    Rectangle popper = playerQueue.Dequeue();
                    popper.x = x;
                    popper.y = y;

                    playerQueue.Enqueue(popper);
                    playerHead = popper;
                    moveTimer = moveTimerMax;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && moveTimer < 0) //Moves "player" left
                {
                    x -= 20;
                    // player.x -= 0.07f;
                    Rectangle popper = playerQueue.Dequeue();
                    popper.x = x;
                    popper.y = y;

                    playerHead = popper;
                    playerQueue.Enqueue(popper);
                    moveTimer = moveTimerMax;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && moveTimer < 0) //Moves "player" up
                {
                    y -= 20;
                    // player.y -= 0.07f;
                    Rectangle popper = playerQueue.Dequeue();
                    popper.x = x;
                    popper.y = y;

                    playerHead = popper;
                    playerQueue.Enqueue(popper);
                    moveTimer = moveTimerMax;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && moveTimer < 0) //Moves "player" downwards
                {
                    y += 20;
                    // player.y += 0.07f;
                    Rectangle popper = playerQueue.Dequeue();
                    popper.x = x;
                    popper.y = y;

                    playerHead = popper;
                    playerQueue.Enqueue(popper);
                    moveTimer = moveTimerMax;
                }

                Raylib.BeginDrawing(); //Starts drawing

                Raylib.ClearBackground(myColor); //Backgroundcolor

                if (x >= 791) //Checks player position Right side, tp to back to Left side(portal)
                {
                    x = -10;
                }
                if (x <= -11) //Checks player position Left side, tp to back to Right side(portal)
                {
                    x = 790;
                }
                if (y >= 591) //Checks player position Right side, tp to back to Left side(portal)
                {
                    y = -15;
                }
                if (y <= -16) //Checks player position Left side, tp to back to Right side(portal)
                {
                    y = 590;
                }

                bool isOverlapping = Raylib.CheckCollisionRecs(playerHead, fruit);


                if (isOverlapping == true)
                {
                    // System.Console.WriteLine("OVERLAP!!!");
                    oneFruit = false;
                    while (oneFruit == false && fruit.y >= 595 && fruit.x >= 795 && fruit.x <= 5 && fruit.y <= 5)//Checks if the fruit is in the visable area, if not, try again.
                    {
                        fruitX = generator.Next(5, 795);
                        fruitY = generator.Next(5, 595);
                        oneFruit = true;
                    }

                    playerQueue.Enqueue(new Rectangle(x, y, 20, 20));
                    isOverlapping = false;
                }

                bool isColliding = false;

                foreach (Rectangle rect in playerQueue)
                {
                    if (rect.x != playerHead.x && rect.y != playerHead.y && !isColliding)
                    {
                        isColliding = Raylib.CheckCollisionRecs(playerHead, rect);

                    }
                }

                if (isColliding == true)
                {
                    Environment.Exit(0);
                }
                Raylib.EndDrawing();
            }

        }
    }
}
