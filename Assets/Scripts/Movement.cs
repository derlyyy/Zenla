using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения игрока
    public float jumpForce = 10f; // Сила прыжка

    private float targetAngle = 0f; // Целевой угол поворота
    public float rotationSpeed = 5f; // Скорость поворота

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput < 0) // Если двигаем влево
        {
            transform.Translate(Vector3.left * moveInput * moveSpeed * Time.deltaTime);
            targetAngle = 180f; // Устанавливаем целевой угол на 180 градусов
        }
        else if (moveInput > 0) // Если двигаем вправо
        {
            targetAngle = 0f; // Устанавливаем целевой угол на 0 градусов
            transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
        }

        // Используем Slerp для плавного поворота
        float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0f, angle, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}