using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarController : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider[] wheelColliders;
    public GameObject[] wheelMeshes;

    [Header("Movement")]
    public float maxSpeed = 200f;
    public float acceleration = 1000f;
    public float braking = 1000f;

    [Header("Steering")]
    public float maxSteeringAngle = 45f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float accelerationInput = Input.GetAxis("Vertical");
        float steeringInput = Input.GetAxis("Horizontal");

        Accelerate(accelerationInput);
        Steer(steeringInput);

        if (Input.GetKey(KeyCode.E))
        {
            Brake();
        }

        UpdateWheelVisuals();
    }

    private void Accelerate(float input)
    {
        if (input > 0f)
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                float force = acceleration * input;
                rb.AddForce(transform.forward * force * Time.deltaTime);
            }
        }
        else if (input < 0f)
        {
            if (rb.velocity.magnitude > -maxSpeed / 2f)
            {
                Debug.Log("DANDO REEEEEEEEEEEEEEEEEEEEEEEE ");
                float force = braking * input;
                rb.AddForce(transform.forward * force * Time.deltaTime);
            }
        }
    }

    private void Steer(float input)
    {
        float steeringAngle = maxSteeringAngle * input;
        wheelColliders[0].steerAngle = steeringAngle;
        wheelColliders[1].steerAngle = steeringAngle;
    }

    private void Brake()
    {
        rb.velocity *= 0.9f;
    }

    private void UpdateWheelVisuals()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            Quaternion q;
            Vector3 p;
            wheelColliders[i].GetWorldPose(out p, out q);
            wheelMeshes[i].transform.position = p;
            wheelMeshes[i].transform.rotation = q;
        }
    }
}