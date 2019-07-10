using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerManager : MonoBehaviour
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
        for (int i = allBullets.Count - 1; i >= 0; i--)
        {
            Bullet b = allBullets[i];
            if (b.transform.position.x > mapLimit ||
                b.transform.position.y > mapLimit ||
                b.transform.position.z > mapLimit)
            {
                allBullets.RemoveAt(i);
                Destroy(b);
            }
        }
    }

    public void spawnBullet(Bullet type, Vector3 position, Quaternion rotation)
    {
        Bullet bulletInst = Instantiate(type);
        allBullets.Add(bulletInst);
        bulletInst.transform.position = position;
        bulletInst.transform.rotation = rotation;
    }

    public void removeBullet(Bullet bulletInst)
    {
        allBullets.Remove(bulletInst);
        Destroy(bulletInst);
    }
}
