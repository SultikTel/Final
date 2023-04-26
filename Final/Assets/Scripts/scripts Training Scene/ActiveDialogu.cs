using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogu : MonoBehaviour
{
    public DialogueManager dialogue;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "soldier")
        {
            dialogue.StartDialogue();
            dialogue.isActive = true;
            this.gameObject.SetActive(false);
        }
    }
}
