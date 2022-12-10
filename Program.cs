﻿using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("snake2", new Snake2());
            cast.AddActor("obstacles", new Obstacle());
            cast.AddActor("score", new Score());
            cast.AddActor("runner", new Runner());
            cast.AddActor("score", new Score());
            cast.AddActor("snake", new Snake());
            cast.AddActor("game over", new Actor());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("update", new Clock());
            script.AddAction("output", new DrawActorsAction(videoService));
            

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}