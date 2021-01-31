using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class Credits : MonoBehaviour
{
    int counterSpace = 0;
    [SerializeField] Image blackScreen;
    [SerializeField] Image credits;
    [SerializeField] Image fin;
    bool permit = false;

    public void Start()
    {
        BlackScreenEditor();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && permit)
        {
            counterSpace++;
        }

        switch (counterSpace)
        {
            case 0:
                fin.color = new Color(credits.color.r, credits.color.g, credits.color.b, 0);
                break;

            case 1:
                fin.color = new Color(credits.color.r, credits.color.g, credits.color.b, 1);
                credits.color = new Color(credits.color.r, credits.color.g, credits.color.b, 0);
                break;
            case 2:
                FadingOut();
                break;
        }
    }

    public void BlackScreenEditor()
    {
        StartCoroutine(BlackScreenEditor());

        IEnumerator BlackScreenEditor()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                blackScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
            permit = true;
        }
    }

    public void FadingOut()
    {
        StartCoroutine(AppearBlackScreen());
        IEnumerator AppearBlackScreen()
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                blackScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
            Application.Quit();
        }
    }
}

