using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    private Table _table;

    private bool _CanChosee=true;
    private Token LastChosen=null;
    private void Awake()
    {
        Singleton();
        _table = GetComponent<Table>();  
    }

  

    void Start()
    {
        _table.StarTable();
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
        Destroy(lastChosen.gameObject,1.5f);
        // TODO generate particleSysyem when player has matched
        //TODO apply sound when player has won

        lastChosen = null;

        StartCoroutine(BlockChosen(1.5f));


        _table.cuantityTokens -= 2;

        if(_table.cuantityTokens <= 0)
        {
            //TODO canvas winner and credits
        }


    }
    private void WrongPair(Token token, Token lastChosen)
    {
        print("Incorrecto");
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
}
