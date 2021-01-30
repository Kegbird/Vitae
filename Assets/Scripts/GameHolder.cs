using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameHolder : MonoBehaviour
{
    GameObject[] popUpButtons;
    Button backButton;
    Image popUp;
    bool[] checkEnd = new bool[4];
    Scene currentScene;
    [SerializeField] Image blackScreen;
    [SerializeField] Dialogue button1Dialog;
    [SerializeField] Dialogue button2Dialog;
    [SerializeField] Dialogue button3Dialog;
    [SerializeField] Dialogue button4Dialog;
    [SerializeField] DialogueManager dialogMng;


    void Start()
    {
        dialogMng.ResetDialogue();
        BlackScreenEditor();
        currentScene = SceneManager.GetActiveScene();
        GameObject app = GameObject.FindGameObjectWithTag("BackButton");
        if (app != null)
            backButton = app.GetComponent<Button>();
        backButton.gameObject.SetActive(false);

        popUpButtons = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButtons[0] == null || popUpButtons[1] == null || popUpButtons[2] == null || popUpButtons[3] == null)
        {
            Application.Quit();
        }



        GameObject popUpHelp = GameObject.FindGameObjectWithTag("PopUp");
        if (popUpHelp != null)
            popUp = popUpHelp.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (dialogMng.avaiableRead)
            {
                dialogMng.ReadLine();
            }

        }
    }

    public void BlackScreenEditor()
    {
        StartCoroutine(BlackScreenEditor());

        IEnumerator BlackScreenEditor()
        {
            for(float i=1; i>=0; i -= Time.deltaTime)
            {
                blackScreen.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.02f);
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
                yield return new WaitForSeconds(0.04f);
            }
            SceneChanger();
        }
    }

    public void SetEndMinigame()
    {
        bool changeDone = false;
        for(int i=0; i<checkEnd.Length && !changeDone; i++)
        {
            if (!checkEnd[i])
            {
                checkEnd[i] = true;
                changeDone = true;
            }
        }
    }

    public void BackButton()
    {
        backButton.gameObject.SetActive(false);
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0f);
        if(!(dialogMng.dialogue_text.text == ""))
            dialogMng.CloseDialogue();
        dialogMng.ResetDialogue();
        CheckEndInt();
    }

    public void springButton1()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();

    }
    public void springButton2()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void springButton3()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void springButton4()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void summerButton1()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void summerButton2()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void summerButton3()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void summerButton4()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton1()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton2()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton3()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void fallButton4()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button4Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton1()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        popUpButtons[0].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button1Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton2()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[1].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button2Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton3()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[2].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button3Dialog);
        dialogMng.ShowDialogue();
        dialogMng.ReadLine();
        SetEndMinigame();
    }
    public void winterButton4()
    {
        if (backButton.gameObject.activeInHierarchy)
            return;
        popUpButtons[3].GetComponent<Button>().interactable = false;
        backButton.gameObject.SetActive(true);
        dialogMng.LoadDialogue(button4Dialog);
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
            backButton.gameObject.SetActive(false);
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

