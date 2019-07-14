using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SimpleTouchController cameraController;
    public float cameraSpeed = 10f;
    public float cameraClostLimit = 0.5f;
    public float cameraFarLimit = 5.0f;

    private void Awake() {
        List<SimpleTouchController> controllerUIs = new List<SimpleTouchController>(FindObjectsOfType<SimpleTouchController>());
        foreach (var controllerUI in controllerUIs)
        {
            if (controllerUI.name.Contains("Right")){
                cameraController = controllerUI;
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
        if  (cameraController.GetTouchPosition.y != 0 &&
            ((cameraController.GetTouchPosition.y > 0 && transform.localPosition.x >= cameraClostLimit && transform.localPosition.y >= cameraClostLimit && transform.localPosition.z >= cameraClostLimit) ||
            (cameraController.GetTouchPosition.y < 0 && transform.localPosition.x <= cameraFarLimit && transform.localPosition.y <= cameraFarLimit && transform.localPosition.z <= cameraFarLimit)))
        {
            transform.position += cameraController.GetTouchPosition.y * transform.forward * Time.deltaTime * cameraSpeed;
        }
    }
}
