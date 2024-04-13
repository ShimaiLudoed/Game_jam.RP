using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //ПОСМОТРИТЕ УРОКИ В ЧАТЕ КАНАЛА ПРОГЕРОВ, Я ПО НИМ ВСЁ ЭТО ДЕЛАЛ!!!
public class Movement : MonoBehaviour
{
    private SpriteRenderer _characterSprite;      //что-то для спрайта смотреть в 1 уроке
    private CharacterAnim _animations;            //анимации смотреть в 1 уроке

    public float _jumpForce;                      //Сила прыжка
    public float _speed;                          //скорость 
    private Vector3 _input;                       //тупо вектор который будет получать значения
    private Rigidbody2D _rigidbody;               //ссылка на компонент (хз, что это)     ==     скорее всего, тело игрока

    private bool _isMoving;
  
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();           //Получаем компонент 
        _animations = GetComponentInChildren<CharacterAnim>();//тож самое, но анимации
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);    //хз, мозги кипят уже
        transform.position += _input * _speed * Time.deltaTime;         //вычесление для передвижения и сама ходьба 
        if (Input.GetKey(KeyCode.Space)&& Mathf.Abs(_rigidbody.velocity.y)< 0.05f) //проверка, что игрок нажимет space и то что игрок на земле 
        //есть странная вещь, что при достижение определённой высоты можно сделать двойной прыжок, но если с цифрами поиграть такого не будет
        {
            Jump(); //вызываем метод jump 
        }
        move(); //делает поворот героя и анимацию стопа (если они есть)
    }

    private void Jump()
    {
        Debug.Log("jump"); //вывод в консоль 
        
        _rigidbody.AddForce(transform.up*_jumpForce,ForceMode2D.Impulse); //вычисление для прыжка
    }

    private void move()
    {
        
        _isMoving = _input.x != 0 ? true : false;                       //для анимации, что бы игрок мог остановиться
        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;         //хз что это 
        }

     
    }
}
