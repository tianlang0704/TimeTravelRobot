﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : TimeScaledGO
{
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

    private void walk()
    {
        float nowSpeed = getNowSpeed();
        if (nowSpeed > 0)
        {
            anim.SetBool("Walk_Anim", true);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }

        float deltaTime;
        TimeScaledGO tgo = GetComponent<TimeScaledGO>();
        if (tgo != null) {
            deltaTime = tgo.getDeltaTime();
        }else{
            deltaTime = Time.deltaTime;
        }

        transform.position += transform.forward * nowSpeed * deltaTime;
        transform.rotation = getRotation();
    }

    private Quaternion getRotation()
    {
        return Quaternion.Euler(0, 131.096f, 0);
    }

    private float getNowSpeed()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("anim_open"))
        {
            return 0;
        }
        return speed;
    }
}
