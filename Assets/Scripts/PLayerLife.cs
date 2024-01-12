using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    AudioManager audioManager;

    [SerializeField] private Transform respawnPoint; // Set this in the inspector

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HealthSystem.Health--;
            Die();
            if (HealthSystem.Health <= 0)
            {
                Debug.Log("Game Over!");
                SaveCherries();
                GameOver();
            }
        }
    }

    private void Die()
    {
        audioManager.PlaySFX(audioManager.death);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        // Instead of reloading the scene, reset the player's position
        transform.position = respawnPoint.position;
        rb.bodyType = RigidbodyType2D.Dynamic;

        anim.SetTrigger("alive");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("End Screen");
    }
    private void SaveCherries()
    {
        // Lưu số lượng cherry vào PlayerPrefs khi người chơi chết
        int currentCherries = PlayerPrefs.GetInt("Cherries", 0);
        currentCherries += ItemCollector.cherries; // Thêm vào số lượng cherry đã kiếm được
        PlayerPrefs.SetInt("Cherries", currentCherries);
        PlayerPrefs.Save();
        Debug.Log("current cherry" + currentCherries);
    }
}
