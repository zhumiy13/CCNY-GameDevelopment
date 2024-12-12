using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;  // Import TextMeshPro namespace
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // The target player
    public PlayerMovement Target;

    // How fast does the monster move?
    public float Speed = 4;

    // Reference to Rigidbody2D for movement
    public Rigidbody2D RB;

    // Health of the monster
    public float Health = 10;
    public float MaxHealth = 10;

    // Reference to the TextMeshProUGUI to display health
    public TextMeshProUGUI HealthText;

    
    void Start()
    {
        // Ensure there is a target player
        if (Target == null) Target = PlayerMovement.Player;

        // Initialize health text
        if (HealthText != null)
        {
            UpdateHealthText();
        }
    }

    void Update()
    {
        // If there is no target, stop chasing
        if (Target == null) return;

        // Calculate direction to the player
        Vector3 offset = Target.transform.position - transform.position;
        // Normalize and apply speed
        RB.velocity = offset.normalized * Speed;

        // Additional logic for chasing or catching player can be here
    }

    // This function is called when the monster is hit
    public void GetShot()
    {
        // Decrease health
        Health--;
        if (Health <= 0)
        {
            // If health reaches 0, destroy the monster
            Destroy(gameObject);
        }

        // Update the health text whenever the monster's health changes
        UpdateHealthText();
    }

    // This function updates the health text UI element
    void UpdateHealthText()
    {
        if (HealthText != null)
        {
            HealthText.text = "Health: " + Health + "/" + MaxHealth;
        }
    }
}

