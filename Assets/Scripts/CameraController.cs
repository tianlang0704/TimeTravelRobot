using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    // 保存相机位置确保切换主角的时候视角一致
    static Vector3 savedCameraPos = Vector3.zero;

    // 相机参数
    public float cameraSpeed = 10f; //相机速度参数暂时没使用
    public float cameraClostLimit = 0.5f;
    public float cameraFarLimit = 5.0f;

    protected SimpleTouchController cameraController;
    protected PostProcessVolume postProcessVolume;
    protected DepthOfField depthOfField;

    protected virtual void Awake() {
        // 获取相机位置控制器
        List<SimpleTouchController> controllerUIs = new List<SimpleTouchController>(FindObjectsOfType<SimpleTouchController>());
        foreach (var controllerUI in controllerUIs)
        {
            if (controllerUI.name.Contains("Right")){
                cameraController = controllerUI;
            }
        }

        // 获取后期组件
        postProcessVolume = FindObjectOfType<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out depthOfField);

        // 恢复相机位置
        if (savedCameraPos != Vector3.zero) {
            transform.localPosition = savedCameraPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 如果在限制范围内, 移动相机
        if  (cameraController.GetTouchPosition.y != 0 &&
            ((cameraController.GetTouchPosition.y > 0 && transform.localPosition.x >= cameraClostLimit && transform.localPosition.y >= cameraClostLimit && transform.localPosition.z >= cameraClostLimit) ||
            (cameraController.GetTouchPosition.y < 0 && transform.localPosition.x <= cameraFarLimit && transform.localPosition.y <= cameraFarLimit && transform.localPosition.z <= cameraFarLimit)))
        {
            // 移动相机
            transform.position += cameraController.GetTouchPosition.y * transform.forward * Time.unscaledDeltaTime * cameraSpeed;
            // 保存位置
            savedCameraPos = transform.localPosition;
            // 配置后期景深
            depthOfField.focalLength.value = 1.526941f / transform.localPosition.magnitude * 24;
        }
    }
}
