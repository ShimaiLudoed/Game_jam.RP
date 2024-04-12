using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //ПОСМОТРИТЕ УРОКИ В ЧАТЕ КАНАЛА ПРОГЕРОВ, Я ПО НИМ ВСЁ ЭТО ДЕЛАЛ!!!
public class Movement : MonoBehaviour
{
    private SpriteRenderer _characterSprite;      //что-то для спрайта смотреть в 1 уроке
    private CharacterAnim _animations;            //анимации смотреть в 1 уроке
    public Transform GroundCheck;                 //сущность для проверки, что это земля(как я понял) 2 урок
    public LayerMask whatIsground;                //то что мы будем в на карте называть землёй 
    public float radgroundCheck;                  //радиус проверки, что игрок на земле 
    private bool IsGrounded;                      //проверка, что игрок на земле или нет 
    public float _jumpForce;                      //Сила прыжка
    public float _speed;                          //скорость 
    private Vector3 _input;                       //тупо вектор который будет получать значения
    private Rigidbody2D _rigidbody;               //ссылка на компонент (хз, что это) 

    private bool _isMoving;
  
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();           //Получаем компонент 
        _animations = GetComponentInChildren<CharacterAnim>();//тож самое, но анимации
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, radgroundCheck, whatIsground); //во втором уроке объяснили как это работает
        move(); //вызываем метод move
        if (Input.GetKey(KeyCode.Space)&& IsGrounded) //проверка, что игрок нажимет space и то что игрок на земле 
        {
            Jump(); //вызываем метод jump 
        }
    }

    private void Jump()
    {
        Debug.Log("jump"); //вывод в консоль 
        
        _rigidbody.AddForce(transform.up*_jumpForce,ForceMode2D.Impulse); //вычисление для прыжка
    }

    private void move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);    //хз, мозги кипят уже
        transform.position += _input * _speed * Time.deltaTime;         //вычесление для передвижения и сама ходьба 
        _isMoving = _input.x != 0 ? true : false;                       //для анимации, что бы игрок мог остановиться
        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;         //хз что это 
        }

     
    }
}
