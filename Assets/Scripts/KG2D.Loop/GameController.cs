using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KG2D.Player;
namespace KG2D.Loop
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement playerMovement;

        private InputSystem inputSystem;



        public PlayerMovement PlayerMovement => playerMovement;
        public InputSystem InputSystem => inputSystem;
        

        private BaseState currentState;

        private void Awake()
        {
            inputSystem = new InputSystem();
        }

        void Start()
        {
            playerMovement.InitializeSystem();
            ChangeState(new GameState());
        }

       
        void Update()
        {
            currentState?.Tick();
        }

        private void FixedUpdate()
        {
            currentState?.FixedTick();
        }

        private void LateUpdate()
        {
            currentState?.LateTick();
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.Dispose(); //OnDestroy
            currentState = newState;
            currentState?.BeforeInitialize(this); //Awake
            currentState?.Initialize(); //Start
        }
            

    }
}

