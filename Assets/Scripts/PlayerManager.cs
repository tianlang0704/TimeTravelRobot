using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public Player playerPrefab;
    public Ghost ghostPrefab;

    private Player mainPlayer;
    private Ghost mainGhost;
    private List<Player> ghosts = new List<Player>();
    private TimeManager timeManager;

    private void Awake() {
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 获取随机出生点
    private GameObject getRandomSpawnPoint() {
        int spawnPointCount = spawnPoints.Count;
        int randomSpownIdx = Random.Range(0, spawnPointCount - 1);
        GameObject spawnPoint = spawnPoints[randomSpownIdx];
        return spawnPoint;
    }

    // 生成一个玩家
    public void spawnPlayer() {
        GameObject spawnPoint = getRandomSpawnPoint();
        Player p = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        mainPlayer = p;
    }

    // 生成一个幽灵
    public  Ghost spawnGhost() {
        if (mainGhost != null) { return null; }

        GameObject spawnPoint = mainPlayer?.gameObject;
        if (spawnPoint == null) { spawnPoint = getRandomSpawnPoint(); }
        Ghost g = Instantiate(ghostPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        mainGhost = g;

        // 切换相机到幽灵
        Camera c = mainPlayer.GetComponentInChildren<Camera>();
        if (c) {
            c.enabled = false;
        }

        // 切换声音接受到幽灵
        AudioListener al = mainPlayer.GetComponentInChildren<AudioListener>();
        if (al) {
            al.enabled = false;
        }

        return g;
    }

    // 重生一个角色
    public void respawnPlayer(Player oldPlayer) {
        removePlayer(oldPlayer);
        spawnPlayer();
    }

    // 移除一个角色
    public void removePlayer(Player p) {
        mainPlayer = null;
        Destroy(p.gameObject);
    }

    // 移除一个幽灵
    public void removeGhost(Ghost g = null) {
        // 消灭不应该出现的Ghost
        if (g && mainGhost != g) {
            Destroy(g.gameObject);
        }

        // 消灭主Ghost
        if (mainGhost == null) { return; }
        Destroy(mainGhost.gameObject);
        mainGhost = null;
        
        // 切换相机到主角
        Camera c = mainPlayer.GetComponentInChildren<Camera>();
        if (c) {
            c.enabled = true;
        }

        // 切换声音接受到主角
        AudioListener al = mainPlayer.GetComponentInChildren<AudioListener>();
        if (al) {
            al.enabled = true;
        }
    }

    public bool isGhostExist() {
        return mainGhost != null;
    }

    public void enterGhostState() {
        Ghost g = spawnGhost();
        if (g) {
            timeManager.slowDownAllButOne(g);
        }
    }

    public void exitGhostState() {
        // 消除Ghost
        removeGhost();

        // 矫正时间
        timeManager.resumeAll();
    }
}
