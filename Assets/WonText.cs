using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WonText : MonoBehaviour
{
    TextMeshProUGUI text;
    
    void Start(){
        text = GetComponent<TextMeshProUGUI>();
        WaveManager.onWin.AddListener(ShowText);
    }

    void ShowText(){
        text.text = "YOU JUST WON!";
    }
}
