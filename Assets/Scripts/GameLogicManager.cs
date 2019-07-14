using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    int counter = 0;    private PlayerManager playerManager;
    private BulletManager bulletManager;
    private EnemyManager enemyManager;

    private void Awake() {
        bulletManager = FindObjectOfType<BulletManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBulletHit(Bullet b, Enemy e) {
        if (e != null) {
            enemyManager.killEnemy(b.gameObject, e);
        }
        bulletManager.removeBullet(b);
    }

    public void OnPlayerHit(Player p, Enemy e) {
        p.gameObject.SetActive(false); //避免一帧触碰多次触发BUG
        
        enemyManager.killEnemy(p.gameObject, e);
        playerManager.respawnPlayer(p);
    }
}
