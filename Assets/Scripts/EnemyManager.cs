using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人生成和销毁管理器
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
    private TimeManager timeManager;

    private void Awake() {
        gameLogicManager = FindObjectOfType<GameLogicManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 检查时间并生成敌人
        checkAndSpawnEnemyWave();

        // 检查敌人位置并自动销毁超出位置限制的个体
        checkEnemyPositionLimit();
    }

    // 检查时间并生成敌人
    private void checkAndSpawnEnemyWave()
    {
        spawnEnemyTimer += Time.unscaledDeltaTime;
        if (isSpawnEnemy && waveCount <= Mathf.Floor(spawnEnemyTimer / enemySpawnInterval))
        {
            waveCount += 1;
            spawnEnemy();
        }
    }

    // 设置是否生成敌人
    public void setToSpawningEnemy(bool b)
    {
        // 如果为是, 清除生成时间计数
        if (b) {
            spawnEnemyTimer = 0f;
        }
        isSpawnEnemy = b;
    }

    // 检查敌人位置并自动销毁超出位置限制的个体
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
    
    // 消除敌人, 所有接口经过这里
    private void removeEnemy(Enemy e) {
        allEnemies.Remove(e);
        Destroy(e.gameObject);
    }

    // 生成敌人, 所有接口经过这里
    private void spawnEnemy()
    {
        // 随机出生点
        int spawnPointCount = spawnPoints.Count;
        if (spawnPointCount == 0) { return; }
        int randomSpownIdx = Random.Range(0, spawnPointCount - 1);
        GameObject spawnPoint = spawnPoints[randomSpownIdx];
        if (spawnPoint == null) { return; }

        // 实例化敌人
        Enemy e = Instantiate(enemyCharacterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        allEnemies.Add(e);
    }

    // 元素交互
    public void killEnemy(GameObject killer, Enemy enemy) {
        removeEnemy(enemy);
    }
}
