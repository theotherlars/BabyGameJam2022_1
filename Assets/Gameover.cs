using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameover : MonoBehaviour
{
    TextMeshProUGUI text;
    
    void Start(){
        text = GetComponent<TextMeshProUGUI>();
        PlayerManager.Instance.onDeath.AddListener(ShowText);
    }

    void ShowText(){
        text.text = "GAME OVER";
    }

}
