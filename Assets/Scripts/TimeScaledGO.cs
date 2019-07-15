using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaledGO : MonoBehaviour
{
    public float timeScale = 1f;
    public bool isAffectedByTimeScale {
        set {
            isAffectedByTimeScaleInternal = value;
            setAnimationAffectedByTimeScale(value);
        }
        get{
            return isAffectedByTimeScaleInternal;
        }
    }
    public bool isAffectedByTimeScaleInternal = true;

    private TimeManager timeManager;

    protected virtual void Awake() {
        timeManager = FindObjectOfType<TimeManager>();
        setAnimationAffectedByTimeScale(isAffectedByTimeScaleInternal);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        timeManager.registerGO(this);
    }

    protected virtual void OnDestroy() {
        timeManager.unregisterGO(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAnimationAffectedByTimeScale(bool b) {
        Animator animator = GetComponent<Animator>();
        if (animator == null) { return; }

        if (b) {
            animator.updateMode = AnimatorUpdateMode.Normal;
        }else{
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    public float getTimeScale() {
        if (isAffectedByTimeScale) {
            return Time.timeScale * timeScale;
        }else{
            return timeScale / Time.timeScale;
        }
    }

    public float getDeltaTime() {
        return Time.deltaTime * getTimeScale();
    }

    public float getFixedDeltaTime() {
        return Time.fixedDeltaTime * getTimeScale();
    }
}
