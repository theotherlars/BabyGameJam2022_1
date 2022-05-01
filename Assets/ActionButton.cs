using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField]Image iconImage;
    [SerializeField]Image backgroundImage;
    
    public void UpdateButton(Sprite _image, Sprite _parentImage){
        iconImage.sprite = _image;
        backgroundImage.sprite = _parentImage;
    }
}
