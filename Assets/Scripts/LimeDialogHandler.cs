using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimeDialogHandler : Interactable
{
    void Update()
    {
        collider.OverlapCollider(filter, collidedObjects);
        foreach (var o in collidedObjects)
        {
            if (o.CompareTag("Player"))
            {

                OnCollidedPlayer(o.gameObject);
            }

        }
        if (GlobalVariables.interactedWithEnemyNPC)
            {
                DialogContent = "What was that, it didnt seem nice at all";
            }
        if (GlobalVariables.CollidedWithYshel)
        {
            DialogContent = "We shoudld investigate this strange pile of leafs, it looks suspicious, thats what i m thinking";
        }
        if(GlobalVariables.InteractedWithYshel)
        {
            DialogContent = "If he cares about it so much we should help him. "+ (3 - GlobalVariables.ShroomiesKilled).ToString() + " Shroomies are remaining.";
        }
        if (GlobalVariables.ShroomiesKilled >= 3 && GlobalVariables.InteractedWithYshel)
        {
            DialogContent = "Now we should go back and talk with him again As far as I understood he will help us overcome the hill.";
        }
        if (GlobalVariables.YshelMoves)
        {
            DialogContent = "How is he suppose to help us if he coudlnt kill them by their own?";
        }
    }
}
