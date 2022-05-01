using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]Button button;
    [SerializeField]Image background;

    public void Activate(){
        button.interactable = true;
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1);
    }   
    public void Deactivate(){
        button.interactable = false;
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0.2f);
    }   

}
