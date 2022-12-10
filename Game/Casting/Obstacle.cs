using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A cactus which hurts if you touch it </para>
    /// <para>The responsibility of the obstacles is to get in the runners way </para>
    /// </summary>
    public class Obstacle : Actor
    {
        private List<Actor> _cacti = new List<Actor>();
        private bool playing = true;

        /// <summary>
        /// Constructs a new instance of Obstacles
        /// </summary>
        public Obstacle()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the all the obstacles
        /// </summary>
        /// <returns>The obstacles in a list</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_cacti.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the first cacti in the list
        /// </summary>
        /// <returns>The first cacti in the list</returns>
        public Actor GetHead()
        {
            return _cacti[0];
        }

        /// <summary>
        /// Gets the rest of the cacti in the list.
        /// </summary>
        /// <returns>A list of cacti that will be used as obstacles</returns>
        public List<Actor> GetSegments()
        {
            return _cacti;
        }

        // / <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _cacti)
            {
                if (playing == true)
                {
                    Point position = segment.GetPosition();
                    int x = position.GetX() - 15;
                    int y = position.GetY();
                    position = new Point(x, y);
                    segment.SetPosition(position);
                }
                else
                {
                    Point stop = new Point(0, 0);
                    segment.SetVelocity(stop);
                }
                
                
            }
        }

        /// <summary>
        /// Sets the velocity of the first cacti
        /// </summary>
        public void TurnHead(Point direction)
        {
            _cacti[0].SetVelocity(direction);
        }

        /// <summary>
        /// Creates new instances of cacti
        /// </summary>
        public void PrepareBody()
        {
            int x = 900;
            int y = 285;

            for (int i = 0; i < 1; i++)
            {
                if (playing == true)
                {
                    Point position = new Point(x, y);
                    Point velocity = new Point(-1 * Constants.CELL_SIZE, 0);
                    string text = i == 0 ? ">|<" : "_";
                    Color color = i == 0 ? Constants.GRAY : Constants.GRAY;

                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    _cacti.Add(segment);
                }
            }
        }

        /// <summary>
        /// Stops the movement of the obstacles
        /// </summary>
        public void Stop()
        {
            playing = false;
        }
    }
}