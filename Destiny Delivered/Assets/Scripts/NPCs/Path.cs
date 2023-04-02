using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Class Responsible for restrict the path where the car should go through.
*/
public class Path : MonoBehaviour
{
   
    // Variables
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();                          // List of nodes
    Vector3 currentNode ;
    Vector3 previousNode = new Vector3(0f, 0f, 0f);

    // Change the color of the nodes for visualization purpose
    void OnDrawGizmos(){
        Gizmos.color = lineColor;
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();          //  Keep into array all the nodes
        nodes = new List<Transform>();

        foreach (var path in pathTransforms)
        {
            if (path != transform){
                nodes.Add(path);
            }
        }
        
      /*  for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        */

        // Going through nodes
        for (int i = 0; i < nodes.Count; i++){
            currentNode = nodes[i].position;                                        // Get the current position (x,y,z) of this node
        
            // Preventing offindex 
            if (i > 0){
                previousNode = nodes[ i - 1].position;
            }else if( i == 0 && nodes.Count > 1) {                                  // There is at least 2 nodes
                previousNode = nodes[nodes.Count - 1].position;                     // Obs. Count starts counting from 1, not from 0 as usual
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.3f);                               // Draw the verti
        }
    }
}
