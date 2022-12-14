using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Floor.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Floor's first caracter.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(-Constants.CELL_SIZE, 0);
        private Point _direction2 = new Point(-Constants.CELL_SIZE, 0);
        

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Runner runner = (Runner)cast.GetFirstActor("runner");
            Point position = runner.GetPosition();
            runner.Gravity(position);

            if (_keyboardService.IsKeyDown("space"))
            {
                if(position.GetY() >= 285)
                {
                    runner.Jump();
                }
                
            }

            Floor2 Floor2 = (Floor2)cast.GetFirstActor("Floor2");
            Score score = (Score)cast.GetFirstActor("score");
            score.AddPoints(0);
            
        }
    }
}