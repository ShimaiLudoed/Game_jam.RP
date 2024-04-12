using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator _animator;
    
    public bool Ismoving { private get; set; }     //отвечает за состояние движения 

    private void Start()
    {
        _animator = GetComponent<Animator>();      //получение компонента 
    }

    private void FixedUpdate()
    {
        _animator.SetBool("Ismoving",Ismoving);     //установление состояния в движение
    }
}
