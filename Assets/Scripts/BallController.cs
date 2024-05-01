using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float currentSpeed; // Текущая скорость мяча
    public float startSpeed = 5f; // Начальная скорость
    public float maxSpeed = 20f;   // Максимальная скорость
    public float accelerationRate = 0.1f; // Скорость ускорения
    public float minDirection = 0.5f; // Минимальная длина вектора направления
    private Vector3 direction; // Направление движения мяча
    private bool stopped = true;
    public GameObject sparksVFX;

    private Rigidbody rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        currentSpeed = startSpeed;
    }

    void FixedUpdate()
    {
        if(stopped)
            return;

        // Увеличиваем текущую скорость мяча со временем
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.fixedDeltaTime * accelerationRate);

        // Перемещаем мяч в новую позицию
        rb.MovePosition(this.rb.position + direction * currentSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Wall"))
        {
            // Отражаем мяч от стены по оси Z
            direction.z = -direction.z;

            hit = true;
        }

        if
        (other.CompareTag("Player"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;

            hit = true;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }
    private void ChooseDirection()
    {
        // Генерируем случайное направление для мяча
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        this.stopped = true;
    }

    public void Go()
    {
        ChooseDirection();
        this.stopped = false;
        ResetAcceleration();
    }

    public void ResetAcceleration()
    {
        currentSpeed = startSpeed; // Сброс ускорения до начальной скорости
    }
}
