using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;

    void Update()
    {
        // Двигаем врага влево
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Если враг вышел за левый край экрана, удаляем его и создаем нового справа
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * 2f)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        // Устанавливаем скорость врага
        speed = newSpeed;
    }
}
