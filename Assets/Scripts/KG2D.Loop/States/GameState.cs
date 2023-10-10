namespace KG2D.Loop
{
    public class GameState : BaseState
    {
        public override void Initialize()
        {
            gameController.InputSystem.move += gameController.PlayerMovement.Move;
            gameController.InputSystem.jump += gameController.PlayerMovement.Jump;
        }
        public override void Tick()
        {
            gameController.InputSystem.UpdateInputs();

        }
        public override void FixedTick()
        {
            
        }
        public override void LateTick()
        {
            
            
        }
    }
}

