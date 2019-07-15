using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : TimeScaledGO
{
    public enum BulletType
    {
        Base = 1,
        TimeSlow = 2
    }
    public float bulletSpeed = 0.5f;

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
