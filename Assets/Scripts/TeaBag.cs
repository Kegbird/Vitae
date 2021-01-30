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

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
            ShowTeaBag();
        if (Input.GetKey(KeyCode.U))
            HideTeaBag();
    }

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
        }
        StartCoroutine(ShowTeaBag());
    }

    public void HideTeaBag()
    {
        IEnumerator HideTeaBag()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                cup.color = new Color(1, 1, 1, i);
                yield return null;
            }
            playing = false;
        }
        StartCoroutine(HideTeaBag());
    }
}
