using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public Player playerPrefab;
    private List<Player> players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 生成一个玩家
    public void spawnPlayer() {
        int spawnPointCount = spawnPoints.Count;
        if (spawnPointCount == 0) { return; }

        int randomSpownIdx = Random.Range(0, spawnPointCount - 1);
        GameObject spawnPoint = spawnPoints[randomSpownIdx];
        if (spawnPoint == null) { return; }

        Player p = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        players.Add(p);
    }

    public void respawnPlayer(Player oldPlayer) {
        removePlayer(oldPlayer);
        spawnPlayer();
    }

    public void removePlayer(Player p) {
        players.Remove(p);
        Destroy(p.gameObject);
    }
}
