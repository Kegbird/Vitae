using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    public class Bag : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public Vector3 reset_position;
        [SerializeField]
        public GameObject cup;
        [SerializeField]
        public Sprite cup_with_teabag;

        void Awake()
        {
            reset_position = transform.localPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(Vector3.Distance(cup.transform.position, transform.position)<=150f)
            {
                GetComponent<Image>().color = new Color(1, 1, 1, 0f);
                cup.GetComponent<Image>().sprite = cup_with_teabag;
            }
            transform.localPosition = reset_position;
        }
    }
}
