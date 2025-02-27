using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableEnemyNpc : Interactable
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
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
            if (!GlobalVariables.interactedWithEnemyNPC)
            {
                GlobalVariables.interactedWithEnemyNPC = true;
                DialogArea.SetActive(true);
                interacted = true;
                Tmp.text = "";
                timesInteractedWith++;
                OnInteract(DialogContent);
            }
        }
    }
    protected override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Tmp.text = "";
            DialogArea.SetActive(false);

            // animator.SetTrigger("Attack");

        }
    }
}
