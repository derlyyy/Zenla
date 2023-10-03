using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Скорость полета пули
    private int damage;
    
    private Vector2 moveDirection; // Направление движения пули

    public void SetDirection(Vector2 direction, int damageValue)
    {
        moveDirection = direction.normalized; // Нормализуем направление
        damage = damageValue;
    }

    private void Update()
    {
        // Двигаем пулю с постоянной скоростью в установленном направлении
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Если пуля сталкивается с чем-то
        if (other.CompareTag("Enemy")) // Проверяем, является ли объект, с которым столкнулась пуля, врагом
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Уничтожаем пулю после попадания во врага
            Destroy(gameObject);
        }
        else
        {
            // Уничтожаем пулю, если она сталкивается с чем-то другим
            Destroy(gameObject);
        }
    }
}