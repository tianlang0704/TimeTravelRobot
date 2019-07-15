using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public enum SkillType
    {
        SSS = 0,
        Main = 1,
        Second = 2
    }

    [System.Serializable] public class CDInfo {
        public float cd;
        public float timeStamp;
    }
    
    public List<CDInfo> cdInfoList = new List<CDInfo>();

    private float sssTimestamp = -1f;
    private TimeManager timeManager;
    private PlayerManager playerManager;
    private GameLogicManager gameLogicManager;
    private Text mainBtnText;
    private Text secondBtnText;
    private Text sssBtnText;

    private void Awake() {
        timeManager = FindObjectOfType<TimeManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        gameLogicManager = FindObjectOfType<GameLogicManager>();
        mainBtnText = FindObjectOfType<MainShootButton>().GetComponentInChildren<Text>();
        secondBtnText = FindObjectOfType<SecondShootButton>().GetComponentInChildren<Text>();
        sssBtnText = FindObjectOfType<SSSButton>().GetComponentInChildren<Text>();

        // 保证最开始低于CD的几秒钟时间计算正确
        foreach (var cdInfo in cdInfoList) {
            cdInfo.timeStamp = -cdInfo.cd;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSkillButtonText();
    }

    private void updateSkillButtonText() {
        float timeNow = Time.unscaledTime;
        
        CDInfo mainCDInfo = cdInfoList[(int)SkillType.Main];
        float mainCD = mainCDInfo.timeStamp + mainCDInfo.cd - timeNow;
        if (mainCD > 0) {
            mainBtnText.text = Mathf.Ceil(mainCD).ToString();
        }else{
            mainBtnText.text = "M";
        }

        CDInfo secondCDInfo = cdInfoList[(int)SkillType.Second];
        float secondCD = secondCDInfo.timeStamp + secondCDInfo.cd - timeNow;
        if (secondCD > 0) {
            secondBtnText.text = Mathf.Ceil(secondCD).ToString();
        }else{
            secondBtnText.text = "S";
        }

        CDInfo sssCDInfo = cdInfoList[(int)SkillType.SSS];
        float sssCD = sssCDInfo.timeStamp + sssCDInfo.cd - timeNow;
        if (sssCD > 0) {
            sssBtnText.text = Mathf.Ceil(sssCD).ToString();
        }else{
            sssBtnText.text = "SSS";
        }
    }

    public void stamp(SkillManager.SkillType bulletType) {
        cdInfoList[(int)bulletType].timeStamp = Time.unscaledTime;
    }

    public bool isReady(SkillManager.SkillType bulletType) {
        CDInfo cdInfo = cdInfoList[(int)bulletType];
        return Time.unscaledTime - cdInfo.timeStamp > cdInfo.cd;
    }

    public void SSS() {
        if (Time.unscaledTime - sssTimestamp < 1f) { return; }
        sssTimestamp = Time.unscaledTime;

        // 如果在Ghost状态, 退出
        if (playerManager.isGhostExist()) {
            playerManager.exitGhostState();
            return;
        }

        // 检查CD
        if (!isReady(SkillType.SSS)) { return; }
        stamp(SkillType.SSS);

        // 进入Ghost状态
        playerManager.enterGhostState();
    }
}
