using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine;
using TMPro; // Make sure to include the TextMeshPro namespace
using UnityEngine.SceneManagement; // For scene management

using UnityEngine;
using TMPro; // Make sure to include the TextMeshPro namespace
using UnityEngine.SceneManagement; // For scene management

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public TextMeshPro ScoreText;
    public float Speed = 5;
    public int Score = 0;
    public int TotalCoins = 0; // New variable to track total coins
    public SpriteRenderer SR;
    public Color TargetColor = Color.red;

    void Start()
    {
        UpdateScore();
        // Initialize TotalCoins if needed (for example, if you know the total beforehand)
        TotalCoins = FindObjectsOfType<CoinScript>().Length; // Count all coins in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SR.color = TargetColor;
        }

        Vector2 vel = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.RightArrow)) vel.x = Speed;
        if (Input.GetKey(KeyCode.LeftArrow)) vel.x = -Speed;
        if (Input.GetKey(KeyCode.UpArrow)) vel.y = Speed;
        if (Input.GetKey(KeyCode.DownArrow)) vel.y = -Speed;

        RB.velocity = vel;
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 position = transform.position;
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            Die();
        }

        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        if (coin != null)
        {
            coin.GetBumped();
            Score++;
            UpdateScore();

            // Check if the player has collected all coins
            if (Score >= TotalCoins)
            {
                Win();
            }
        }
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    // New function to handle winning the game
    public void Win()
    {
        ScoreText.text = "You Win!";
        // Optionally: Add any additional logic for winning (e.g., stopping movement)
        RB.velocity = Vector2.zero; // Stop player movement
        // You might also want to disable controls or show a win screen after a delay
    }
}

