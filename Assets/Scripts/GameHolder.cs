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
    [SerializeField] GameObject backPictureNewphenButton;
    [SerializeField] GameObject backPictureGirlfriendButton;
    [SerializeField] GameObject backPictureMarriageBtn;
    [SerializeField] Image blackScreen;
    [SerializeField] Image picture;
    [SerializeField] Image pictureGirlfriend;
    [SerializeField] Image pictureMarriage;
    [SerializeField] Image pictureNewphen;
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
    [SerializeField] Dialogue pictureNewphenDialog;
    [SerializeField] Dialogue pictureNewphenEndDialog;
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
    [SerializeField] TeaBag teaBag;
    [SerializeField] Letter letter;
    [SerializeField]
    public bool task_done;
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
        if (game_completed == things_to_do)
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
        if (drawbook.task_completed)
            return;
        drawbook.ShowDrawbook();
        dialogMng.LoadDialogue(drawbookDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void DrawbookBtnOver(Sprite bcg)
    {
        if (drawbook.task_completed)
            return;
        backGround.sprite = bcg;
    }

    public void DrawbookBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void PictureBtnClick()
    {
        if (task_done)
            return;
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
        task_done = true;
    }

    public void PictureBtnOver(Sprite bcg)
    {
        if (task_done)
            return;
        backGround.sprite = bcg;
    }

    public void PictureBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void FigureBookBtnClick()
    {
        if (tradingCard.task_completed)
            return;
        tradingCard.ShowTradingCard();
    }

    public void FigureBookBtnOver(Sprite bcg)
    {
        if (tradingCard.task_completed)
            return;
        backGround.sprite = bcg;
    }

    public void FigureBookBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void AbacusBtnClick()
    {
        if (abacus.task_completed)
            return;
        abacus.ShowAbacus();
    }

    public void AbacusBtnOver(Sprite bcg)
    {
        if (abacus.task_completed)
            return;
        backGround.sprite = bcg;
    }

    public void AbacusBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void GuitarBtnClick()
    {
        if (guitar.task_completed)
            return;
        guitar.ShowGuitar();
        dialogMng.LoadDialogue(guitarDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void GuitarBtnOver(Sprite bck)
    {
        if (guitar.task_completed)
            return;
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
        task_done = true;
    }

    public void PictureGirlfriendBtnClick()
    {
        if (task_done)
            return;
        pictureGirlfriend.raycastTarget = true;
        pictureGirlfriend.gameObject.SetActive(true);
        backPictureGirlfriendButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(pictureGirlfriendDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void PictureGirlfriendBtnOver(Sprite bck)
    {
        if(!task_done)
            backGround.sprite = bck;
    }

    public void PictureGirlfirendBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void TelephoneBtnClick()
    {
        if (tinder.task_done)
            return;
        tinder.ShowTinder();
        dialogMng.LoadDialogue(tinderDialogue);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void TelephoneBtnOver(Sprite bck)
    {
        if(!tinder.task_done)
            backGround.sprite = bck;
    }
    public void TelephoneBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void MarriagePictureBtnClick()
    {
        if (task_done)
            return;
        pictureMarriage.gameObject.SetActive(true);
        backPictureMarriageBtn.gameObject.SetActive(true);
        dialogMng.LoadDialogue(pictureMarriageDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void MarriagePictureBtnOver(Sprite bck)
    {
        if(!task_done)
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
        task_done = true;
    }

    public void UserAgreementBtnClick()
    {
        if (userAgreement.task_done)
            return;
        userAgreement.ShowUserAgreement();
        dialogMng.LoadDialogue(userAgreementDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }

    public void UserAgreementBtnOver(Sprite bck)
    {
        if(!userAgreement.task_done)
            backGround.sprite = bck;
    }

    public void UserAgreementBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }

    public void DocumentBtnClick()
    {
        document.ShowDocuments();
    }

    public void DocumentBtnOver(Sprite bck)
    {
        if(!document.task_done)
            backGround.sprite = bck;
    }

    public void DocumentBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }
    public void CupBtnClick()
    {
        teaBag.ShowTeaBag();
    }
    public void CupBtnEnter(Sprite bck)
    {
        if(!teaBag.task_completed)
            backGround.sprite = bck;
    }
    public void CupBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }
    public void PictureNewphenBackClick()
    {
        backPictureNewphenButton.SetActive(false);
        pictureNewphen.gameObject.SetActive(false);
        pictureNewphen.raycastTarget = false;
        dialogMng.LoadDialogue(pictureNewphenEndDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
        task_done = true;
    }
    public void PictureNewphenBtnClick()
    {
        if (task_done)
            return;
        backPictureNewphenButton.SetActive(true);
        pictureNewphen.gameObject.SetActive(true);
        pictureNewphen.raycastTarget = true;
        dialogMng.LoadDialogue(pictureNewphenDialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
    }
    public void PictureNewphenBtnOver(Sprite bck)
    {
        if (task_done)
            return;
        backGround.sprite = bck;
    }
    public void PictureNewphenBtnExit()
    {
        backGround.sprite = defaultbackGround;
    }
    public void LetterBtnClick()
    {
        letter.ShowLetter();
    }
    public void LetterBtnOver(Sprite bck)
    {
        if (letter.task_completed)
            return;
        backGround.sprite = bck;
    }
    public void LetterBtnEnd()
    {
        backGround.sprite = defaultbackGround;
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
                SceneManager.LoadScene("Credits");
                break;

        }
    }
}

