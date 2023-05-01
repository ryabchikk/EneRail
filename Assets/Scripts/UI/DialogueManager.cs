using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Queue<string> sentences;
    [SerializeField] private Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue();
    }

    public void StartDialogue()
    {
        animator.SetBool("IsOpen", true);


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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        } 
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
