using System.Collections;
using System.Collections.Generic;
// EnemyManager.cs
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int maxEnemies = 4; 
    public float minY = -3f;
    public float maxY = 3f;
    public float minSpeed;
    public float maxSpeed;

    private void Start()
    {
        // Запускаем создание врагов
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Создаем случайное количество врагов в заданных пределах
            int enemiesToSpawn = Random.Range(1, maxEnemies + 1);
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); 
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f)); 
        }
    }

    void SpawnEnemy()
    {
        // Создаем враг вне экрана справа
        Vector2 spawnPosition = new Vector2(Camera.main.transform.position.x + Camera.main.orthographicSize * 2f, Random.Range(minY, maxY));
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Назначаем случайную скорость врагу
        float speed = Random.Range(minSpeed, maxSpeed);
        enemy.GetComponent<Enemy>().SetSpeed(speed);
    }
}
