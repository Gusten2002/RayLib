using System;
using Raylib_cs;

namespace RayLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Hello TE!");

            Color myColor = new Color(0, 255, 128, 255);

            Random generator = new Random();

            float x = 400;
            float y = 300;

            float fruitX = 50;
            float fruitY = 50;
            bool oneFruit = false;

            Rectangle fruit = new Rectangle((int)fruitX, (int)fruitY, 15, 15);
            Rectangle player = new Rectangle((int)x, (int)y, 20, 20);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.DrawRectangleRec(fruit, Color.RED);
                Raylib.DrawRectangleRec(player, Color.SKYBLUE);

                while (oneFruit == false || fruit.y >= 595 || fruit.x >= 795 || fruit.x <= 5 || fruit.y <= 5)//Checks if the fruit is in the visable area, if not, try again.
                {
                    fruit.x = generator.Next(5, 795);
                    fruit.y = generator.Next(5, 595);
                    oneFruit = true;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) //Moves "player" right
                {
                    player.x += 0.07f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) //Moves "player" left
                {
                    player.x -= 0.07f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) //Moves "player" up
                {
                    player.y -= 0.07f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) //Moves "player" downwards
                {
                    player.y += 0.07f;
                }

                Raylib.BeginDrawing(); //Börjar rita

                Raylib.ClearBackground(myColor); //Backgroundcolor

                // Raylib.DrawRectangle((int)fruitX, (int)fruitY, 15, 15, Color.RED); //Fruit

                // Raylib.DrawRectangle((int)x, (int)y, 20, 20, Color.PINK); //Player

                if (player.x >= 791) //Checks player position Right side, tp to back to Left side(portal)
                {
                    player.x = -10;
                }
                if (player.x <= -11) //Checks player position Left side, tp to back to Right side(portal)
                {
                    player.x = 790;
                }
                if (player.y >= 591) //Checks player position Right side, tp to back to Left side(portal)
                {
                    player.y = -10;
                }
                if (player.y <= -11) //Checks player position Left side, tp to back to Right side(portal)
                {
                    player.y = 590;
                }

                bool isOverlapping = Raylib.CheckCollisionRecs(player, fruit);

                if (isOverlapping == true)
                {
                    oneFruit = false;
                    while (oneFruit == false && fruit.y >= 595 && fruit.x >= 795 && fruit.x <= 5 && fruit.y <= 5)//Checks if the fruit is in the visable area, if not, try again.
                    {
                        fruitX = generator.Next(5, 795);
                        fruitY = generator.Next(5, 595);
                        oneFruit = true;
                    }
                    isOverlapping = false;
                }

                Raylib.EndDrawing();
            }

        }
    }
}
