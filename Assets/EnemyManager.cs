using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// EnemyManager.cs
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int maxEnemies; 
    public float minY = -3f;
    public float maxY = 3f;
    public float minSpeed;
    public float maxSpeed;
    private void Start()
    {
        GameState.currentEnemies = 0;
    }

    private void Update()
    {
        if(GameState.currentEnemies < maxEnemies)
        {
            for(int i = GameState.currentEnemies; i < maxEnemies; i++)
            {
                GameState.currentEnemies++;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        // ������� ���� ��� ������ ������
        Vector2 spawnPosition = new Vector2(Camera.main.transform.position.x + Camera.main.orthographicSize * 2f, Random.Range(minY, maxY));
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // ��������� ��������� �������� �����
        float speed = Random.Range(minSpeed, maxSpeed);
        enemy.GetComponent<Enemy>().SetSpeed(speed);
    }
}
