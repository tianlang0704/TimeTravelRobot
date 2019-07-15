using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    static Vector3 savedCameraPos = Vector3.zero;

    public float cameraSpeed = 10f;
    public float cameraClostLimit = 0.5f;
    public float cameraFarLimit = 5.0f;
    private SimpleTouchController cameraController;
    private PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;

    private void Awake() {
        List<SimpleTouchController> controllerUIs = new List<SimpleTouchController>(FindObjectsOfType<SimpleTouchController>());
        foreach (var controllerUI in controllerUIs)
        {
            if (controllerUI.name.Contains("Right")){
                cameraController = controllerUI;
            }
        }

        postProcessVolume = FindObjectOfType<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out depthOfField);

        if (savedCameraPos != Vector3.zero) {
            transform.position = savedCameraPos;
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
            transform.position += cameraController.GetTouchPosition.y * transform.forward * Time.unscaledDeltaTime * cameraSpeed;
            savedCameraPos = transform.position;
            depthOfField.focalLength.value = 1.526941f / transform.localPosition.magnitude * 24;
        }
    }
}
