namespace KG2D.Loop
{
    public abstract class BaseState
    {
        protected GameController gameController;

        public virtual void BeforeInitialize(GameController gameController)
        {
            this.gameController = gameController;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Tick()
        {

        }
        public virtual void FixedTick()
        {

        }
        public virtual void LateTick()
        {

        }
        public virtual void Dispose()
        {

        }
    }

}
