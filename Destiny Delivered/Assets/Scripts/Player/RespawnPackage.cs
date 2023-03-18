using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnPackage : MonoBehaviour
{
    public float waitTime = 4.0f;


    private bool canRespawn = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log("The Box Fell down");
            canRespawn = true;
            Timer.isCarActive = false;
            GameController.new_msg = true;
            GameController.msg = "Wait!\n Picking up the lost package!\n Press ENTER";
            StartCoroutine(WaitAndRespawn());
        }
            
    }

    private IEnumerator WaitAndRespawn()
    {
        yield return new WaitForSeconds(waitTime);

        if (canRespawn)
        {
            RespawnToOriginalPoint();
            canRespawn = false;
        }
    }

    private void RespawnToOriginalPoint()
    {
        Timer.isCarActive = true;
        GameObject package = GameObject.Find("Paper_Pack");
        package.transform.position = GameObject.Find("RespawnPoint").transform.position;
        package.transform.rotation = GameObject.Find("RespawnPoint").transform.rotation;

    }

}
