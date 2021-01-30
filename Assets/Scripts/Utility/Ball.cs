using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IDragHandler
{
    public Transform minTransform;
    public Transform maxTransform;

    public void OnDrag(PointerEventData eventData)
    {
        float y = transform.position.y;
        float x =  Input.mousePosition.x;
        transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, minTransform.transform.position.x, maxTransform.transform.position.x), y);
    }
}
