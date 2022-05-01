using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuHandler : MonoBehaviour
{
    Animator anim;
    bool active = false;
    [SerializeField] ActionButton[] actionButtons;
    int currentActionButton = -1;
    [SerializeField] ActionBarHandler actionBarHandler;
    [SerializeField] UpgradeButton[] upgradeButtons;
    
    void Start(){
        for(int i = 0; i < upgradeButtons.Length; i++){
            if(!PlayerManager.Instance.allWeapons[i].available){
                upgradeButtons[i].Deactivate();
            }
        }

        anim = GetComponent<Animator>();
        for(int i = 0; i < PlayerManager.Instance.slotsAvailable; i++){
            currentActionButton = i;
            PlayerManager.Instance.allWeapons[i].available = true;
            SelectUpgrade(PlayerManager.Instance.activeWeapons[i]);
        }
        currentActionButton = -1;
    }


    private void Update() {
        for(int i = 0; i < upgradeButtons.Length; i++){
            if(PlayerManager.Instance.IngameCurrency >= PlayerManager.Instance.allWeapons[i].cost){
                upgradeButtons[i].Activate();
            }
            else{
                upgradeButtons[i].Deactivate();
            }
        }
    }

    public void ToggleMenu(int _actionButton){
        active = !active;
        if(active){
            currentActionButton = _actionButton ;
            anim.Play("UpgradeMenuOpen",0);
            StartCoroutine(Wait(0.8f));
        }
        else{
            // StopCoroutine(Wait(0.8f));
            currentActionButton = -1;
            Time.timeScale = 1;
            anim.Play("UpgradeMenuClose",0);
        }
    }

    public void CloseMenu(){
        active = false;
        currentActionButton = -1;
        Time.timeScale = 1;
        anim.Play("UpgradeMenuClose",0);
    }
    
    IEnumerator Wait(float timer){
        yield return new WaitForSeconds(timer);
        if(active){
            Time.timeScale = 0.1f;
        }
    }

    public void SelectUpgrade(int index){
        if(currentActionButton != -1){
            PlayerManager.Instance.activeWeapons[currentActionButton] = index;
            Weapon weapon = PlayerManager.Instance.allWeapons[index];
            actionButtons[currentActionButton].UpdateButton(weapon.weaponIcon, weapon.weaponBackground);
        }
        CloseMenu();
    }
}
