using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 公共
    public Enemy enemyCharacterPrefab;
    public float enemySpawnInterval = 5f;
    public List<GameObject> spawnPoints = new List<GameObject>();

    // 私有
    private bool isSpawnEnemy = true;
    private float spawnEnemyTimer = 0f;
    private int waveCount = 0;
    private List<Enemy> allEnemies = new List<Enemy>();
    private GameLogicManager gameLogicManager;

    private void Awake() {
        gameLogicManager = FindObjectOfType<GameLogicManager>();
    }

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
        if (spawnPointCount == 0) { return; }

        int randomSpownIdx = Random.Range(0, spawnPointCount - 1);
        GameObject spawnPoint = spawnPoints[randomSpownIdx];
        if (spawnPoint == null) { return; }

        Enemy e = Instantiate(enemyCharacterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        allEnemies.Add(e);
    }

    // 元素交互
    public void killEnemy(GameObject killer, Enemy enemy) {
        removeEnemy(enemy);
    }
}
