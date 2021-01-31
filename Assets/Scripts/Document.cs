using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class Document : MonoBehaviour
{
    [SerializeField]
    public Sprite[] pages;
    [SerializeField]
    public Image page;
    [SerializeField]
    public int index;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public Dialogue dialogue;
    [SerializeField]
    public GameHolder holder;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    public bool playing;

    public void ShowDocuments()
    {
        page.gameObject.SetActive(true);
        page.sprite = pages[0];
        playing = true;
    }

    public void HideDocuments()
    {
        index = 0;
        playing = false;
        dialogueManager.LoadDialogue(dialogue);
        dialogueManager.ShowDialogue();
        dialogueManager.ReadLine();
        holder.SetEndMinigame();
        page.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                pressing = true;
            }
            if (Input.GetMouseButtonUp(0) && pressing)
            {
                pressing = false;
                index++;
                if(index==Constants.DOCUMENTS)
                    HideDocuments();
                page.sprite = pages[index];
            }
        }
    }
}
