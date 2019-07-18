using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 时间管理器
public class TimeManager : MonoBehaviour
{
    // 减速时间设置
    public float slowDownTimeScale = 0.1f;
    // 记录是否已经减速的状态
    public bool isAllSlowDown = false;
    // 所有可以减速物件的列表
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

    // 只减速一个物件
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

    // 减速一个物件除外的所有物件
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

    // 恢复时间
    public void resumeAll() {
        foreach (var one in tgoList)
        {
            one.isAffectedByTimeScale = false;
        }
        resumeTime();
        isAllSlowDown = false;
    }

    // 时间减慢内部机制
    private void slowDownTime() {
        if (Time.timeScale != slowDownTimeScale) {
            Time.fixedDeltaTime *= slowDownTimeScale;
        }
        Time.timeScale = slowDownTimeScale;
    }

    // 时间恢复内部机制
    private void resumeTime() {
        if (Time.timeScale != 1) {
            Time.fixedDeltaTime /= slowDownTimeScale;
        }
        Time.timeScale = 1;
    }

    // 注册一个可减速物件
    public void registerGO(TimeScaledGO tgo) {
        tgoList.Add(tgo);

        // 设置除了Ghost之外的慢动作
        Ghost g = tgo.GetComponent<Ghost>();
        if (g == null) {
            tgo.isAffectedByTimeScale = isAllSlowDown;
        }
    }

    // 反注册一个可减速物件
    public void unregisterGO(TimeScaledGO tgo) {
        tgoList.Remove(tgo);
    }
}
