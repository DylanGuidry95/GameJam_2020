using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float HorizontalSpeed;
    [Range(0.1f, 10.0f)]
    public float RotationSpeed;
    [Range(0.0f, 10.0f)]
    public float JumpForce;

    private void Update()
    {
        
    }
}
