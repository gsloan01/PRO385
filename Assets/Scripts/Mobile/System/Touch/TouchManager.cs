using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public delegate void touchStartDelegate(Vector2 position);
    public delegate void touchStopDelegate(Vector2 position);
    public delegate void touchUpdateDelegate(Vector2 position);

    public event touchStartDelegate touchStartEvent;
    public event touchStopDelegate touchStopEvent;
    public event touchUpdateDelegate touchUpdateEvent;

    TouchControls touchControls;
    bool touched;

    static TouchManager instance;
    public static TouchManager Instance {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<TouchManager>();
            }
            return instance;
        }
    }

    public Vector2 position { get => touchControls.Touch.TouchPosition.ReadValue<Vector2>(); }

    private void Awake()
    {
        instance = this;
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        instance = this;
        touchControls.Touch.TouchPress.started += context =>  TouchPressStart(context);
        touchControls.Touch.TouchPress.canceled += context =>  TouchPressStop(context);
    }


    void TouchPressStart(InputAction.CallbackContext context)
    {
        touchStartEvent?.Invoke(position);
        touched = true;
    }

    void TouchPressStop(InputAction.CallbackContext context)
    {
        touchStopEvent?.Invoke(position);
        touched = false;
    }



    void Update()
    {
        if(touched)
        {
            touchUpdateEvent?.Invoke(position);
        }
    }
}
