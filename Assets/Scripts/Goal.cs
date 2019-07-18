using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 目标管理器
public class Goal : MonoBehaviour
{
    private GameLogicManager glm;
    private void Awake() {
        glm = FindObjectOfType<GameLogicManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 目标碰撞逻辑
    private void OnTriggerEnter(Collider other) {
        glm.OnGoalHit(this, other.gameObject);
    }
}
