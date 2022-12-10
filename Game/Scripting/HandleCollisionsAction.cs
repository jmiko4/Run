using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private int winner;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                // HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
            }
        }

        private void HandleSegmentCollisions(Cast cast)
        {
            Point position = new Point(90, 285);
            Obstacle obstacle = (Obstacle)cast.GetFirstActor("obstacles");
            List<Actor> obstacles = obstacle.GetBody();
            Actor head = obstacle.GetHead();
            Runner runner = (Runner)cast.GetFirstActor("runner");
            Score score = (Score)cast.GetFirstActor("score");
            Actor game_over = (Actor)cast.GetFirstActor("game over");

            if (runner.GetPosition().Equals(head.GetPosition()))
                {
                    Console.WriteLine("HELLO");
                    _isGameOver = true;
                    score.StopScoring();
                    runner.StopRunning();
                    obstacle.Stop();
                    game_over.SetColor(Constants.RED);
                    

                }

            foreach (Actor segment in obstacles)
            {
                
                if (runner.GetPosition().Equals(segment.GetPosition()))
                {
                    Console.WriteLine("HELLO");
                    _isGameOver = true;
                    score.StopScoring();
                    runner.StopRunning();
                    obstacle.Stop();
                    game_over.SetColor(Constants.RED);
                }
            }
        }

    }
}