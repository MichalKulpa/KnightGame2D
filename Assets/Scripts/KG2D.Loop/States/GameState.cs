namespace KG2D.Loop
{
    public class GameState : BaseState
    {
        public override void Initialize()
        {
            gameController.InputSystem.move += gameController.PlayerMovement.Move;

        }
        public override void Tick()
        {
            gameController.InputSystem.UpdateInputs();

        }
        public override void FixedTick()
        {
            //gameController.InputSystem.UpdateInputs();
        }
        public override void LateTick()
        {
            gameController.PlayerMovement.Move();
        }
    }
}

