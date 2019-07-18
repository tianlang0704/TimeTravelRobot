using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 可减速物件控制器
public class TimeScaledGO : MonoBehaviour
{
    // 物件的现在时间规格
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

    //设置是否受时间控制器设置的时间影响
    public void setAnimationAffectedByTimeScale(bool b) {
        Animator animator = GetComponent<Animator>();
        if (animator == null) { return; }

        if (b) {
            animator.updateMode = AnimatorUpdateMode.Normal;
        }else{
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    // 获取用来做计算的时间倍数
    public float getTimeScale() {
        if (isAffectedByTimeScale) {
            return Time.timeScale * timeScale;
        }else{
            return timeScale / Time.timeScale;
        }
    }

    // 获取用来计算的DT
    public float getDeltaTime() {
        return Time.deltaTime * getTimeScale();
    }

    // 获取用来计算的FDT
    public float getFixedDeltaTime() {
        return Time.fixedDeltaTime * getTimeScale();
    }
}
