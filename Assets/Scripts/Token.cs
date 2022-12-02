using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public int Id { get; set; }
    [SerializeField]private SpriteRenderer _SpriteRenderer;

    private void OnMouseDown()
    {
        print(Id);
    }


}
