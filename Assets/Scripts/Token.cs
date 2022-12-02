using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public int Id { get; set; }
    [SerializeField]private SpriteRenderer _SpriteRenderer;
    [SerializeField]private Animator _Animator;

    private void OnMouseDown()
    {
        GameManager.instance.ProcessTokenClick(this);
       
    }

    public void ShowFront()
    {
        _Animator.Play("TokenBackFront");
    }
    public void ShowBack()
    {
        _Animator.Play("TokenFrontBack");
    }
    public void Setearimage(Sprite sprite)
    {
        _SpriteRenderer.sprite=sprite;
    }

}
