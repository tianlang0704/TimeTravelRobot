using UnityEngine;
using System.Collections;

public class TransformingRobotCharacter : MonoBehaviour {
	public float robotSpeed=1f;
	public float tankSpeed=1f;
	public float tankRotateSpeed=1f;
	public float planeSpeed=1f;
	public float planeRotateSpeed=1f;
	public int robotMode=1;//0:robot,1:tank,2:plane


	private Animator robotAnimator;
	private Rigidbody robotRigidBody;
    private Transform robotTransform;
	private BulletSpawner spawner;

	// Use this for initialization
	void Start () {
		robotAnimator = GetComponent<Animator> ();
		robotAnimator.speed = robotSpeed;
		robotRigidBody = GetComponent<Rigidbody> ();
        robotTransform = GetComponent<Transform> ();
		spawner = GetComponentInChildren<BulletSpawner>();
	}

	void Update(){

	}

	public void RobotModeChange(int aRobotMode){
		robotMode = aRobotMode;
		if (robotMode == 0) {
            robotAnimator.applyRootMotion = false;
			robotRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
			robotRigidBody.useGravity = true;
		} else if (robotMode == 1) {
            robotAnimator.applyRootMotion = false;
            robotRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            robotRigidBody.useGravity = true;
        }
        else if(robotMode == 2){
			robotAnimator.applyRootMotion = false;
			robotRigidBody.constraints = RigidbodyConstraints.None;
			robotRigidBody.useGravity = false;
		}
	}


	public void Robot(){
        RobotModeChange(0);
        robotAnimator.SetTrigger ("Robot");
	}

	public void Tank(){
		RobotModeChange (1);
		robotAnimator.SetTrigger ("Tank");
	}

	public void Plane(){
		RobotModeChange (2);
		robotAnimator.SetTrigger ("Plane");
	}

	public void Attack(){
		robotAnimator.SetTrigger ("Attack");
        spawner.spawnBullet();
	}

	public void Punch(){
		robotAnimator.SetTrigger ("Punch");
	}

	public void Hit(){
		robotAnimator.SetTrigger ("Hit");
	}

	public void Move(float v,float h){
        robotAnimator.SetFloat("Forward", h);
        if (h != 0 && robotMode == 1) {
            robotTransform.position += h * transform.forward * Time.deltaTime * tankSpeed;
        } else if (h > 0 && robotMode == 2) {	
			robotRigidBody.AddForce(h * transform.forward * Time.deltaTime * planeSpeed);
		}
	}
}
