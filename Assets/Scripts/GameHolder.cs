using System.Collections;
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
    [SerializeField] GameObject backPictureMarriageBtn;
    [SerializeField] Image blackScreen;
    [SerializeField] Image picture;
    [SerializeField] Image pictureGirlfriend;
    [SerializeField] Image pictureMarriage;
    [SerializeField] Sprite defaultbackGround;
    [SerializeField] Image backGround;
    [SerializeField] Dialogue drawbookDialog;
    [SerializeField] Dialogue figureDialog;
    [SerializeField] Dialogue guitarDialog;
    [SerializeField] Dialogue pictureMarriageDialog;
    [SerializeField] Dialogue abacusDialog;
    [SerializeField] Dialogue pictureDialog;
    [SerializeField] Dialogue pictureEndDialog;
    [SerializeField] Dialogue pictureGirlfriendDialog;
    [SerializeField] Dialogue pictureGirlfriendEndDialog;
    [SerializeField] Dialogue tinderDialogue;
    [SerializeField] Dialogue userAgreementDialog;
    [SerializeField] Dialogue documentDialog;
    [SerializeField] DialogueManager dialogMng;
    [SerializeField] Drawbook drawbook;
    [SerializeField] TradingCard tradingCard;
    [SerializeField] Abacus abacus;
    [SerializeField] Guitar guitar;
    [SerializeField] Tinder tinder;
    [SerializeField] UserAgreement userAgreement;
    [SerializeField] Document document;
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
        dialogMng.LoadDialogue(pictureEndDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
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
        dialogMng.LoadDialogue(guitarDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
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
        pictureGirlfriend.raycastTarget = false;
        pictureGirlfriend.gameObject.SetActive(false);
        backPictureGirlfriendButton.gameObject.SetActive(false);
        dialogMng.ResetDialogue();
        dialogMng.LoadDialogue(pictureGirlfriendEndDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }

    public void PictureGirlfriendBtnClick()
    {
        pictureGirlfriend.raycastTarget = true;
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

    public void TelephoneBtnClick()
    {
        tinder.ShowTinder();
        dialogMng.LoadDialogue(tinderDialogue);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void TelephoneBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }
    public void TelephoneBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void MarriagePictureBtnClick()
    {
        pictureMarriage.gameObject.SetActive(true);
        backPictureMarriageBtn.gameObject.SetActive(true);
        dialogMng.LoadDialogue(pictureMarriageDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void MarriagePictureBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }

    public void MarriagePictureBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void PictureMarriageBackBtnClick()
    {
        backPictureMarriageBtn.gameObject.SetActive(false);
        pictureMarriage.gameObject.SetActive(false);
        StopAllCoroutines();
        dialogMng.StopAllCoroutines();
        dialogMng.ResetDialogue();
        dialogMng.CloseDialogue();
        SetEndMinigame();
    }

    public void UserAgreementBtnClick()
    {
        userAgreement.ShowUserAgreement();
        dialogMng.LoadDialogue(userAgreementDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void UserAgreementBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }

    public void UserAgreementBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }
    
    public void DocumentBtnClick()
    {
        dialogMng.LoadDialogue(documentDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        document.ShowDocuments();
    }

    public void DocumentBtnOver(Sprite bck)
    {
        backGround.sprite = bck;
    }

    public void DocumentBtnExit()
    {
        backGround.sprite = defaultbackGround;
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
                SceneManager.LoadScene("Autunno");
                break;
            case "Autunno":
                SceneManager.LoadScene("Inverno");
                break;
            case "Inverno":
                break;

        }
    }
}

