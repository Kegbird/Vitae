using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Tinder : MonoBehaviour
{
    [SerializeField]
    public Sprite[] girls;
    [SerializeField]
    public Image phone;
    [SerializeField]
    public Image girlpic;
    [SerializeField]
    public Image notification;
    [SerializeField]
    public Sprite dislike;
    [SerializeField]
    public Sprite like;
    [SerializeField]
    public int girls_seen;
    [SerializeField]
    public GameHolder gameHolder;
    [SerializeField]
    public Dialogue endDialogue;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    public Vector3 start;
    [SerializeField]
    public Vector3 end;

    public void ShowTinder()
    {
        phone.gameObject.SetActive(true);
        girlpic.gameObject.SetActive(true);
        notification.gameObject.SetActive(true);
        girlpic.sprite = girls[0];
        playing = true;
        girls_seen = 0;
    }

    private void Update()
    {
        if (playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pressing = true;
                start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0) && pressing)
            {
                pressing = false;
                end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ElaborateSwipe(end - start);
            }
        }
    }

    public void ElaborateSwipe(Vector2 direction)
    {
        if (direction.x > 0)
            notification.sprite = like;
        else
            notification.sprite = dislike;
        IEnumerator animation()
        {
            LeanTween.scale(notification.gameObject, new Vector3(4, 4, 0), 1f);
            yield return new WaitForSeconds(1f);
            LeanTween.scale(notification.gameObject, new Vector3(0, 0, 0), 1f);
        }
        StartCoroutine(animation());
        girls_seen++;

        if (girls_seen == Constants.GIRLS)
        {
            HideTinder();
            return;
        }
        girlpic.sprite = girls[girls_seen];
    }

    public void HideTinder()
    {
        playing = false;
        phone.gameObject.SetActive(false);
        girlpic.gameObject.SetActive(false);
        notification.gameObject.SetActive(false);
        girlpic.sprite = girls[0];
        playing = true;
        girls_seen = 0;
        gameHolder.SetEndMinigame();
        dialogueManager.ResetDialogue();
        dialogueManager.LoadDialogue(endDialogue);
        dialogueManager.ShowDialogue();
    }
}
