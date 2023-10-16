namespace KG2D.Loop
{
    public class GameState : BaseState
    {
        public override void Initialize()
        {
            gameController.InputSystem.move += gameController.PlayerMovement.Move;
            gameController.InputSystem.jump += gameController.PlayerMovement.Jump;
            gameController.InputSystem.attack += gameController.PlayerMovement.Attack;
            gameController.InputSystem.roll += gameController.PlayerMovement.Roll;
        }
        public override void Tick()
        {
            gameController.PlayerMovement.UpdateMovement();
        }
        public override void FixedTick()
        {
            
        }
        public override void LateTick()
        {
            gameController.InputSystem.UpdateInputs();
        }
    }
}

