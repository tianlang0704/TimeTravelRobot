using UnityEngine;
using System.Collections;

public class TransformingRobotUserController : MonoBehaviour {

	public TransformingRobotCharacter transformingRobotCharacter;

    public SimpleTouchController playerControllerUI;

    // Use this for initialization
    void Start () {
		transformingRobotCharacter = GetComponent<TransformingRobotCharacter> ();	
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			transformingRobotCharacter.Plane();
		}else if (Input.GetKeyDown(KeyCode.R)) {
			transformingRobotCharacter.Robot();
		}else if (Input.GetKeyDown(KeyCode.T)) {
			transformingRobotCharacter.Tank();
		}	

		if (Input.GetButtonDown ("Fire1")) {
			transformingRobotCharacter.Attack();
		}
		
		if (Input.GetButtonDown ("Fire2")) {
			transformingRobotCharacter.Punch();
		}

		if (Input.GetKeyDown(KeyCode.H)) {
			transformingRobotCharacter.Hit();
		}
	}
	
	void FixedUpdate(){
        //float v = Input.GetAxis("Vertical");
        float v = playerControllerUI.GetTouchPosition.y;
        //float h = Input.GetAxis("Horizontal");
        float h = playerControllerUI.GetTouchPosition.x;
        if (h != 0)
        {
            transformingRobotCharacter.Move(v, h);
        }
    }
}
