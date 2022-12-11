using Unit05.Game.Casting;
using Unit05.Game.Services;
using System;

namespace Unit05.Game.Scripting{

    public class Clock : Action{
        //Is a clock that keeps track of the number of ticks and increases the length of the Floor
        private int _tickCount;
        private int _rticks;
        Random rand = new Random();
        
        public Clock(){
            _tickCount = 0;
            
        }

        public void Tick(Cast cast){
            //every 5 ticks increases the length of the Floor
            _rticks = rand.Next(20, 50);
            Obstacle obstacle = (Obstacle)cast.GetFirstActor("obstacles");
            _tickCount++;
            if (_tickCount >= _rticks){
                _tickCount = 0;
                obstacle.PrepareBody();
            }
        }

        public void Execute(Cast cast, Script script){
            Tick(cast);
        }

        


    }


}