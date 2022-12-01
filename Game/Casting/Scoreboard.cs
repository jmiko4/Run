using System.Collections.Generic;


namespace Unit04.Game.Casting
{
    /// <summary>
    /// <para>A scoreboard.</para>
    /// <para>Keeps track of the scoreboard
    /// </para>
    /// </summary>
    public class Scoreboard
    {


        private int _points;

        public Scoreboard(){
            _points = 0;
        }

        //returns the points
        public int GetPoints(){
            return _points;
        }

        //adds a point
        public void AddPoint(){
            _points++;
        }

        //remobves a point
        public void RemovePoint(){
            _points--;
        }



    }
}