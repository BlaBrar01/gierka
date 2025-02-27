using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimePopUpDialog : Interactable
{
    Collider2D interactionCollider;
    Collider2D triggerColliderStop;
    Collider2D triggerColliderOutOfBarrel;
    [SerializeField] GameObject Lime;
    void Start()
    {
        interactionCollider = GameObject.Find("BarrelLime").GetComponent<Collider2D>();
        triggerColliderStop = GameObject.Find("BarrelLimeCutsceneCollider").GetComponent<Collider2D>();
        triggerColliderOutOfBarrel = GameObject.Find("BarrelLimeGettingOutOfBarrel").GetComponent<Collider2D>();

    }
    void PlayerStop()
    {
        triggerColliderStop.enabled = true;
    }
    void LimeDialog1st()
    {
        if (!PositionChanged)
        {
            Vector3 temp = new Vector3(0, 29f, 0);
            DialogArea.transform.position += temp;
            PositionChanged = true;
            // DialogAreaPosition = DialogArea.transform.position.y;
        }
        // ButtonConfirmLabel.text = "";
        // ButtonRefuseLabel.text = "";
        // ButtonConfirmLabel.text = ButtonConfirmText;
        // ButtonRefuseLabel.text = ButtonRefuseText;
        DialogArea.SetActive(true);
        interacted = true;
        Tmp.text = "";
        timesInteractedWith++;
        OnInteract(DialogContent);
        triggerColliderStop.enabled = false;//maybe add new event when he jumps out ?  
    }
    void GettingOut()
    {
        interactionCollider.enabled = false;
    }
    void LimeGameObjectTrigger()
    {
        DialogArea.SetActive(true);
        interacted = true;
        Tmp.text = "";
        DialogContent = "Maybe ask this mysterious person whats happening in this place ?";
        timesInteractedWith++;
        OnInteract(DialogContent);
        Lime.SetActive(true);
    }

}

