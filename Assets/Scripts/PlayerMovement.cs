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
    [Range(0.01f, 10.0f)]
    public float HorizontalSpeed = 0.1f;
    [Range(0.1f, 10.0f)]
    public float RotationSpeed = 0.1f;
    [Range(0.1f, 10.0f)]
    public float VerticalViewSpeed = 0.1f;
    [Range(0.0f, 100.0f)]
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

    private bool IsGrounded
    {
        get
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position - transform.up, -transform.up, out hit, 0.1f))
            {
                if (hit.collider.gameObject.tag == "Ground")
                    return true;
            }
            return false;
        }
    }

    private void Awake()
    {
        rbRef = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float hValue = HorizontalSpeed * Input.GetAxis(HorizontalAxis);
        float vValue = HorizontalSpeed * Input.GetAxis(VerticalAxis);
        float rValue = RotationSpeed * Input.GetAxis(RotationAxis);
        float vvValue = VerticalViewSpeed * Input.GetAxis(VerticalViewAxis);

        RaycastHit hitSide;
        Debug.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.right * 1, Color.blue);
        Debug.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.right * -1, Color.blue);
        if (!Physics.Raycast(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.right * ((hValue > 0) ? 1 : -1), out hitSide, 1))
        {
            rbRef.transform.position += transform.right * hValue;
        }
        RaycastHit hitForward;
        Debug.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.forward * 1, Color.green);
        Debug.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.forward * -1, Color.green);
        if (!Physics.Raycast(transform.position - transform.up + new Vector3(0,0.25f, 0), transform.forward * ((vValue > 0) ? 1 : -1), out hitForward, 1))
        {            
            rbRef.transform.position += gameObject.transform.forward * vValue;
        }

        transform.Rotate(new Vector3(0, rValue, 0), Space.World);

        lookRotation += -vvValue;
        lookRotation = Mathf.Clamp(lookRotation, MinCamVerticalRotation, MaxCamVerticalRotation);
        CameraRef.transform.eulerAngles = new Vector3(lookRotation, transform.eulerAngles.y, transform.eulerAngles.z);        

        if(Input.GetButtonDown(JumpButton) && IsGrounded)
        {
            rbRef.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position - transform.up, -transform.up * 0.1f);
        float hValue = HorizontalSpeed * Input.GetAxis(HorizontalAxis);
        float vValue = HorizontalSpeed * Input.GetAxis(VerticalAxis);
        float rValue = RotationSpeed * Input.GetAxis(RotationAxis);
        float vvValue = VerticalViewSpeed * Input.GetAxis(VerticalViewAxis);
        Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.right * 1.5f);
        //Gizmos.DrawRay(transform.position - transform.up + new Vector3(0, 0.25f, 0), transform.forward * 1.5f);
    }
}
