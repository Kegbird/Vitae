using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightlightItems : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] Image popUp;
    [SerializeField] Button backButton;

    public void Start()
    {
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0f);
        backButton.gameObject.SetActive(false);
    }

    public void Highlighting()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0.7f);
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 1f);
        Debug.Log("ciao");
        backButton.gameObject.SetActive(true);
    }

    public void EndInteraction()
    {
        backButton.gameObject.SetActive(false);
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1f);
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0f);
    }
}
