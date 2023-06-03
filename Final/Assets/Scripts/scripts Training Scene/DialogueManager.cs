using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Text dialogue;
    public string[] sentences;
    float speedText = 2f;
    public AudioClip[] clips;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }
    void Update()
    {
        EnterNewText();
    }

    IEnumerator TypeSentences()
    {
        foreach(char c in sentences[index].ToCharArray())
        {   
            dialogue.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void StartDialogue()
    {
        dialogue.text = string.Empty;
        index = 0;
        StartCoroutine(TypeSentences());
        audioSource.PlayOneShot(clips[index]);
    }

    public void NextSentences()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            StartCoroutine(TypeSentences());
            audioSource.PlayOneShot(clips[index]);
        }else 
        {
            gameObject.SetActive(false);
        }
    }
    public void EnterNewText()
    {
        if(dialogue.text.Length == sentences[index].Length)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
               print("Enter is working");
               NextSentences();
            }
        }
        else {
            StopAllCoroutines();
            dialogue.text = sentences[index];
        }
    }
}
