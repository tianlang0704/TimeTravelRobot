using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownTimeScale = 0.1f;

    private List<TimeScaledGO> tgoList = new List<TimeScaledGO>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            if (Time.timeScale == slowDownTimeScale) {
                slowDownAllButOne();
            }else{
                resumeAll();
            }
		}
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
        foreach (var one in tgoList)
        {
            if (tgo && one == tgo) {
                one.isAffectedByTimeScale = false;
            }else{
                one.isAffectedByTimeScale = true;
            }
        }
    }

    public void resumeAll() {
        foreach (var one in tgoList)
        {
            one.isAffectedByTimeScale = false;
        }
        resumeTime();
    }

    public void slowDownTime() {
        if (Time.timeScale != slowDownTimeScale) {
            Time.fixedDeltaTime *= slowDownTimeScale;
        }
        Time.timeScale = slowDownTimeScale;
    }

    public void resumeTime() {
        if (Time.timeScale != 1) {
            Time.fixedDeltaTime /= slowDownTimeScale;
        }
        Time.timeScale = 1;
        // Time.fixedDeltaTime *= slowDownTimeScale;
    }

    public void registerGO(TimeScaledGO tgo) {
        tgoList.Add(tgo);
    }

    public void unregisterGO(TimeScaledGO tgo) {
        tgoList.Remove(tgo);
    }
}
