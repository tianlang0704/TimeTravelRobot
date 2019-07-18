using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
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

    // 根据武器类型生成子弹, 角色控制器调用这里
    public void spawnBullet(SkillManager.SkillType type = SkillManager.SkillType.Main)
    {
        if (type == SkillManager.SkillType.Main) {
            bulletManager.spawnBullet(bullet, transform.position, transform.rotation);     
        }else if (type == SkillManager.SkillType.Second){
            bulletManager.spawnBullet(secondBullet, transform.position, transform.rotation);
        }
    }
}
