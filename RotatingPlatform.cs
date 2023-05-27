using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float RotateSpeedPlatform;

    void Update()
    {
        transform.Rotate(new Vector3(0f, RotateSpeedPlatform, 0f));
    }
}
