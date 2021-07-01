using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTilt : MonoBehaviour
{
    private void OnEnable()
    {
        GyroManager.Instance.gyroUpdateEvent += Tilt;
    }
    private void OnDisable()
    {
        if (GyroManager.Instance == null) return;
        GyroManager.Instance.gyroUpdateEvent -= Tilt;

    }

    void Tilt(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}
