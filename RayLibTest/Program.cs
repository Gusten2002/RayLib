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

            while(!Raylib.WindowShouldClose())
            {
                while(oneFruit == false || fruitY >= 570 || fruitX >= 770 || fruitX <= 30 || fruitY <= 30)
                {
                    fruitX = generator.Next(30, 770);
                    fruitY = generator.Next(30, 570);
                    oneFruit = true;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    x += 0.1f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    x -= 0.1f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    y -= 0.1f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    y += 0.1f;
                }

                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                Raylib.DrawCircle((int)fruitX, (int)fruitY, 9, Color.RED);

                Raylib.DrawRectangle((int)x, (int)y, 20, 20, Color.PINK);

                if(x >= 791)
                {
                    x = -10;
                }
                if(x <= -11)
                {
                    x = 790;
                }
                if(y >=  591)
                {
                    y = -10;
                }
                if(y <= -11)
                {
                    y = 590;
                }

                Raylib.EndDrawing();
            }

        }
    }
}
