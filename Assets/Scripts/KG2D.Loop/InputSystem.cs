using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KG2D.Loop
{
    public class InputSystem
    {
        public Action move;
        public Action jump;
        public Action attack;
        public Action roll;

        public void UpdateInputs()
        {
            if (Input.GetAxis("Horizontal")!=0)
            {
                move?.Invoke();              
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                jump?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0)
                || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                attack?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                roll?.Invoke();
            }

        }


    }
}

