using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    Image image;
    
    // Start is called before the first frame update
    void Start(){
        image = GetComponent<Image>();
    }

    public void UpdateButton(Image _image, Color _color){
        image.color = _color;
        image.sprite = _image.sprite;
    }
}
