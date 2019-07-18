using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家统合管理器
public class Player : TimeScaledGO
{
    // 公有
    // 胜利火花prefab
    public GameObject firework;

    // 私有
    protected GameLogicManager gameLogicManager;
    protected TransformingRobotCharacter character;
    protected TransformingRobotUserController userController;
    protected CameraController cameraController;
    protected BulletSpawner bulletSpawner;

    override protected void Awake() {
        base.Awake();
        gameLogicManager = FindObjectOfType<GameLogicManager>();
        character = GetComponent<TransformingRobotCharacter>();
        userController = GetComponent<TransformingRobotUserController>();
        cameraController = GetComponentInChildren<CameraController>();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 玩家碰撞逻辑
    private void OnTriggerEnter(Collider other) {
        gameLogicManager.OnPlayerHit(this, other.gameObject);
    }

    // 设置展示火花
    public void setShowFirework(bool b) {
        firework.SetActive(b);
    }
}
