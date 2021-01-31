using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UserAgreement : MonoBehaviour
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
    public Image user_agreement;
    [SerializeField]
    public int page_scrolled;
    [SerializeField]
    public Sprite[] pages;
    [SerializeField]
    public int node;
    [SerializeField]
    public GameHolder holder;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public Dialogue dialogueEnd;
    [SerializeField]
    public bool task_done;
    [SerializeField]
    public Image mask;

    private void Update()
    {
        if (playing && !task_done)
        {
            if(Input.GetMouseButtonUp(0) && pressing)
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
                    page_scrolled++;
                    if (page_scrolled == Constants.PAGE_TO_SCROLL)
                    {
                        HideUserAgreement();
                        return;
                    }
                    user_agreement.sprite = pages[page_scrolled];
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
        if (node == 0)
            node = 1;
        else
            node = 0;
        anchors[node].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        beginning_distance = Vector3.Distance(Camera.main.WorldToScreenPoint(Input.mousePosition), Camera.main.WorldToScreenPoint(anchors[node].transform.position));
        pressing = true;
    }

    private void DisappearPoint()
    {
        anchors[node].GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public void ShowUserAgreement()
    {
        IEnumerator ShowUserAgreement()
        {
            user_agreement.sprite = pages[0];
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                user_agreement.color = new Color(1, 1, 1, i);
                yield return null;
            }
            mask.raycastTarget = true;
            playing = true;
        }
        if (task_done)
            return;
        StartCoroutine(ShowUserAgreement());
    }

    public void HideUserAgreement()
    {
        task_done = true;
        dialogueManager.ResetDialogue();
        dialogueManager.LoadDialogue(dialogueEnd);
        dialogueManager.ShowDialogue();
        dialogueManager.ReadLine();
        holder.SetEndMinigame();

        IEnumerator HideUserAgreement()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                user_agreement.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
            mask.raycastTarget = false;
            page_scrolled = 0;
        }
        StartCoroutine(HideUserAgreement());
    }
}
