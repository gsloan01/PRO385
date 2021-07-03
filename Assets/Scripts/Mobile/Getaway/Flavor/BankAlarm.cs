using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankAlarm : MonoBehaviour
{
    public float rate = 100.0f;
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rate);
    }
}
