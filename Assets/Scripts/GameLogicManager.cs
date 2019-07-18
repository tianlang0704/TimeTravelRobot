using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    public GameObject deathPanel;
    public Text hpText;
    public GameObject explosion;
    public int maxHp = 10;
    
    private int hpInternal;
    private int hp {
        get { return hpInternal; }
        set {
            hpInternal = value;
            hpText.text = "HP " + hpInternal.ToString();
        }
    }
    private PlayerManager playerManager;
    private BulletManager bulletManager;
    private EnemyManager enemyManager;
    private TimeManager timeManager;
    private bool isWon = false;

    private void Awake() {
        bulletManager = FindObjectOfType<BulletManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hpText.text = "HP " + maxHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExplosionHit(Explosion exp, GameObject go) {
        Enemy e = go.GetComponent<Enemy>();
        if (e == null) { return; }

        go.SetActive(false);
        enemyManager.killEnemy(exp.gameObject, e);
    }

    public void OnBulletHit(Bullet b, GameObject go) {
        // 确认触碰到敌人
        Enemy e = go.GetComponent<Enemy>();
        if (e != null) {
            // 执行子弹效果
            if (b.getBulletType() == Bullet.BulletType.Base) {
                enemyManager.killEnemy(b.gameObject, e);
            }else if (b.getBulletType() == Bullet.BulletType.TimeSlow) {
                timeManager.slowDownOne(e);
            }
        }

        // 如果不是碰到另外一个子弹, 消除子弹
        Bullet b2 = go.GetComponent<Bullet>();
        if (b2 == null) {
            bulletManager.removeBullet(b);
        }
    }

    public void OnPlayerHit(Player p, GameObject go) {
        // 确认触碰到敌人
        Enemy e = go.GetComponent<Enemy>();
        if (e == null) { return; }

        // 重置演员
        p.gameObject.SetActive(false); //避免一帧触碰多次触发BUG
        enemyManager.killEnemy(p.gameObject, e);
        playerManager.respawnPlayer(p);
        playerManager.removeGhost();

        // 算分
        if (hp > 1) {
            hp -= 1;
        }else{
            theEnd();
        }
    }

    public void OnGhostHit(Ghost g, GameObject go) {
        // 确认触碰到敌人
        Enemy e = go.GetComponent<Enemy>();
        if (e == null) { return; }

        // 避免一帧触碰多次触发BUG
        g.gameObject.SetActive(false); 

        // 退出Ghost状态
        playerManager.exitGhostState();

        // 爆炸
        GameObject expInstance = Instantiate(explosion, g.transform.position + new Vector3(0f, 0.01f, 0f), g.transform.rotation);
    }

    public void OnGoalHit(Goal g, GameObject go) {
        if (isWon) { return; }
        Player p = go.GetComponent<Player>();
        if (p == null) { return; }

        playerManager.exitGhostState();
        playerManager.transformMainToWinState();
    }

    private void theEnd() {
        deathPanel.SetActive(true);
    }
}
