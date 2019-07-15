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
        vignette.active = true;
        vignette.intensity.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        vignette.active = false;
    }
}
