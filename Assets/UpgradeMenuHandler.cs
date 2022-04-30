using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuHandler : MonoBehaviour
{
    Animator anim;
    bool active = false;
    ActionButton actionButton;

    
    void Start(){
        anim = GetComponent<Animator>();
    }

    public void ToggleMenu(ActionButton _actionButton){
        active = !active;
        if(active){
            actionButton = _actionButton;
            anim.Play("UpgradeMenuOpen",0);
            StartCoroutine(Wait(0.8f));
        }
        else{
            StopCoroutine(Wait(0.8f));
            actionButton = null;
            Time.timeScale = 1;
            anim.Play("UpgradeMenuClose",0);
        }
    }
    IEnumerator Wait(float timer){
        yield return new WaitForSeconds(timer);
        if(active){
            Time.timeScale = 0.1f;
        }
    }

    public void SelectUpgrade(int index){
        
    }
}
