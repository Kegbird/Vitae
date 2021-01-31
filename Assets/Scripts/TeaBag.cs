using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeaBag : MonoBehaviour
{
    [SerializeField]
    public Image teabag;
    [SerializeField]
    public Image cup;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public Image mask;
    [SerializeField]
    public GameHolder holder;
    [SerializeField]
    public bool task_completed;

    public void ShowTeaBag()
    {
        IEnumerator ShowTeaBag()
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                teabag.color = new Color(1, 1, 1, i);
                cup.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = true;
            mask.raycastTarget = true;
            teabag.raycastTarget = true;
        }
        if (task_completed)
            return;
        StartCoroutine(ShowTeaBag());
    }

    public void HideTeaBag()
    {
        holder.SetEndMinigame();
        task_completed = true;
        IEnumerator HideTeaBag()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                cup.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
            mask.raycastTarget = false;
            teabag.raycastTarget = false;
        }
        StartCoroutine(HideTeaBag());
    }
}
