using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Object Refrences")]
    private Rigidbody rbRef;
    public Camera CameraRef;


    [Header("Modifiers")]
    [Range(0.01f, 1.0f)]
    public float HorizontalSpeed = 0.1f;
    [Range(0.1f, 10.0f)]
    public float RotationSpeed = 0.1f;
    [Range(0.1f, 10.0f)]
    public float VerticalViewSpeed = 0.1f;
    [Range(0.0f, 10.0f)]
    public float JumpForce = 0;

    [Range(-90, 0)]
    public float MinCamVerticalRotation = -45;

    [Range(0, 90)]
    public float MaxCamVerticalRotation = 45;

    [Header("Controls")]
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";
    public string RotationAxis = "Mouse X";
    public string VerticalViewAxis = "Mouse Y";
    public string JumpButton = "Jump";    
    
    private float lookRotation;

    private void Awake()
    {
        rbRef = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hValue = HorizontalSpeed * Input.GetAxis(HorizontalAxis);
        float vValue = HorizontalSpeed * Input.GetAxis(VerticalAxis);
        float rValue = RotationSpeed * Input.GetAxis(RotationAxis);
        float vvValue = VerticalViewSpeed * Input.GetAxis(VerticalViewAxis);

        rbRef.transform.position += gameObject.transform.right * hValue;
        rbRef.transform.position += gameObject.transform.forward * vValue;

        transform.Rotate(new Vector3(0, rValue, 0), Space.World);

        lookRotation += -vvValue;
        lookRotation = Mathf.Clamp(lookRotation, MinCamVerticalRotation, MaxCamVerticalRotation);
        CameraRef.transform.eulerAngles = new Vector3(lookRotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
