using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts;

namespace Assets.Scripts.Utility
{
    public class Figure : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public Vector3 reset_position;
        public TradingCard trading_card;
        //This is the id of the array in trading card
        public int id;

        void Awake()
        {
            reset_position = transform.localPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            trading_card.grabbed = this.gameObject;
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (trading_card.IsOverSlot(id))
                trading_card.ApplyFigure(id);
            transform.localPosition = reset_position;
        }
    }
}
