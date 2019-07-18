using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraControllerForGhost : CameraController
{
    Vignette vignette;
    protected override void Awake() {
        base.Awake();
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 给幽灵的相机附上遮罩
        vignette.active = true;
        vignette.intensity.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        // 相机随着幽灵销毁的时候, 取消遮罩
        vignette.active = false;
    }
}
