using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeSlow : Bullet
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override BulletType getBulletType() {
        return BulletType.TimeSlow;
    }
}
