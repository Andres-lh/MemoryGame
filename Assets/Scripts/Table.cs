using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        for (int x = 0; x < m_SizeTableX; x++)
        {
            for (int y = 0; y < m_SizeTableY; y++)
            {
                Vector3 newPosition = new Vector3(x * m_SplitTokens.x, 0, y * m_SplitTokens.y);
                GameObject tokenGo = Instantiate(m_Token, newPosition, Quaternion.identity);

                tokenGo.transform.parent = m_AreaOfGame;
            }
        }

    }
}



