using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Задаём скорость игрока
    [SerializeField] private float speed = 5f;

    // Задаём аниматор
    [SerializeField] private Animator animator;

    // Задаём направление движения
    private Vector2 direction;

    // Задаём компонент Rigidbody2D как rb
    private Rigidbody2D rb;

    void Start()
    {
        // Получаем компонент Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем направление движения(ввод с клавиатуры) по иксу 
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        // Нормализуем направление движения
        direction = direction.normalized;

        // Привязываем значения из аниматора к направлениям движения
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // складываем позицию игрока с направлением помноженым на скорость и промежуток времени
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
