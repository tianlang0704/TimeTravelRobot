using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{ 

    public Bullet bullet;
    public BulletControllerManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnBullet()
    {
        manager.spawnBullet(bullet, transform.position, transform.rotation);     
    }
}
