using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Obstacle : Actor
    {
        private List<Actor> _cacti = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Obstacle()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_cacti.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _cacti[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _cacti;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        // public void GrowTail(int numberOfSegments)
        // {
        //     for (int i = 0; i < numberOfSegments; i++)
        //     {
        //         // Actor tail = _cacti.Last<Actor>();
        //         // Point velocity = tail.GetVelocity();
        //         // Point offset = velocity.Reverse();
        //         // Point position = tail.GetPosition().Add(offset);
        //         Point position = new Point(200, 200);
        //         Point velocity = new Point(1, 0);

        //         Actor segment = new Actor();
        //         segment.SetPosition(position);
        //         segment.SetVelocity(velocity);
        //         segment.SetText("");
        //         segment.SetColor(Constants.GRAY);
        //         _cacti.Add(segment);
        //     }
        // }

        // / <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _cacti)
            {
                Point position = segment.GetPosition();
                // segment.MoveNext();
                int x = position.GetX() - 15;
                int y = position.GetY();
                position = new Point(x, y);
                segment.SetPosition(position);
                
            }

            

            // for (int i = _cacti.Count - 1; i > 0; i--)
            // {
            //     Actor trailing = _cacti[i];
            //     Actor previous = _cacti[i - 1];
            //     Point velocity = previous.GetVelocity();
            //     trailing.SetVelocity(velocity);
            // }
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            _cacti[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        public void PrepareBody()
        {
            int x = Constants.MAX_X / 8;
            int y = 297;

            for (int i = 0; i < 1; i++)
            {
                Point position = new Point(895, y);
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
}