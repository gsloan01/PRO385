using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipPlayer : MonoBehaviour
{
    //movement speed
    public float speed = 2;

    //player shot
    public GameObject shot;

    //input value
    Vector2 input;

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }
    private void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.name == "Fire")
        {
            OnFire();
        }
        if (context.action.name == "Move")
        {
            OnMove(context);
        }
    }


    void Update()
    {
        ////Gamepad controls
        //Gamepad gamepad = Gamepad.current;
        //if (gamepad == null) return;

        //input = gamepad.leftStick.ReadValue();
        //if (gamepad.buttonSouth.wasPressedThisFrame)
        //{
        //    OnFire();
        //}

        ////Keyboard Controls
        //input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");

        transform.Translate(input * speed * Time.deltaTime);

        //if(Input.GetButtonDown("Fire1"))
        //{
        //    OnFire();
        //}
    }

    public void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    //sending and broadcasting messages
    public void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
    }

    //invoke unity events
    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

}
