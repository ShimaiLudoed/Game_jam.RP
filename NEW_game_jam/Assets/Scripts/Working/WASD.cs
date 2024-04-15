using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    private bool _isMove;
    private CharAnim _anim;
    public bool moving = false;
    private float speed = 10f;
    private SpriteRenderer _char;
    
    // Добавляем переменные для каждого направления взгляда
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public void Start()
    {
        _anim = GetComponentInChildren<CharAnim>();
        _char = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer /
    }

    public void Update()
    {
        Movement();
        SetSpriteDirection(); // Вызываем метод для изменения спрайта персонажа
    }

    public void Movement()
    {
        _isMove = moving != false ? true : false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;

        }

        _anim.Ismove = _isMove;
    }

    public void SetSpriteDirection()
    {
        // Изменяем спрайт в зависимости от направления движения
        if (Input.GetKey(KeyCode.W))
        {
            _char.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _char.sprite = leftSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _char.sprite = downSprite;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _char.sprite = rightSprite;
        }
    }
}