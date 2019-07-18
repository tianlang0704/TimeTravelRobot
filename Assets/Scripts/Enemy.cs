using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人控制器
public class Enemy : TimeScaledGO
{
    // 敌人移动速度
    public float speed = 0.05f;

    private Animator anim;

    // Use this for initialization
    override protected void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    // 移动数据逻辑和动画
    private void walk()
    {
        // 获取现在移动速度, 如果有速度, 播放移动动画, 如果没有速度, 不播放移动动画
        float nowSpeed = getNowSpeed();
        if (nowSpeed > 0)
        {
            anim.SetBool("Walk_Anim", true);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }

        // 根据时间控制模块来获取控制移动距离的时间参数
        float deltaTime;
        TimeScaledGO tgo = GetComponent<TimeScaledGO>();
        if (tgo != null) {
            deltaTime = tgo.getDeltaTime();
        }else{
            deltaTime = Time.deltaTime;
        }

        // 实际移动和转向
        transform.position += transform.forward * nowSpeed * deltaTime;
        transform.rotation = getRotation();
    }

    // 获取方向, 目前为固定方向
    private Quaternion getRotation()
    {
        return Quaternion.Euler(0, 131.096f, 0);
    }

    // 获取速度, 目前在展开时没有速度
    private float getNowSpeed()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("anim_open"))
        {
            return 0;
        }
        return speed;
    }
}
