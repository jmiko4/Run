using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int _points = 0;
        Point Scoreboard = new Point(810,15);
        private bool scoring = true;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {
            AddPoints(0);
            SetColor(Constants.RED);
            SetPosition(Scoreboard);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            if (scoring == true)
            {
                this._points ++;
            SetText($"Score: {this._points}");
            }
            else
            {
                SetText($"Score: {this._points}");
            }
            
        }

        public void StopScoring()
        {
            this.scoring = false;
        }
    }
}