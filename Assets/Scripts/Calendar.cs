using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    [SerializeField]
    public int event_placed = 0;
    [SerializeField]
    public bool task_completed;
    [SerializeField]
    public Image calendar_panel;
    [SerializeField]
    public Image[] calendar_event;
    [SerializeField]
    public Image[] calendar_slots;
    [SerializeField]
    public bool[] taken_slots;
    [SerializeField]
    public GameObject grabbed;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public bool pressing;
    [SerializeField]
    DialogueManager dialogue_manager;
    [SerializeField]
    Dialogue end_dialogue;

    private void Awake()
    {
        taken_slots =new bool[]{ false, false, false, false};
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowCalendar();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            HideCalendar();
        }

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

    public bool IsOverCalendarSlot()
    {
        for (int i = 0; i < calendar_slots.Length; i++)
        {
            if (Vector3.Distance(calendar_slots[i].transform.position, grabbed.transform.position) < 85f && !taken_slots[i])
                return true;
        }
        return false;
    }

    public void ApplyCalendarEvent()
    {
        for (int i = 0; i < calendar_slots.Length; i++)
        {
            if ((Vector3.Distance(calendar_slots[i].transform.position, grabbed.transform.position) < 85f) && !taken_slots[i])
            {
                calendar_slots[i].sprite = calendar_event[i].sprite;
                taken_slots[i] = true;
                event_placed++;
                if (event_placed == Constants.NUMBER_EVENT_SLOTS)
                {
                    dialogue_manager.LoadDialogue(end_dialogue);
                    dialogue_manager.ShowDialogue();
                    dialogue_manager.ReadLine();
                    task_completed = true;
                    StartCoroutine(WaitEndDialogue());
                }
                grabbed = null;
                return;
            }
        }
    }
    
    IEnumerator WaitEndDialogue()
    {
        yield return new WaitUntil(() => !dialogue_manager.dialogue_box_visible);
        HideCalendar();
    }

    public void ShowCalendar()
    {
        IEnumerator ShowCalendar()
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                calendar_panel.color = new Color(1, 1, 1, i);
                calendar_event[0].color = new Color(1, 1, 1, i);
                calendar_event[1].color = new Color(1, 1, 1, i);
                calendar_event[2].color = new Color(1, 1, 1, i);
                calendar_event[3].color = new Color(1, 1, 1, i);
                calendar_event[4].color = new Color(1, 1, 1, i);
                calendar_slots[0].color = new Color(1, 1, 1, i);
                calendar_slots[1].color = new Color(1, 1, 1, i);
                calendar_slots[2].color = new Color(1, 1, 1, i);
                calendar_slots[3].color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = true;
        }
        StartCoroutine(ShowCalendar());
    }

    public void HideCalendar()
    {
        IEnumerator HideLetter()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                calendar_panel.color = new Color(1, 1, 1, i);
                calendar_event[0].color = new Color(1, 1, 1, i);
                calendar_event[1].color = new Color(1, 1, 1, i);
                calendar_event[2].color = new Color(1, 1, 1, i);
                calendar_event[3].color = new Color(1, 1, 1, i);
                calendar_event[4].color = new Color(1, 1, 1, i);
                calendar_slots[0].color = new Color(1, 1, 1, i);
                calendar_slots[1].color = new Color(1, 1, 1, i);
                calendar_slots[2].color = new Color(1, 1, 1, i);
                calendar_slots[3].color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
            event_placed = 0;
        }
        StartCoroutine(HideLetter());
    }
}
