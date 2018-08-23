using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSize : MonoBehaviour {
    public Button button;
    public Vector2 ButtSize = new Vector2(0, 0); // how big you want it?.

    

    public void OnMouseEnter()
    {
        button.image.rectTransform.sizeDelta = ButtSize;
    }

    public void OnMouseExit()
    {
        button.image.rectTransform.sizeDelta = new Vector2(50, 50);//remains static for button size.
    }

}
