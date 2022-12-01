
namespace Unit04.Game.Casting{

    public class Clock{
        //Is a clock that keeps track of the game's countdown
        private int _timer;
        private int _tickCount;
        public Clock(){
            _timer = 60;
            _tickCount = 0;
        }

        public void Tick(){
            //every 12 ticks is a second of real time
            _tickCount++;
            if (_tickCount == 12){
                _tickCount = 0;
                _timer--;
            }
        }

        public string GetTimer(){
            //returns the timer
            if (_timer <= 0){
                string lost = "Game Over";
                return (lost);
            }
            else{return _timer.ToString();}
        }

        


    }


}