using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float mapLimit = 4f;


    // TODO: 加入子弹池

    private List<Bullet> allBullets = new List<Bullet>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 自动销毁
        for (int i = allBullets.Count - 1; i >= 0; i--)
        {
            Bullet b = allBullets[i];
            if (b.transform.position.x > mapLimit ||
                b.transform.position.y > mapLimit ||
                b.transform.position.z > mapLimit)
            {
                removeBullet(b);
            }
        }
    }

    // 生成子弹
    public void spawnBullet(Bullet type, Vector3 position, Quaternion rotation)
    {
        Bullet bulletInst = Instantiate(type);
        allBullets.Add(bulletInst);
        bulletInst.transform.position = position;
        bulletInst.transform.rotation = rotation;
    }

    // 销毁子弹
    public void removeBullet(Bullet bulletInst)
    {
        allBullets.Remove(bulletInst);
        Destroy(bulletInst.gameObject);
    }
}
