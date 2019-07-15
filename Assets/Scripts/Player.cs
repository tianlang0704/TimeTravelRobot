using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : TimeScaledGO
{
    private GameLogicManager gameLogicManager;
    private TransformingRobotCharacter character;
    private TransformingRobotUserController userController;
    private CameraController cameraController;
    private BulletSpawner bulletSpawner;

    override protected void Awake() {
        base.Awake();
        gameLogicManager = FindObjectOfType<GameLogicManager>();
        character = GetComponent<TransformingRobotCharacter>();
        userController = GetComponent<TransformingRobotUserController>();
        cameraController = GetComponentInChildren<CameraController>();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();

        List<SimpleTouchController> controllerUIList = new List<SimpleTouchController>(FindObjectsOfType<SimpleTouchController>());
        foreach (var controller in controllerUIList) {
            if (controller.gameObject.name.Contains("Left")) {
                userController.playerControllerUI = controller;
            }else if (controller.gameObject.name.Contains("Right")) {
                cameraController.cameraController = controller;
            }
        }
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

    private void OnTriggerEnter(Collider other) {
        gameLogicManager.OnPlayerHit(this, other.gameObject);
    }
}
