using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars_BackgroundScript : MonoBehaviour
{
    SpriteRenderer starRender;
    public Color yelloWeak;
    public Color yellowStrong;

    public float changingAlphaValue;

    private void Start()
    {
        starRender = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        //changingAlphaValue = Mathf.Lerp(0,1,100);
        //starRender.color =  Color.Lerp(yellow,white, 2);
        starRender.color =  Color.Lerp(yelloWeak,yellowStrong, Mathf.PingPong(Time.time, 1));
    }


    // IEnumerator ChangetoYellow()
    // {
    //     // yield return new WaitForSeconds(2);
    //     // starRender.color = Mathf.Lerp(yellow, white, 10);


    

//}

}
