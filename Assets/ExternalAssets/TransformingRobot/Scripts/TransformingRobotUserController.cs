using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformingRobotUserController : MonoBehaviour {
	private TransformingRobotCharacter transformingRobotCharacter;
    private SimpleTouchController playerControllerUI;
	private MainShootButton mainShootButton;
	private SecondShootButton secondShootButton;
	private SSSButton sssButton;
	private SkillManager skillManager;

	private void Awake() {
		List<SimpleTouchController> controllerUIs = new List<SimpleTouchController>(FindObjectsOfType<SimpleTouchController>());
        foreach (var controllerUI in controllerUIs)
        {
            if (controllerUI.name.Contains("Left")){
                playerControllerUI = controllerUI;
				break;
            }
        }

		transformingRobotCharacter = GetComponent<TransformingRobotCharacter> ();
		mainShootButton = FindObjectOfType<MainShootButton>();
		secondShootButton = FindObjectOfType<SecondShootButton>();
		sssButton = FindObjectOfType<SSSButton>();
		skillManager = FindObjectOfType<SkillManager>();
	}

    // Use this for initialization
    void Start () {
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			transformingRobotCharacter.Plane();
		}else if (Input.GetKeyDown(KeyCode.R)) {
			transformingRobotCharacter.Robot();
		}else if (Input.GetKeyDown(KeyCode.T)) {
			transformingRobotCharacter.Tank();
		}	

		if (mainShootButton.isShoot || Input.GetKeyDown(KeyCode.J)) {
			transformingRobotCharacter.Attack(SkillManager.SkillType.Main);
		}else if (secondShootButton.isShoot|| Input.GetKeyDown(KeyCode.K)) {
			transformingRobotCharacter.Attack(SkillManager.SkillType.Second);
		}else if (sssButton.isShoot || Input.GetKeyDown(KeyCode.L)) {
			skillManager.SSS();
		}
		
		// if (Input.GetButtonDown ("Fire2")) {
		// 	transformingRobotCharacter.Punch();
		// }

		// if (Input.GetKeyDown(KeyCode.H)) {
		// 	transformingRobotCharacter.Hit();
		// }

        float v = playerControllerUI.GetTouchPosition.y + Input.GetAxis("Vertical");
        float h = playerControllerUI.GetTouchPosition.x + Input.GetAxis("Horizontal");
        if (h != 0 || v != 0) {
            transformingRobotCharacter.Move(v, h);
        }
	}
	
	void FixedUpdate(){

    }
}
