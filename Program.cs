using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "GREED";
        // private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_GEMS = 40;
        private static int DEFAULT_ROCKS = 20;
        // private static int POINTS;



        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(25);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(25, 25));
            cast.AddActor("banner", banner);
            //create timer
            Actor timer = new Actor();
            timer.SetText("");
            timer.SetFontSize(25);
            timer.SetColor(WHITE);
            timer.SetPosition(new Point(750,25));
            cast.AddActor("timer", timer);
            //create instructions
            Actor instructions = new Actor();
            instructions.SetText("Get 25 points within 60 seconds to win");
            instructions.SetFontSize(20);
            instructions.SetColor(WHITE);
            instructions.SetPosition(new Point(250,25));
            cast.AddActor("instructions", instructions);

            // create the robot
            Actor robot = new Actor();
            robot.SetText("#");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, 585));
            cast.AddActor("robot", robot);


            // create the gems
            Random random = new Random();
            for (int i = 0; i < DEFAULT_GEMS; i++)
            {
                string text = ("$");
                

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 255;
                int g = 255;
                int b = 0;
                Color color = new Color(r, g, b);

                Gem gem = new Gem();
                gem.SetText(text);
                gem.SetFontSize(FONT_SIZE);
                gem.SetColor(color);
                gem.SetPosition(position);
                cast.AddActor("gems", gem);
            }
            for (int i = 0; i < DEFAULT_ROCKS; i++)
            {
                string text = ("0");
                

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 111;
                int g = 78;
                int b = 55;
                Color color = new Color(r, g, b);

                Rock rock = new Rock();
                rock.SetText(text);
                rock.SetFontSize(FONT_SIZE);
                rock.SetColor(color);
                rock.SetPosition(position);
                
                cast.AddActor("rocks", rock);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}