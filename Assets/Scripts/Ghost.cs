using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Player
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        gameLogicManager.OnGhostHit(this, other.gameObject);
    }
}
