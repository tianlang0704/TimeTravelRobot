using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameLogicManager gameLogicManager;
    private TransformingRobotCharacter character;
    private TransformingRobotUserController userController;
    private CameraController cameraController;
    private BulletSpawner bulletSpawner;

    private void Awake() {
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Enemy e = other.GetComponent<Enemy>();
        if (e == null) {
            Debug.LogError("NOT AN ENEMY!!");
            return;
        }

        gameLogicManager.OnPlayerHit(this, e);
    }
}
