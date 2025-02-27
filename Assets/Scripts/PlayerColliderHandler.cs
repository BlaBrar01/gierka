using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerColliderHandler : Interactable
{
    public static GameObject TalkingWith;
    public Button ButtonConfirm;
    public  Button ButtonRefuse;
    private bool DoorCollider = false;
    [SerializeField] private Animator DoorAnimator;
    [SerializeField] private Animator LimeAppearAnimator;
    void Start()
    {
        ButtonConfirm = GameObject.Find("ButtonConfirm").GetComponent<Button>();
        ButtonRefuse = GameObject.Find("ButtonRefuse").GetComponent<Button>();
        ButtonConfirm.onClick.AddListener(OnConfirm);
        ButtonRefuse.onClick.AddListener(OnRefuse);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Interactable" )
        {

            TalkingWith = collider.gameObject;
            ButtonRefuse.gameObject.SetActive(true);
            ButtonConfirm.gameObject.SetActive(true);
        } 
        if (collider.gameObject.name == "npc")
        {
            ButtonRefuse.gameObject.SetActive(false);
            ButtonConfirm.gameObject.SetActive(false);
        }
        if (collider.gameObject.name == "Doors")
        {

        }
        if (collider.gameObject.name == "yshel")
        {
            ButtonRefuse.gameObject.SetActive(true);
            ButtonConfirm.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (DoorCollider == true && Input.GetKeyDown("e"))
        {
            DoorAnimator.SetBool("NextToDoors", true);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Doors")
        {
            StartCoroutine(PopUpChange(Tmp, "Press E to exit the Tavern"));
            DoorCollider = true;

        }
        if (collider.gameObject.name == "BarrelLime")
        {
            LimeAppearAnimator.SetBool("LimeAppearTrigger", true);
        }
        if (collider.gameObject.name == "BarrelLimeGettingOutOfBarrel")
        {
            LimeAppearAnimator.SetBool("LimeOutOfBarrel", true);
        }
        if (collider.gameObject.name == "yshel")
        {
            GlobalVariables.CollidedWithYshel = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Doors")
        {
            StartCoroutine(PopUpChange(Tmp, ""));
            DoorCollider = false;
        }

    }

    void OnConfirm()
    {
        OnInteract(0,TalkingWith);
    }
    void OnRefuse()
    {
        OnInteract(1, TalkingWith);
    }


}
