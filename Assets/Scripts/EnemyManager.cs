using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 增加一个角色基类
    public Enemy enemyCharacterPrefab;
    public float enemySpawnInterval = 5f;
    public List<GameObject> spawnPoints = new List<GameObject>();

    private bool isSpawnEnemy = true;
    private float spawnEnemyTimer = 0f;
    private int waveCount = 0;
    private List<Enemy> allEnemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkAndSpawnEnemyWave();
        checkEnemyPositionLimit();
    }

    private void checkAndSpawnEnemyWave()
    {
        spawnEnemyTimer += Time.deltaTime;
        if (isSpawnEnemy && waveCount <= Mathf.Floor(spawnEnemyTimer / enemySpawnInterval))
        {
            waveCount += 1;
            spawnEnemy();
        }
    }

    public void setToSpawningEnemy(bool b)
    {
        if (b) {
            spawnEnemyTimer = 0f;
        }
        isSpawnEnemy = b;
    }

    private void checkEnemyPositionLimit()
    {
        // 自动销毁
        for (int i = allEnemies.Count - 1; i >= 0; i--)
        {
            Enemy e = allEnemies[i];
            if (e.transform.position.y < 0.7)
            {
                removeEnemy(e);
            }
        }
    }
    
    private void removeEnemy(Enemy e) {
        allEnemies.Remove(e);
        Destroy(e.gameObject);
    }

    private void spawnEnemy()
    {
        int spawnPointCount = spawnPoints.Count;
        if (spawnPointCount != 0)
        {
            int randomSpownIdx = Random.Range(0, spawnPointCount - 1);
            GameObject spawnPoint = spawnPoints[randomSpownIdx];
            if (spawnPoint == null) { return; }
            Enemy e = Instantiate(enemyCharacterPrefab);
            allEnemies.Add(e);
            e.transform.position = spawnPoint.transform.position;
            e.transform.rotation = spawnPoint.transform.rotation;
        }
    }
}
