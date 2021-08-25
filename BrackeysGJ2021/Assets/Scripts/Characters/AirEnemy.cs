using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elements;

public class AirEnemy : EnemyManager
{
    private void Start()
    {
        GetPlayerTransforms();
        myElement = Element.Air;
    }
    private void FixedUpdate()
    {
        EnemyMovement();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
