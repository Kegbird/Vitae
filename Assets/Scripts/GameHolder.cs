﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameHolder : MonoBehaviour
{
    bool[] checkEnd = new bool[4];
    Scene currentScene;
    [SerializeField] GameObject backPictureButton;
    [SerializeField] GameObject backPictureGirlfriendButton;
    [SerializeField] Image blackScreen;
    [SerializeField] Image picture;
    [SerializeField] Image pictureGirlfriend;
    [SerializeField] Sprite defaultbackGround;
    [SerializeField] Image backGround;
    [SerializeField] Dialogue drawbookDialog;
    [SerializeField] Dialogue figureDialog;
    [SerializeField] Dialogue abacusDialog;
    [SerializeField] Dialogue pictureDialog;
    [SerializeField] Dialogue pictureGirlfriendDialog;
    [SerializeField] DialogueManager dialogMng;
    [SerializeField] Drawbook drawbook;
    [SerializeField] TradingCard tradingCard;
    [SerializeField] Abacus abacus;
    [SerializeField] Guitar guitar;
    [SerializeField]
    int game_completed = 0;
    [SerializeField]
    int things_to_do;


    void Start()
    {
        dialogMng.ResetDialogue();
        BlackScreenEditor();
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogMng.ReadLine();
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
            SceneChanger();
        }
    }

    public void SetEndMinigame()
    {
        backGround.sprite = defaultbackGround;
        game_completed++;
        if(game_completed==things_to_do)
        {
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(5f);
                FadingOut();
            }

            StartCoroutine(Delay());
        }
    }

    public void DrawbookBtnClick()
    {
        drawbook.ShowDrawbook();
        dialogMng.LoadDialogue(drawbookDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void DrawbookBtnOver(Sprite bcg)
    {
        backGround.sprite = bcg;
    }

    public void DrawbookBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void PictureBtnClick()
    {
        picture.gameObject.SetActive(true);
        backPictureButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(pictureDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void PictureBackBtnClick()
    {
        backPictureButton.gameObject.SetActive(false);
        picture.gameObject.SetActive(false);
        StopAllCoroutines();
        dialogMng.StopAllCoroutines();
        dialogMng.ResetDialogue();
        dialogMng.CloseDialogue();
        SetEndMinigame();
    }

    public void PictureBtnOver(Sprite bcg)
    {
        backGround.sprite = bcg;
    }

    public void PictureBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void FigureBookBtnClick()
    {
        tradingCard.ShowTradingCard();
        dialogMng.LoadDialogue(figureDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void FigureBookBtnOver(Sprite bcg)
    {
        backGround.sprite = bcg;
    }

    public void FigureBookBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void AbacusBtnClick()
    {
        abacus.ShowAbacus();
        dialogMng.LoadDialogue(abacusDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void AbacusBtnOver(Sprite bcg)
    {
        backGround.sprite = bcg;
    }

    public void AbacusBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void GuitarBtnClick()
    {
        guitar.ShowGuitar();
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }

    public void GuitarBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }

    public void GuitarBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void PictureGirlfriendBackBtnClick()
    {
        pictureGirlfriend.gameObject.SetActive(false);
        backPictureGirlfriendButton.gameObject.SetActive(false);
        StopAllCoroutines();
        dialogMng.StopAllCoroutines();
        dialogMng.ResetDialogue();
        dialogMng.CloseDialogue();
        SetEndMinigame();
    }

    public void PictureGirlfriendBtnClick()
    {
        pictureGirlfriend.gameObject.SetActive(true);
        backPictureGirlfriendButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(pictureGirlfriendDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void PictureGirlfriendBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }

    public void PictureGirlfirendBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void summerButton3()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }
    public void summerButton4()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }
    public void fallButton1()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton2()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton3()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton4()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton1()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton2()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton3()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton4()
    {
        /*if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);*/
        //dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }



    public void CheckEndInt()
    {
        bool endOfGame = true;

        for (int i = 0; i < checkEnd.Length && endOfGame; i++)
        {
            if (!checkEnd[i])
            {
                endOfGame = false;
            }
        }

        if (endOfGame)
        {
            //cose da inserire quando si finisce il livello,quindi il scene changer
            //backButton.gameObject.SetActive(false);
            FadingOut();
        }
    }

    public void SceneChanger()
    {
        switch (currentScene.name)
        {
            case "Primavera":
                SceneManager.LoadScene("Estate");
                break;

            case "Estate":
                break;

            case "Autunno":
                break;

            case "Inverno":
                break;

        }
    }
}

