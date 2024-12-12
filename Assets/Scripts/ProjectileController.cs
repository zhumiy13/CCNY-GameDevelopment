using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //My rigidbody
    public Rigidbody2D RB;
    //How fast I should fly
    public float Speed = 10;

    private void Update()
    {
        //Just go flying in the direction I'm facing!
        //It's up to the gun to rotate me so that I'm facing the correct direction
        RB.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Did what I hit have a monster script on it?
        MonsterController mon = other.gameObject.GetComponent<MonsterController>();
        BugController bug = other.gameObject.GetComponent<BugController>();
        //If so. . .
       
        if (mon != null)
        {
            //Tell them they got shot!
            mon.GetShot();
        }

        if (bug != null)
        {
            bug.GetShot();
        }
            
        
        
        //If I bump into something that isn't the player
        if (!other.gameObject.CompareTag("Player"))
        {
            //then self destruct
            Destroy(gameObject);
        }
    }
}
