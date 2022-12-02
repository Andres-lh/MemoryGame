using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    private Table _table;

    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioCorrect; 
    [SerializeField] AudioClip audioWrong;

    [Header("Particles")]
    [SerializeField] Particles particles;

    [Header("Panel")]
    [SerializeField] GameObject pnlPause;
    [SerializeField] GameObject pnlWin;
    [SerializeField] GameObject pnlDefeat;

    [SerializeField] TextMeshProUGUI textRemainingTiles;
    [SerializeField] TextMeshProUGUI textremainingAttempts;


    private bool _CanChosee=true;
    private Token LastChosen=null;

    [SerializeField] private int _RemainingTrys = 5;
    private void Awake()
    {
        Singleton();
        _table = GetComponent<Table>();  
    }

  

    void Start()
    {
        _table.StarTable();
        UpdateRemainingTokens();
        UpdateRemainingAttempts();
    }
    void Update()
    {
        
    }
    public void ProcessTokenClick(Token token)
    {
        if (!_CanChosee)
        {
            return;
        }

        if (!LastChosen)
        {
            FirstTokenChosen(token);
        }
        else
        {
            SecondTokenChosen(token);
        }
    }

    private void FirstTokenChosen(Token token)
    {
        LastChosen=token;
        token.ShowFront();
    }

    private void SecondTokenChosen(Token token)
    {
        if (token==LastChosen)
        {
            return;
        }
        token.ShowFront();
        if (token.Id == LastChosen.Id)
        {
            CorrectPair(token,LastChosen);

            
        }
        else
        {
            WrongPair(token, LastChosen);
        }
    }

    private void CorrectPair(Token token, Token lastChosen)
    {
        Destroy(token.gameObject, 1.5f);
        Destroy(lastChosen.gameObject, 1.5f);
      

        if (audioCorrect != null) { 
        audioSource.PlayOneShot(audioCorrect);
    }

        particles.GenerateParticles(token.transform);
        particles.GenerateParticles(lastChosen.transform);


        LastChosen = null;


        StartCoroutine(BlockChosen(1.5f));


        _table.cuantityTokens -= 2;
        UpdateRemainingTokens();

        if(_table.cuantityTokens <= 0)
        {
           
            pnlWin.SetActive(true);
          
        }


    }
    private void WrongPair(Token token, Token _lastChosen)
    {
        LastChosen = null;
        _RemainingTrys -= 1;
        UpdateRemainingAttempts();
        

        // TODO generate particleSysyem when player has not matched

        if (_RemainingTrys <= 0)
        {
            _CanChosee = false;
            pnlDefeat.SetActive(true); 
        }
        else
        {
            token.Invoke("ShowBack",1.5f);
            _lastChosen.Invoke("ShowBack", 1.5f);
            StartCoroutine(BlockChosen(1.5f));
        }
        if (audioWrong != null) { 
        audioSource.PlayOneShot(audioWrong);
        }
    }


    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BlockChosen(float time)
    {
        _CanChosee = false;
        yield return new WaitForSeconds(time);
        _CanChosee = true;
    }

    public void UpdateRemainingTokens()
    {
        if(textRemainingTiles != null)
        {
            textRemainingTiles.text ="Remaining Tokens: " + _table.cuantityTokens.ToString(); 

        }
    }
    public void UpdateRemainingAttempts()
    {
        if (textremainingAttempts != null)
        {
            textremainingAttempts.text = "Remaining Attempts: " + _RemainingTrys.ToString();

        }
    }

    public void ShowMenuPause(bool estado)
    {
        pnlPause.SetActive(estado);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainlyMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
