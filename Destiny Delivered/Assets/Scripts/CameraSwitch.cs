using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitch
{
   static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
   public static CinemachineVirtualCamera activeCamera = null;
   
   public static bool isActiveCamera(CinemachineVirtualCamera camera)
   {
        return camera == activeCamera;
   }


    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        activeCamera = camera;

        foreach (CinemachineVirtualCamera cam  in cameras)
        {
            if (cam != camera && cam.Priority != 0)
            {
                cam.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera){
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera){
        cameras.Remove(camera);
    }
}
