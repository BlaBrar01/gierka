using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUpSystem : Interactable
{  

    void Start()
    {
        StartCoroutine(PopUp(popUpText));
    }
    public IEnumerator PopUp(string text)
    {
        Tmp.text = "";
        foreach (var letter in text.ToCharArray())
        {
            Tmp.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }

 
}
