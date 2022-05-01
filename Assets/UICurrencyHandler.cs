using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrencyHandler : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {   
        text.text = PlayerManager.Instance.IngameCurrency.ToString();
    }
}
