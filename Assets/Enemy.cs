using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.05f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
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

        transform.position += transform.forward * nowSpeed * Time.deltaTime;
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
