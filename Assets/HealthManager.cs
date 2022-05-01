using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] List<Sprite> healthImages = new List<Sprite>();
    Image currentImage;
    private void Start() {
        currentImage = GetComponent<Image>();
        currentImage.sprite = healthImages[3];
        PlayerManager.Instance.onHealthLost.AddListener(LoseHealth);
    }

    void LoseHealth(){
        if(PlayerManager.Instance.currentHealth > 0 ){
            currentImage.sprite = healthImages[(int)PlayerManager.Instance.currentHealth];
        }
    }
}
