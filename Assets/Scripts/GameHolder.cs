using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHolder : MonoBehaviour
{
    Button backButton;
    Image popUp;
    bool[] checkEnd = new bool[4];
    Scene currentScene;
    [SerializeField] Image blackScreen; 
    void Start()
    {
        BlackScreenEditor();
        currentScene = SceneManager.GetActiveScene();
        GameObject app = GameObject.FindGameObjectWithTag("BackButton");
        if (app != null)
            backButton = app.GetComponent<Button>();
        backButton.gameObject.SetActive(false);

        GameObject popUpHelp = GameObject.FindGameObjectWithTag("PopUp");
        if (popUpHelp != null)
            popUp = popUpHelp.GetComponent<Image>();
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
    }

    public void springButton1()
    {
        //link allo script del minigioco della primavera 1
        Debug.Log("Test che funziono1 - primavera");
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        backButton.gameObject.SetActive(true);
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void springButton2()
    {
        //link allo script del minigioco della primavera 2
        Debug.Log("Test che funziono2 - primavera");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void springButton3()
    {
        //link allo script del minigioco della primavera 3
        Debug.Log("Test che funziono3 - primavera");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void springButton4()
    {
        //link allo script del minigioco della primavera 4
        Debug.Log("Test che funziono4 - primavera");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void summerButton1()
    {
        Debug.Log("Test che funziono1 - estate");

        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        backButton.gameObject.SetActive(true);
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void summerButton2()
    {
        Debug.Log("Test che funziono2 - estate");

        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[1] != null)
        {
            Button buttonInt = popUpButton[1].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void summerButton3()
    {

        Debug.Log("Test che funziono3 - estate");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[2] != null)
        {
            Button buttonInt = popUpButton[2].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void summerButton4()
    {
        Debug.Log("Test che funziono4 - estate");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[3] != null)
        {
            Button buttonInt = popUpButton[3].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void fallButton1()
    {
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        backButton.gameObject.SetActive(true);
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void fallButton2()
    {
        Debug.Log("Test che funziono2 - autunno");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[1] != null)
        {
            Button buttonInt = popUpButton[1].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void fallButton3()
    {
        Debug.Log("Test che funziono3 - autunno");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[2] != null)
        {
            Button buttonInt = popUpButton[2].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void fallButton4()
    {
        Debug.Log("Test che funziono4 - autunno");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[3] != null)
        {
            Button buttonInt = popUpButton[3].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void winterButton1()
    {
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        backButton.gameObject.SetActive(true);
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[0] != null)
        {
            Button buttonInt = popUpButton[0].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void winterButton2()
    {
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[1] != null)
        {
            Button buttonInt = popUpButton[1].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void winterButton3()
    {
        Debug.Log("Test che funziono3 - inverno");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[2] != null)
        {
            Button buttonInt = popUpButton[2].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
    }
    public void winterButton4()
    {
        Debug.Log("Test che funziono4 - inverno");
        GameObject[] popUpButton = GameObject.FindGameObjectsWithTag("InteractButton");
        if (popUpButton[3] != null)
        {
            Button buttonInt = popUpButton[3].GetComponent<Button>();
            buttonInt.interactable = false;
        }

        SetEndMinigame();
        CheckEndInt();
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
            FadingOut();
            SceneChanger();
        }     
    }

    public void SceneChanger()
    {
        switch (currentScene.name)
        {
            case "Primavera":
                //SceneManager.LoadScene("Estate");
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

