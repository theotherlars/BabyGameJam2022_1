using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarHandler : MonoBehaviour
{
    public List<GameObject> actionButtons =  new List<GameObject>();
    public int slots;
    
    private void Start() {
        PlayerManager.Instance.onNewSlot.AddListener(UpdateSlots);

        for(int i = 0; i < slots; i++){
            actionButtons[i].SetActive(true);
        }   
    }

    private void OnDisable() {
        PlayerManager.Instance.onNewSlot.RemoveListener(UpdateSlots);
    }
    
    void UpdateSlots(){
        slots++;
        actionButtons[slots-1].SetActive(true);
    }

}
