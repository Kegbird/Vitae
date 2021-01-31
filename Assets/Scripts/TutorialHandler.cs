using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class TutorialHandler : MonoBehaviour
{
    GameObject[] intButtons;
    [SerializeField] Image screenDiag;
    [SerializeField] Image screenMinigame;
    [SerializeField] Dialogue tutDialogo;
    [SerializeField] Dialogue tutMinigiochi;
    [SerializeField] Dialogue tutEnd;
    [SerializeField] DialogueManager dlgMng;
    [SerializeField] DialogueManager dlgMngMinigame;
    [SerializeField] Canvas canvasDialog;
    [SerializeField] Canvas canvasMinigame;

    public void Start()
    {
        intButtons = GameObject.FindGameObjectsWithTag("InteractButton");
        if (intButtons[0] == null || intButtons[1] == null)        
            Application.Quit();
        BlackScreenEditor(screenDiag);

        intButtons[2].SetActive(false);

        canvasMinigame.gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dlgMng.ReadLine();
        }
    }

    public void BlackScreenEditor(Image blackType)
    {
        StartCoroutine(BlackScreenEditor(blackType));

        IEnumerator BlackScreenEditor(Image blackScreen)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                blackScreen.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.01f);
            }         
        }
    }

    public void FadingOut(Image blackType)
    {
        StartCoroutine(AppearBlackScreen(blackType));
        IEnumerator AppearBlackScreen(Image blackScreen)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                blackScreen.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public void btnDialog()
    {
        dlgMng.LoadDialogue(tutDialogo);
        dlgMng.ShowDialogue();
        dlgMng.ReadLine();
        intButtons[1].SetActive(false);
        intButtons[2].SetActive(true);
    }

    public void Continue1()
    {
        StartCoroutine(FadingOutCustom());

        IEnumerator FadingOutCustom()
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                screenDiag.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1);
            canvasMinigame.gameObject.SetActive(true);
            intButtons[0].SetActive(false);
            canvasDialog.gameObject.SetActive(false);
            BlackScreenEditor(screenMinigame);
            dlgMngMinigame.ResetDialogue();
            yield return new WaitForSeconds(4);
            TutMinigames();
        }
    }

    public void TutMinigames()
    {
        intButtons[0].SetActive(true);
        dlgMngMinigame.LoadDialogue(tutMinigiochi);
        dlgMngMinigame.ShowDialogue();
        dlgMngMinigame.ReadLine();
    }

    public void Continue2()
    {
        dlgMngMinigame.ResetDialogue();
        dlgMngMinigame.LoadDialogue(tutEnd);
        dlgMngMinigame.ShowDialogue();
        dlgMngMinigame.ReadLine();
        intButtons[0].SetActive(false);
        StartCoroutine(FadingOutCustom2());
        IEnumerator FadingOutCustom2()
        {
            yield return new WaitForSeconds(5);
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                screenDiag.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Primavera");
        }
    }    
}
