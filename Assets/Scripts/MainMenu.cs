using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public Image black_screen;
    [SerializeField]
    public bool interaction_enabled;

    private void Start()
    {
        FadeBlackScreen();
    }

    public void FadeBlackScreen()
    {
        IEnumerator FadeBlackScreen()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
            interaction_enabled = true;
        }

        StartCoroutine(FadeBlackScreen());
    }

    public void AppearBlackScreen()
    {
        interaction_enabled = false;
        IEnumerator AppearBlackScreen()
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        StartCoroutine(AppearBlackScreen());
    }

    public void PlayBtnClicked()
    {
        if (!interaction_enabled)
            return;

        IEnumerator Delay()
        {
            AppearBlackScreen();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(Constants.SPRING_SCENE);
        }
        StartCoroutine(Delay());
    }

    public void QuitBtnClicked()
    {
        if (!interaction_enabled)
            return;

        IEnumerator Delay()
        {
            AppearBlackScreen();
            yield return new WaitForSeconds(1f);
            Application.Quit();
        }
        StartCoroutine(Delay());
    }
}
