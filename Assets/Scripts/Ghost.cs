using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 幽灵管理器
public class Ghost : Player
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 重载碰撞逻辑
    private void OnTriggerEnter(Collider other) {
        gameLogicManager.OnGhostHit(this, other.gameObject);
    }
}
