using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            Snake2 snake2 = (Snake2)cast.GetFirstActor("snake2");
            List<Actor> segments2 = snake2.GetSegments();
            Obstacle obstacle = (Obstacle)cast.GetFirstActor("obstacle");
            List<Actor> obstacles = obstacle.GetSegments();
            Runner runner = (Runner)cast.GetFirstActor("runner");
            // Actor score = cast.GetFirstActor("score");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segments2);
            _videoService.DrawActors(obstacles);
            _videoService.DrawActor(runner);
            // _videoService.DrawActor(score);
            _videoService.DrawActor(food);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}