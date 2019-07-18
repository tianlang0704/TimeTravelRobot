using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : TimeScaledGO
{
    // 子弹种类
    public enum BulletType
    {
        Base = 1, // 基础子弹
        TimeSlow = 2 // 时间减慢子弹
    }
    public float bulletSpeed = 0.5f; // 子弹速度

    private GameLogicManager GameLogicManager;

    override protected void Awake() {
        base.Awake();
        GameLogicManager = FindObjectOfType<GameLogicManager>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update() {
        // 根据时间管理组件来计算子弹速度.
        float deltaTime;
        TimeScaledGO tgo = GetComponent<TimeScaledGO>();
        if (tgo != null) {
            deltaTime = tgo.getDeltaTime();
        }else{
            deltaTime = Time.deltaTime;
        }
        transform.position += deltaTime * bulletSpeed * transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    public virtual BulletType getBulletType() {
        return BulletType.Base;
    }

    private void OnTriggerEnter(Collider other) {
        GameLogicManager.OnBulletHit(this, other.gameObject);
    }
}
