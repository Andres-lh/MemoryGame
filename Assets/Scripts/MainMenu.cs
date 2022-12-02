using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI menuText;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject creditsText;
    [SerializeField] private GameObject creditsPanel;

    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void EnterCredits()
    {
        menuText.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);

        creditsText.gameObject.SetActive(true);
        creditsPanel.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        menuText.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(true);

        creditsText.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(false );
    }
}

