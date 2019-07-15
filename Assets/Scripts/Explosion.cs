using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
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

    public void onAnimationEnd() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        glm.OnExplosionHit(this, other.gameObject);
    }
}
