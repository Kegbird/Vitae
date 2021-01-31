using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guitar : MonoBehaviour
{
    [SerializeField]
    public GameObject[] left_anchors;
    [SerializeField]
    public GameObject[] right_anchors;
    [SerializeField]
    public GameObject dest_anchor;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    public float beginning_distance;
    [SerializeField]
    public bool task_completed;
    [SerializeField]
    public bool sketch_completed;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public Image guitar;
    [SerializeField]
    public int marker_index;
    [SerializeField]
    public int note_played;
    [SerializeField]
    public Sprite[] marker;
    [SerializeField]
    public AudioClip[] audio_clip;
    [SerializeField]
    public AudioSource audio_source;
    [SerializeField]
    public GameHolder game_holder;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public Dialogue endDialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowGuitar();
        }

        if (!task_completed && playing)
        {
            if (Input.GetMouseButtonUp(0) && pressing)
            {
                pressing = false;
                DisappearPoint();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                GeneratePoint();
            }
            else if (Input.GetMouseButton(0) && pressing)
            {
                float proximity = 1f - (Vector3.Distance(Camera.main.WorldToScreenPoint(Input.mousePosition), Camera.main.WorldToScreenPoint(dest_anchor.transform.position)) / beginning_distance);
                if (proximity > .9f)
                {
                    pressing = false;
                    audio_source.clip = audio_clip[note_played];
                    audio_source.Play();
                    note_played++;
                    if (note_played == Constants.NOTE_TO_PLAY)
                    {
                        task_completed = true;
                        HideGuitar();
                    }
                    DisappearPoint();
                }
            }
        }
    }

    public void ShowGuitar()
    {
        IEnumerator ShowGuitar()
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                guitar.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = true;
        }
        StartCoroutine(ShowGuitar());
    }

    public void HideGuitar()
    {
        dialogueManager.ResetDialogue();
        dialogueManager.LoadDialogue(endDialogue);
        dialogueManager.ShowDialogue();

        IEnumerator HideGuitar()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                guitar.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
            note_played = 0;
            game_holder.SetEndMinigame();
        }
        StartCoroutine(HideGuitar());
    }

    public void GeneratePoint()
    {
        marker_index = Random.Range(0, Constants.ANCHOR_GUITAR_NUMBER);
        if (Input.mousePosition.x > Screen.width/2)
        {
            dest_anchor = left_anchors[marker_index];
        }
        else
        {
            dest_anchor = right_anchors[marker_index];
        }
        
        beginning_distance = Vector3.Distance(Camera.main.WorldToScreenPoint(Input.mousePosition), Camera.main.WorldToScreenPoint(dest_anchor.transform.position));
        dest_anchor.GetComponent<Image>().sprite = marker[note_played];
        dest_anchor.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        pressing = true;
    }

    public void DisappearPoint()
    {
        if(dest_anchor!=null)
            dest_anchor.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
}
