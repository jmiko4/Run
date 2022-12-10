using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>
    /// The responsibility of the score is to keep track of the user's score and display it
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int _points = 0;
        Point Scoreboard = new Point(810,15);
        private bool scoring = true;

        /// <summary>
        /// Constructs a new scoreboard
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

        /// <summary>
        /// Stops the score when player loses
        /// </summary>
        public void StopScoring()
        {
            this.scoring = false;
        }
    }
}