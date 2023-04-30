using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue (Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
