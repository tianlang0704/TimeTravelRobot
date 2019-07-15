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
                resumeTime();
            }else{
                slowDownTime();
            }
		}
    }

    public void slowDownOne(TimeScaledGO tgo) {
        foreach (var one in tgoList)
        {
            if (one != tgo) {
                one.isAffectedByTimeScale = false;
            }else{
                one.isAffectedByTimeScale = true;
            }
        }
        slowDownTime();
    }

    public void slowDownTime() {
        Time.timeScale = slowDownTimeScale;
        // Time.fixedDeltaTime /= slowDownTimeScale;
    }

    public void resumeTime() {
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
