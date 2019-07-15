using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    int counter = 0;    private PlayerManager playerManager;
    private BulletManager bulletManager;
    private EnemyManager enemyManager;
    private TimeManager timeManager;

    private void Awake() {
        bulletManager = FindObjectOfType<BulletManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBulletHit(Bullet b, GameObject go) {
        Enemy e = go.GetComponent<Enemy>();
        if (e != null) {
            if (b.getBulletType() == Bullet.BulletType.Base) {
                enemyManager.killEnemy(b.gameObject, e);
            }else if (b.getBulletType() == Bullet.BulletType.TimeSlow) {
                timeManager.slowDownOne(e);
            }
        }

        Bullet b2 = go.GetComponent<Bullet>();
        if (b2 == null) {
            bulletManager.removeBullet(b);
        }
    }

    public void OnPlayerHit(Player p, GameObject go) {
        Enemy e = go.GetComponent<Enemy>();
        if (e == null) { return; }

        p.gameObject.SetActive(false); //避免一帧触碰多次触发BUG
        enemyManager.killEnemy(p.gameObject, e);
        playerManager.respawnPlayer(p);
    }
}
