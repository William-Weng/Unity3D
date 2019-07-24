using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public float RotateSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, RotateSpeed);
    }
}
