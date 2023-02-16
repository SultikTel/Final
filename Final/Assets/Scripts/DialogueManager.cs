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
    public void StartDialogue()
    {
        dialogue.text = sentences[index];

    }
    // Update is called once per frame
    void Update()
    {
    }
}
