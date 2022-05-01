using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWaveHandler : MonoBehaviour
{
    TextMeshProUGUI text; 
    float showTextTime = 3.0f;
    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        Wave.onWaveStart.AddListener(ShowText);
    }

    private void ShowText(){
        StartCoroutine(WaitBeforeRemoveText(showTextTime));
    }

    IEnumerator WaitBeforeRemoveText(float duration){
        text.text = "Wave " + (WaveManager.Instance.currentWave + 1).ToString();
        yield return new WaitForSeconds(duration);
        text.text = "";
    }


}
