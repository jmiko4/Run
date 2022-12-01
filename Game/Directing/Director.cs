using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        Scoreboard points = new Scoreboard();

        Clock clock = new Clock();


        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {   
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = _keyboardService.GetDirection();
            robot.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor timer = cast.GetFirstActor("timer");
            Actor robot = cast.GetFirstActor("robot");
            Actor instructions = cast.GetFirstActor("instructions");
            List<Actor> gems = cast.GetActors("gems");
            List<Actor> rocks = cast.GetActors("rocks");
            // instructions.SetText("Get 25 Points to win");
            clock.Tick();
            if (points.GetPoints() >= 25){
                banner.SetText("You Win!!!");
                return;
            }
            else{banner.SetText(points.GetPoints().ToString());}
            timer.SetText(clock.GetTimer());
            if (clock.GetTimer() == "Game Over"){
                return;
            }
            
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor actor in gems)
            {
                
                Point direction = new Point(0,1);
                direction = direction.Scale(15);
                actor.SetVelocity(direction);
                actor.MoveNext(maxX, maxY);
                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    cast.RemoveActor("gems", actor);
                    points.AddPoint();
                    // banner.SetText(points.GetPoints().ToString());
                    // Console.WriteLine("Thing");

                }


            }
            
            foreach (Actor actor in rocks)
            {
                
                Point direction = new Point(0,1);
                direction = direction.Scale(15);
                actor.SetVelocity(direction);
                actor.MoveNext(maxX, maxY);
                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    cast.RemoveActor("rocks", actor);
                    points.RemovePoint();
                    // banner.SetText(points.GetPoints().ToString());
                    // Console.WriteLine("Thing");

                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}