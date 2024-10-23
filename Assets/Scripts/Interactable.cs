using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Interactable : Collidable
{
    [SerializeField] public int letterPerSecond;
    public TextMeshProUGUI Tmp;
    [TextArea] public string popUpText;
    private string interactedWith = "";
    private bool interacted = false;
    [SerializeField] public GameObject DialogArea;
    protected override void OnCollided(GameObject collidedObject)
    {
 
        if (collidedObject.tag == "Player" && collidedObject.name != interactedWith)
        {
            StartCoroutine(PopUpChange(Tmp, popUpText));
            interactedWith = collidedObject.name;

        }
        if (collidedObject.tag == "Player" && interacted == false && Input.GetKeyDown("e") )
        {

            DialogArea.SetActive(true);
            interactedWith = collidedObject.name;
            interacted = true;
            Tmp.text = "";
            OnInteract();
        }

        else if (collidedObject.tag == "Player" && interacted == true && Input.GetKeyDown("e"))
        {
            StartCoroutine(PopUpChange(Tmp, popUpText));
            DialogArea.SetActive(false);
            interacted = false;
        }
    }
    protected virtual void OnInteract()
    { 
    }
    public IEnumerator PopUpChange(TextMeshProUGUI Tmp, string text)
    {
        Tmp.text = "";
        foreach (var letter in text.ToCharArray())
        {
            
            Tmp.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }
}
