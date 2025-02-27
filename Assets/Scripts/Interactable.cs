using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactable : MonoBehaviour
{
    //collision
    [SerializeField]protected Collider2D collider;
    [SerializeField] protected ContactFilter2D filter;
    [SerializeField] protected List<Collider2D> collidedObjects = new List<Collider2D>(1);
    //pop up
    [SerializeField] public int letterPerSecond;
    public TextMeshProUGUI Tmp;
    [TextArea] public string popUpText;
    public static bool interacted = false;

    //dialog area
    [SerializeField] public GameObject DialogArea;
    public float DialogAreaPosition;
    public static bool PositionChanged =false ;
    [TextArea] public string DialogContent;
    [SerializeField] public TextMeshProUGUI DialogTmp;

    //dialog menu
    [TextArea] public string ButtonConfirmText;
    [TextArea] public string ButtonRefuseText;
    public TextMeshProUGUI ButtonConfirmLabel;
    public TextMeshProUGUI ButtonRefuseLabel;

    //interaction variables
    public static int timesInteractedWith = 0;
    protected void Start()
    {
        collider = GetComponent<Collider2D>();
    }
    protected void Update()
    {
        collider.OverlapCollider(filter, collidedObjects);
        foreach (var o in collidedObjects)
        {
            if (o.CompareTag("Player"))
            {
               
                OnCollidedPlayer(o.gameObject);
            }

        }
    }
    protected void OnCollidedPlayer(GameObject collidedObject)
    {

        if (interacted == false && Input.GetKeyDown("e"))
        {
            if (!PositionChanged)
            {
                Vector3 temp = new Vector3(0, 29f, 0);
                DialogArea.transform.position += temp;
                PositionChanged = true;
               // DialogAreaPosition = DialogArea.transform.position.y;
            }
            ButtonConfirmLabel.text = "";
            ButtonRefuseLabel.text = "";
            ButtonConfirmLabel.text = ButtonConfirmText;
            ButtonRefuseLabel.text = ButtonRefuseText;
            DialogArea.SetActive(true);
            interacted = true;
            Tmp.text = "";
            timesInteractedWith++;
            OnInteract(DialogContent);
            GlobalVariables.DialogAreaOpen = true;
        }

        else if (interacted == true && Input.GetKeyDown("e"))
        {
            GlobalVariables.DialogAreaOpen = false;
            Tmp.text = "";
            StartCoroutine(PopUpChange(Tmp, popUpText));
            DialogArea.SetActive(false);
            interacted = false;
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PopUpChange(Tmp, popUpText));
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Tmp.text = "";
            interacted = false;
            DialogArea.SetActive(false);
            GlobalVariables.DialogAreaOpen = false;

        }
    }
    protected virtual void OnInteract(string DialogContent)
    {
        DialogTmp.text = "";
        StartCoroutine(PopUpChange(DialogTmp, DialogContent));
    }

    protected virtual void OnInteract(int optionChoosen, GameObject collidedObject)
    {

    }
    protected virtual void OnInteract(int optionChoosen)
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
