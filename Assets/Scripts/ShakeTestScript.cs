using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public  class CameraShakeScript : MonoBehaviour
{

    public ShakeData myShakeData;
    public static CameraShakeScript Instance;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void CameraShake()
    {
        CameraShakerHandler.Shake(myShakeData);
    }
}
