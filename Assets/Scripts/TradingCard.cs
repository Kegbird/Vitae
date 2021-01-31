using Assets.Scripts;
using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingCard : MonoBehaviour
{
    [SerializeField]
    public Image figure_panel;
    [SerializeField]
    public Image[] figures;
    [SerializeField]
    public Image[] figure_slots;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public bool task_completed;
    [SerializeField]
    public GameObject grabbed;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    public bool can_place;
    [SerializeField]
    public int placed;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public Dialogue dialogue;
    [SerializeField]
    public GameHolder gameholder;

    private void Update()
    {
        if (!task_completed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (grabbed != null)
                    pressing = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pressing = false;
            }
        }
    }

    public bool IsOverSlot(int id)
    {
        if (Vector3.Distance(figure_slots[id].transform.position, grabbed.transform.position) < 85f)
            return true;
        return false;
    }

    public void ApplyFigure(int id)
    {
        figure_slots[id].sprite = figures[id].sprite;
        figure_slots[id].color = new Color(1f, 1f, 1f, 1f);
        figures[id].color = new Color(1f, 1f, 1f, 0f);
        placed++;
        if (placed == Constants.NUMBER_FIGURE)
        {
            dialogueManager.ResetDialogue();
            dialogueManager.LoadDialogue(dialogue);
            dialogueManager.ShowDialogue();
            HideTradingCard();
            task_completed = true;
        }
    }

    public void ShowTradingCard()
    {
        IEnumerator ShowTradingCard()
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                figure_panel.color = new Color(1, 1, 1, i);
                for (int j = 0; j < Constants.NUMBER_FIGURE; j++)
                {
                    figures[j].color = new Color(1, 1, 1, i);
                }
                yield return null;
            }
            playing = true;
            figure_panel.GetComponent<Image>().raycastTarget = true;
        }
        StartCoroutine(ShowTradingCard());
    }

    public void HideTradingCard()
    {
        
        IEnumerator HideTradingCard()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                figure_panel.color = new Color(1, 1, 1, i);
                for (int j = 0; j < Constants.NUMBER_FIGURE; j++)
                {
                    figure_slots[j].color = new Color(1, 1, 1, i);
                }
                yield return null;
            }
            playing = true;
            task_completed = false;
            placed = 0;
            figure_panel.GetComponent<Image>().raycastTarget = false;
            gameholder.SetEndMinigame();
        }
        StartCoroutine(HideTradingCard());
    }
}
