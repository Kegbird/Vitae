using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class TutorialHandler : MonoBehaviour
{
    bool permit = false;
    [SerializeField] Image blackScreen;

    public void Start()
    {
        BlackScreenEditor();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && permit)
        {
            FadingOut();
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
            SceneManager.LoadScene("Primavera");
        }
    }  
}
