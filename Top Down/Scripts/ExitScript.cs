using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ExitController : MonoBehaviour
{
    public GameObject exitBorder;  // The physical border blocking the exit
    public Collider2D exitBorderCollider;  // The collider on the exit border that blocks the player
    public MonsterController[] monsters;  // The list of all monsters to track defeat

    private bool exitUnlocked = false;  // Track if the exit is unlocked

    void Start()
    {
        // Initially, block the exit by keeping the collider enabled
        if (exitBorderCollider != null)
        {
            exitBorderCollider.enabled = true;  // Ensure it's blocking the player
        }

        // Get all monsters in the scene
        monsters = FindObjectsOfType<MonsterController>();
    }

    void Update()
    {
        // Check if all monsters are defeated
        if (!exitUnlocked && AllMonstersDefeated())
        {
            // Unlock the exit
            UnlockExit();
        }
    }

    // Function to check if all monsters are defeated
    bool AllMonstersDefeated()
    {
        foreach (var monster in monsters)
        {
            if (monster != null && monster.Health > 0)
            {
                return false;  // If any monster still has health, return false
            }
        }
        return true;  // If all monsters are defeated, return true
    }

    // Function to unlock the exit (open the border)
    void UnlockExit()
    {
        exitUnlocked = true;

        // Disable the collider to allow the player to pass
        if (exitBorderCollider != null)
        {
            exitBorderCollider.enabled = false;  // Disable the collider to open the exit
        }

        // Optional: Move the border to make it open
        if (exitBorder != null)
        {
            // Example of moving the exit border up, you can customize this as needed
            exitBorder.transform.position += new Vector3(0, 3, 0);  // Move the border up by 3 units
        }

        // Optionally: Fade out, animate, or do something visual when the border "opens"
        Debug.Log("Exit Unlocked! The player can now exit.");
    }
}

