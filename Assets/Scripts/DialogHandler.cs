using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogHandler : PlayerColliderHandler
{
    protected override void OnInteract(int optionChoosen, GameObject TalkingWith)
    {
        Debug.Log("On interact daje: "+TalkingWith);
        if (TalkingWith.name == "Bartender")
        {
            if (optionChoosen == 0)
            {
                DialogTmp.text = "";
                DialogContent = "Here you go sir\n<i>*U got a bucket of fried Kentucky Chicken*</i>";
                StartCoroutine(PopUpChange(DialogTmp, DialogContent));
                ButtonRefuse.gameObject.SetActive(false);
                ButtonConfirm.gameObject.SetActive(false);
            }
            if (optionChoosen == 1)
            {
                DialogTmp.text = "";
                DialogContent = "Your loss, it was for free";
                StartCoroutine(PopUpChange(DialogTmp, DialogContent));
                ButtonRefuse.gameObject.SetActive(false);
                ButtonConfirm.gameObject.SetActive(false);
            }
        }
        if (TalkingWith.name == "yshel")
        {
            if (optionChoosen == 0)
            {
                GlobalVariables.YshelTriggerer = true;
            }
            if (optionChoosen == 1)
            {
                DialogArea.SetActive(false);
            }

        }
        if (TalkingWith.name == "BarrelLime")
        {

        }
        if (TalkingWith.name == "Lime")
        {
            ButtonRefuse.gameObject.SetActive(false);
            ButtonConfirm.gameObject.SetActive(false);
        }
    }
}
