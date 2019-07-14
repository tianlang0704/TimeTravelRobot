using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;

    private GameLogicManager GameLogicManager;

    private void Awake() {
        GameLogicManager = FindObjectOfType<GameLogicManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Time.deltaTime * bulletSpeed * transform.forward;
    }

    private void OnTriggerEnter(Collider other) {
        GameLogicManager.OnBulletHit(this, other.gameObject);
    }
}
