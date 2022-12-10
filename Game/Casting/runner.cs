using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A character who runs and jumps</para>
    /// <para>The responsibility if the runner is to jump over objects.</para>
    /// </summary>
    public class Runner : Actor
    {
        Point position = new Point(90, 255);
        private bool IsJumping;
        private bool hangtime = false;
        private int time = 0;
        private int time2 = 0;
        private Point gravity = new Point(0, Constants.CELL_SIZE * 2);
        private Point neutral = new Point(0,0);
        private Point jump = new Point(0,-Constants.CELL_SIZE * 2);
        /// <summary>
        /// Constructs a new instance of a Runner.
        /// </summary>
        public Runner()
        {
            SetText("#");
            SetColor(Constants.RED);
            SetPosition(position);
        }
        /// <summary>
        /// Changes the velocity of the Runner to jump
        /// </summary>
        public void Jump()
        {
            IsJumping = true;
        }
        /// <summary>
        /// Causes a gravity like effect on the Runner.
        /// Controls the Velocity of the Jump based upon different conditions.
        /// </summary>
        public void Gravity(Point position)
        {
            
            
            if (IsJumping == true | hangtime == true)
            {   if (IsJumping == true)
                {
                    SetVelocity(jump);
                    time++;
                    if (time == 5)
                    {
                        IsJumping = false;
                        time = 0;
                        hangtime = true;
                    }
                }
                else if (hangtime == true)
                {
                    SetVelocity(neutral);
                    time = 0;
                    time2++;
                    if (time2 == 2)
                    {
                        hangtime = false;
                        time2 = 0;
                    }
                }
                
            }
            else if(position.GetY() < 285)
            {
                SetVelocity(gravity);
            }
            else if (position.GetY() == 285)
            {
                SetVelocity(neutral);
            }
        }
            
    }
}