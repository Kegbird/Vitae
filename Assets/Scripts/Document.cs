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
    [SerializeField]
    public bool task_done;

    public void ShowDocuments()
    {
        if (task_done)
            return;
        page.gameObject.SetActive(true);
        page.sprite = pages[0];
        playing = true;
    }

    public void HideDocuments()
    {
        task_done = true;
        index = 0;
        playing = false;
        holder.SetEndMinigame();
        page.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playing && !task_done)
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
