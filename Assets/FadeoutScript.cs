using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutScript : MonoBehaviour
{

    Color m_NewColor;
    SpriteRenderer m_SpriteRenderer;

    Color startColor;
    Color fadeoutColor;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        startColor = m_SpriteRenderer.color;
        StartCoroutine("Fader");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
        }
    }

    IEnumerator Fader(){
        yield return new WaitForSeconds(1);
        m_SpriteRenderer.color = Color.Lerp(startColor, new Color(255, 255, 255, 100), Mathf.PingPong(Time.time, 1));
    }
}
