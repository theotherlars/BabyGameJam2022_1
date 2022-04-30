using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class ShakeTestScript : MonoBehaviour
{

    public ShakeData myShakeData;


    // Start is called before the first frame update
    private void Start()
    {
        CameraShakerHandler.Shake(myShakeData);
    }

}
