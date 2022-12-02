using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Table : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int m_SizeTableX = 4;
    [SerializeField] private int m_SizeTableY = 4;
    [SerializeField] Vector2 m_SplitTokens = Vector2.zero;


    [Header("References")]
    [SerializeField] private GameObject m_Token;
    [SerializeField] private Transform m_AreaOfGame; // defined area of game in order to instance tokens and adjust it.

    public int cuantityTokens { get;  set; }

    [SerializeField] private Sprite[] _imagenes; 

    public void StarTable()
    {
        Vector2 StartPositionToken = CalculateStartPositionToken();

        int CuantityTokens=m_SizeTableX*m_SizeTableY;

        List<int> idsTokens = CreateListIdMixer(CuantityTokens);
        int remainingTokens = 0;


        for (int x = 0; x < m_SizeTableX; x++)
        {
            for (int y = 0; y < m_SizeTableY; y++)
            {
                Vector3 newPosition = new Vector3((x * m_SplitTokens.x)- StartPositionToken.x, 0, (y * m_SplitTokens.y) - StartPositionToken.y);

                GameObject tokenGo = Instantiate(m_Token);

                Token currenlyToken=tokenGo.GetComponent<Token>();
                currenlyToken.Id = idsTokens[remainingTokens];
                currenlyToken.Setearimage(_imagenes[currenlyToken.Id]);
                

                tokenGo.transform.parent = m_AreaOfGame;
                tokenGo.transform.localPosition = newPosition;
                remainingTokens++;
            }
        }

        cuantityTokens = remainingTokens;

    }
    private Vector2 CalculateStartPositionToken()
    {
        float positionMaxX = (m_SizeTableX - 1) * m_SplitTokens.x;
        float positionMaxY = (m_SizeTableY - 1) * m_SplitTokens.y;
        float middlePoxMaxX = positionMaxX / 2;
        float middlePosMaxY = positionMaxY / 2;
        return new Vector2(middlePoxMaxX,middlePosMaxY);
    }
    private List<int> CreateListIdMixer(int CuantityTokens)
    {
        List<int> IdTokens = new List<int>();

        for (int i = 0; i < CuantityTokens; i++)
        {
            IdTokens.Add(i/2);
            
        }
        IdTokens.Shuffle();
        return IdTokens;
    }
}



