using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroManager : MonoBehaviour
{
    public delegate void gyroDelegate(Quaternion rotation);


    public event gyroDelegate gyroUpdateEvent;

    GyroControls gyroControls;


    static GyroManager instance;
    public static GyroManager Instance {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
            }
            return instance;
        }
    }

    public Quaternion rotation { get => gyroControls.Gyro.Attitude.ReadValue<Quaternion>(); }

    private void Awake()
    {
        instance = this;
        gyroControls = new GyroControls();
    }

    private void OnEnable()
    {
        gyroControls.Enable();
    }

    private void OnDisable()
    {
        gyroControls.Disable();
    }

    void Start()
    {
        instance = this;
    }


    void Update()
    {
        gyroUpdateEvent?.Invoke(rotation);
    }
}
