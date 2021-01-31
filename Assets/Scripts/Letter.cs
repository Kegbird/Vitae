using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{

    [SerializeField]
    public GameObject[] anchors;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    public float beginning_distance;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public Image letter;
    [SerializeField]
    public int fragment_written;
    [SerializeField]
    public Sprite[] fragments;
    [SerializeField]
    public int node;
    [SerializeField]
    public Sprite indicator;
    [SerializeField]
    public bool task_completed;
    [SerializeField]
    public Dialogue[] dialogues;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public GameHolder holder;

    private void Update()
    {
        if (playing && !task_completed)
        {
            if (Input.GetMouseButtonUp(0) && pressing)
            {
                pressing = false;
                DisappearPoint();
            }
            else if (Input.GetMouseButton(0) && pressing)
            {
                float proximity = 1f - (Vector3.Distance(Camera.main.WorldToScreenPoint(Input.mousePosition), Camera.main.WorldToScreenPoint(anchors[node].transform.position)) / beginning_distance);
                if (proximity > .9f)
                {
                    pressing = false;
                    DisappearPoint();
                    fragment_written++;
                    if (fragment_written == Constants.FRAGMENT_TO_WRITE)
                    {
                        task_completed = true;
                        HideLetter();
                        return;
                    }
                    else
                    {
                        dialogueManager.ResetDialogue();
                        dialogueManager.LoadDialogue(dialogues[fragment_written-1]);
                        dialogueManager.ShowDialogue();
                        dialogueManager.ReadLine();
                    }
                    letter.sprite = fragments[fragment_written];
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                GeneratePoint();
            }
        }
    }

    private void GeneratePoint()
    {
        node = Random.Range(0, Constants.ANCHOR_LETTER_FRAGMENT_NUMBER);
        anchors[node].GetComponent<Image>().sprite = indicator;
        anchors[node].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        beginning_distance = Vector3.Distance(Camera.main.WorldToScreenPoint(Input.mousePosition), Camera.main.WorldToScreenPoint(anchors[node].transform.position));
        pressing = true;
    }

    private void DisappearPoint()
    {
        anchors[node].GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public void ShowLetter()
    {
        IEnumerator ShowLetter()
        {
            if(task_completed)
                letter.sprite = fragments[Constants.FRAGMENT_TO_WRITE-1];
            else
                letter.sprite = fragments[0];
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                letter.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = true;
            letter.raycastTarget = true;
        }
        if (task_completed)
            return;
        StartCoroutine(ShowLetter());
    }

    public void HideLetter()
    {
        holder.SetEndMinigame();
        letter.sprite = fragments[0];
        IEnumerator HideLetter()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                letter.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
            fragment_written = 0;
            letter.raycastTarget = false;
        }
        StartCoroutine(HideLetter());
    }
}
