using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogHandler : Interactable
{

    [SerializeField] public TextMeshProUGUI DialogTmp;
    [TextArea] public string DialogContent;
    protected override void OnInteract()
    {
       DialogTmp.text = DialogContent;
    }
}
