using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Event : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector3 reset_position;
    public Calendar calendar;
    

    void Awake()
    {
        reset_position = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        calendar.grabbed = this.gameObject;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (calendar.IsOverCalendarSlot())
        {
            calendar.ApplyCalendarEvent();
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        }
        transform.localPosition = reset_position;
    }
}
