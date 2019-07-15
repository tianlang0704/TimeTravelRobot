using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSButton : MonoBehaviour
{
    public bool isShoot = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void touchStart() {
        isShoot = true;
    }

    public void touchEnd() {
        isShoot = false;
    }
}
