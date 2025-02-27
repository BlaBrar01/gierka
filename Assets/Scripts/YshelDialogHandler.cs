using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YshelDialogHandler : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        collider.OverlapCollider(filter, collidedObjects);
        foreach (var o in collidedObjects)
        {
            if (o.CompareTag("Player"))
            {

                OnCollidedPlayer(o.gameObject);
                if( Input.GetKeyDown("e"))
                {
                    GlobalVariables.InteractedWithYshel = true;
                }
            }

        }
        DialogContent = "First kill all of the Shrooms.They are hiding in the bushes..." + "after u slain " + (3-GlobalVariables.ShroomiesKilled).ToString() + "  more then we will talk more. ";
        if (GlobalVariables.ShroomiesKilled >= 3)
        {
            DialogContent = "Atlast i can introduce myself my name is Yshel the protector of the forest as a reward for smitting those unholy beings I can help you getting across the hill. Follow me.";
            ButtonConfirmLabel.text = "Follow him";
            ButtonRefuseLabel.text = "Wait";
        }
        if(GlobalVariables.YshelMoves)
        {
            popUpText = "Press E to talk with Yshel the protector";
            DialogContent = "Sorry I didnt help you with them and sorry I cant go any faster than that I m far too old";
        }
    }

}
