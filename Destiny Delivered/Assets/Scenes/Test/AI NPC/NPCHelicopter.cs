using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHelicopter : MonoBehaviour
{
    public GameObject _main_rotor;
    public float _velocity = 2000f;
    public Transform path;
    private List<Transform> nodes;
    //private int currentNode = 0;

    //public float currentSpeed = 0.5f;
    //public float maxSpeed = 2.0f;
    public bool move = false;

    Vector3 limit = new Vector3(0, 1, 1);
    

    void Start()
    {
        _main_rotor = GameObject.FindGameObjectWithTag("Rotor");
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();         
        nodes = new List<Transform>();

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
        RotateMotor();
        FlyAround();
    }

    void RotateMotor(){
        _main_rotor.transform.Rotate(0, Time.deltaTime * _velocity, 0);
    }

    void FlyAround(){
        if(move){ // Down
            gameObject.transform.position -= limit * Time.deltaTime * 2f;
        }else{  // Up
           
            gameObject.transform.position +=  limit * Time.deltaTime * 2f;
        }

        if (gameObject.transform.position.y <=36.6f )
        {
            move = false; // Up
        }
        if (gameObject.transform.position.y >=50f )
        {
            move = true; // Up
        }
    }
   
}
