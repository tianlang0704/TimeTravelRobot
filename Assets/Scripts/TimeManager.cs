using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownTimeScale = 0.1f;
    public bool isAllSlowDown = false;
    private List<TimeScaledGO> tgoList = new List<TimeScaledGO>();

    private void Awake() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void slowDownOne(TimeScaledGO tgo) {
        slowDownTime();
        foreach (var one in tgoList)
        {
            if (one != tgo) {
                one.isAffectedByTimeScale = false;
            }else{
                one.isAffectedByTimeScale = true;
            }
        }
    }

    public void slowDownAllButOne(TimeScaledGO tgo = null) {
        slowDownTime();
        foreach (var one in tgoList)
        {
            if (tgo && one == tgo) {
                one.isAffectedByTimeScale = false;
            }else{
                one.isAffectedByTimeScale = true;
            }
        }
        isAllSlowDown = true;
    }

    public void resumeAll() {
        foreach (var one in tgoList)
        {
            one.isAffectedByTimeScale = false;
        }
        resumeTime();
        isAllSlowDown = false;
    }

    private void slowDownTime() {
        if (Time.timeScale != slowDownTimeScale) {
            Time.fixedDeltaTime *= slowDownTimeScale;
        }
        Time.timeScale = slowDownTimeScale;
    }

    private void resumeTime() {
        if (Time.timeScale != 1) {
            Time.fixedDeltaTime /= slowDownTimeScale;
        }
        Time.timeScale = 1;
    }

    public void registerGO(TimeScaledGO tgo) {
        tgoList.Add(tgo);

        // 设置除了Ghost之外的慢动作
        Ghost g = tgo.GetComponent<Ghost>();
        if (g == null) {
            tgo.isAffectedByTimeScale = isAllSlowDown;
        }
    }

    public void unregisterGO(TimeScaledGO tgo) {
        tgoList.Remove(tgo);
    }
}
