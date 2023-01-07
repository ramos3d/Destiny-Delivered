using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "MainCamera")
        {
            Debug.Log("Colidiu com a camera!");
        }
         
    }

   private void OnCollisionExit(Collision other) {
        if (other.collider.gameObject.tag == "MainCamera")
        {
            Debug.Log("Saiu!");
        }
    }
}
