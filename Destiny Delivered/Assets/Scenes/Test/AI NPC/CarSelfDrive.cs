using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelfDrive : MonoBehaviour
{
    // Variables
    public Transform path;
    private List<Transform> nodes;
    public float maxSteerAngle = 45f;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public float maxMotorque = 80f;
    public float maxBrakeTorque = 150f;
    public float maxSpeed = 20f;
    public bool isBreaking = false;

    private int currentNode = 0;
    
    public float currentSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();         
        nodes = new List<Transform>();
/*
        foreach (var _path in pathTransforms)
        {
            if (_path != path.transform){
                nodes.Add(path);
            }
        }
*/

    for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
                
            }
            
        }

    }

 
    void FixedUpdate()
    {
        TurnSteer();
        Drive();
        CheckPointDistance();
        Braking();
    }

    private void TurnSteer(){
        Vector3 relativeVector = transform.InverseTransformPoint( nodes[currentNode].position);
        //print(relativeVector);
        relativeVector = relativeVector / relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude)  * maxSteerAngle ;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive(){
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000 * Time.deltaTime;

        if (currentSpeed < maxSpeed && !isBreaking)
        {
            wheelFL.motorTorque = maxMotorque;
            wheelFR.motorTorque = maxMotorque;
        }else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
            
    }
    
    private void CheckPointDistance(){
        if (Vector3.Distance(this.transform.position, nodes[currentNode].position) < 0.5f){
            Debug.Log("Node Atual: " + currentNode);
            if (currentNode == nodes.Count -1)
            {
                currentNode = 0;
            }else{
                currentNode++;
            }
        }
    }


    private void Braking(){
        if (isBreaking)
        {
            // It maight turns beacking light on if it exists
            // Break wheels
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
        }else{
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }

        
}
