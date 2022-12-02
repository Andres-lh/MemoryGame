using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Table _table;
    private void Awake()
    {
        _table = GetComponent<Table>();  
    }

  void Start()
    {
        _table.StarTable();
    }
    void Update()
    {
        
    }
}
