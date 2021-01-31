using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class TutorialHandler : MonoBehaviour
{
    GameObject[] canvases;
    GameObject[] intButtons;
    [SerializeField] Image screenDiag;
    [SerializeField] Image screenUpDown;
    [SerializeField] Image screenDragDrop;
    [SerializeField] Image screenSwipe;
    [SerializeField] Dialogue tutDialogo;
    [SerializeField] Dialogue tutSwipe;
    [SerializeField] Dialogue tutDragDrop;
    [SerializeField] Dialogue tutUpDown;
    [SerializeField] DialogueManager dlgMng;

    public void Start()
    {
        canvases[0].SetActive(false); //TutorialUpDown
        canvases[1].SetActive(false); //Tutorial Drag Drop
        canvases[2].SetActive(false); //Tutorial Dialog
        canvases[3].SetActive(false); //Tutorial Swap
        BlackScreenEditor(screenDiag, canvases[2]);

        intButtons = GameObject.FindGameObjectsWithTag("InteractButton");
        canvases = GameObject.FindGameObjectsWithTag("Canvas");
        if (intButtons[0] == null || intButtons[1] == null) //|| popUpButtons[2] == null || popUpButtons[3] == null)
        {
            Application.Quit();
        }
        intButtons[1].SetActive(false);

        if (canvases[0] == null || canvases[1] == null || canvases[2] == null || canvases[3] == null)
        {
            Application.Quit();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dlgMng.ReadLine();

        }
    }

    public void BlackScreenEditor(Image blackScreenApp, GameObject canvasToActive)
    {
        StartCoroutine(BlackScreenEditor(blackScreenApp, canvasToActive));

        IEnumerator BlackScreenEditor(Image blackModifier, GameObject canvasToUse)
        {
            canvasToUse.SetActive(true);
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                blackModifier.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.005f);
            }
        }
    }
    public void FadingOut(Image blackScreen, GameObject canvasType, GameObject nextCanvas)
    {
        StartCoroutine(AppearBlackScreen(blackScreen, canvasType, nextCanvas));
        IEnumerator AppearBlackScreen(Image blackScreenAppl, GameObject canvasTypes, GameObject nextCanvases)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                blackScreenAppl.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.005f);
            }
            canvasTypes.SetActive(false);
            nextCanvases.SetActive(true);

        }
    }

    public void btnDialog()
    {
        intButtons[0].SetActive(false);
        dlgMng.ResetDialogue();
        dlgMng.LoadDialogue(tutDialogo);
        dlgMng.ShowDialogue();
        dlgMng.ReadLine();
        intButtons[1].SetActive(true);
    }

    public void Continue1()
    {
        intButtons[1].SetActive(false);
        FadingOut(screenDiag, canvases[0], canvases[1]);
        LoadUpDown();
    }

    public void LoadUpDown()
    {
        BlackScreenEditor(screenUpDown, canvases[0]);
    }




    public void GameStart()
    {
        SceneManager.LoadScene("Primavera");
    }
}
