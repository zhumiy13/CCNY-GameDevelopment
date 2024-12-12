using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    public PlayerMovement Target;
    public float Speed = 6f;
    public Rigidbody2D RB;
    
    private float direction = 1f;  
    private float minX = -1f;  // Minimum X boundary
    private float maxX = 16f;   // Maximum X boundary

    void Start()
    {
        if (Target == null) Target = PlayerMovement.Player;
        if (RB == null) RB = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        // Move the bug left or right at a constant speed
        Vector2 currentPosition = RB.position;
        currentPosition.x += direction * Speed * Time.deltaTime;  // Move horizontally
        
        // Check if the bug hits the boundaries
        if (currentPosition.x <= minX || currentPosition.x >= maxX)
        {
            direction *= -1f;  // Reverse direction when hitting boundaries
        }
        
        RB.MovePosition(currentPosition);
    }

    public void GetShot()
    {
        Destroy(gameObject);
    }
} 





