using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text dialogue;
    public string[] sentences;
    public int index;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        dialogue.text = sentences[index];
        if(isActive){
         if(Input.GetKeyDown(KeyCode.L))
          {
            if(dialogue.text == sentences[index])
            {
                NextSentences();
            }else 
            dialogue.text = sentences[index];
          }
        }
    }
    public void StartDialogue()
    {
        gameObject.SetActive(true);
    }
    public void NextSentences()
    {
         if(index < sentences.Length - 1)
         {
            index++;
            dialogue.text = sentences[index];
         }else {
            gameObject.SetActive(false);
            index = 0;
         }
    }
}
