using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;

    void Update()
    {
        // ������� ����� �����
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ���� ���� ����� �� ����� ���� ������, ������� ��� � ������� ������ ������
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * 2f)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        // ������������� �������� �����
        speed = newSpeed;
    }
}
