using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public string[] sentences;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dialogue.text == sentences[index])
            {
                NextSentences();
            }else 
            dialogue.text = sentences[index];
        }
    }
    public void StartDialogue()
    {
        dialogue.text = sentences[index];
    }
    public void NextSentences()
    {
         if(index < sentences.Length - 1)
         {
            index++;
            dialogue.text = sentences[index];
         }else {
            gameObject.SetActive(false);
         }
    }
    public void EndDialogue()
    {
        gameObject.SetActive(false);
    }
}
