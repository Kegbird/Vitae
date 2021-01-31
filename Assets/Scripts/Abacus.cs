using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Abacus : MonoBehaviour
{
    public GameObject top;
    public GameObject mid;
    public GameObject bottom;
    public GameObject[] redBalls;
    public GameObject[] orangeBalls;
    public GameObject[] blueBalls;
    [SerializeField]
    public int[] left_numbers;
    [SerializeField]
    public int[] right_numbers;
    [SerializeField]
    public Image abacus;
    [SerializeField]
    public bool playing;
    [SerializeField]
    public bool task_completed;
    [SerializeField]
    public DialogueManager dialogueManager;
    [SerializeField]
    public Dialogue endDialogue;
    [SerializeField]
    public GameHolder gameholder;


    private void Awake()
    {
        redBalls = new GameObject[Constants.BALLS];
        orangeBalls = new GameObject[Constants.BALLS];
        blueBalls = new GameObject[Constants.BALLS];

        for (int i = 0; i < Constants.BALLS; i++)
        {
            redBalls[i] = top.transform.GetChild(i).gameObject;
            orangeBalls[i] = mid.transform.GetChild(i).gameObject;
            blueBalls[i] = bottom.transform.GetChild(i).gameObject;
        }
    }

    public void ShowAbacus()
    {
        IEnumerator ShowAbacus()
        {
            for (int j = 0; j < Constants.BALLS; j++)
            {
                redBalls[j].SetActive(true);
                orangeBalls[j].SetActive(true);
                blueBalls[j].SetActive(true);
            }
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                abacus.color = new Color(1, 1, 1, i);
                abacus.raycastTarget = true;
                for (int j = 0; j < Constants.BALLS; j++)
                {
                    redBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    redBalls[j].GetComponent<Image>().raycastTarget = true;
                    orangeBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    orangeBalls[j].GetComponent<Image>().raycastTarget = true;
                    blueBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    blueBalls[j].GetComponent<Image>().raycastTarget = true;

                }
                yield return null;
            }
            playing = true;
        }
        StartCoroutine(ShowAbacus());
        StartCoroutine(CheckWinCondition());
    }

    public void HideAbacus()
    {
        IEnumerator HideAbacus()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                abacus.color = new Color(1, 1, 1, i);
                abacus.raycastTarget = false;
                for (int j = 0; j < Constants.BALLS; j++)
                {
                    redBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    redBalls[j].GetComponent<Image>().raycastTarget = false;
                    orangeBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    orangeBalls[j].GetComponent<Image>().raycastTarget = false;
                    blueBalls[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                    blueBalls[j].GetComponent<Image>().raycastTarget = false;
                }
                yield return null;
            }
            for (int j = 0; j < Constants.BALLS; j++)
            {
                redBalls[j].SetActive(false);
                orangeBalls[j].SetActive(false);
                blueBalls[j].SetActive(false);
            }
            playing = false;
            gameholder.SetEndMinigame();
        }
        task_completed = true;
        StartCoroutine(HideAbacus());
    }

    IEnumerator CheckWinCondition()
    {
        while (true)
        {
            int leftcount = 0;
            int rightcount = 0;

            for (int i = 0; i < Constants.BALLS; i++)
            {
                if (redBalls[i].transform.position.x > (Screen.width / 2f))
                    rightcount++;
                else
                    leftcount++;
            }

            if (leftcount != left_numbers[0] && rightcount != right_numbers[0])
            {
                yield return new WaitForSeconds(1f);
                continue;
            }

            rightcount = leftcount = 0;
            for (int i = 0; i < Constants.BALLS; i++)
            {
                if (orangeBalls[i].transform.position.x > (Screen.width / 2f))
                    rightcount++;
                else
                    leftcount++;
            }

            if (leftcount != left_numbers[1] && rightcount != right_numbers[1])
            {
                yield return new WaitForSeconds(1f);
                continue;
            }

            rightcount = leftcount = 0;
            for (int i = 0; i < Constants.BALLS; i++)
            {
                if (blueBalls[i].transform.position.x > (Screen.width / 2f))
                    rightcount++;
                else
                    leftcount++;
            }

            if (leftcount == left_numbers[2] && rightcount == right_numbers[2])
            {
                HideAbacus();
                break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
