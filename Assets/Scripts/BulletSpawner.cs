using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum BulletType
    {
        Main = 1,
        Second = 2
    }

    public Bullet bullet;
    public Bullet secondBullet;

    private BulletManager bulletManager;

    private void Awake() {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnBullet(BulletType type = BulletType.Main)
    {
        if (type == BulletType.Main) {
            bulletManager.spawnBullet(bullet, transform.position, transform.rotation);     
        }else if (type == BulletType.Second){
            bulletManager.spawnBullet(secondBullet, transform.position, transform.rotation);
        }
    }
}
