﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    // tạm thời bỏ cái này đi vì đã sử dụng audio manager
    //[SerializeField] private AudioSource deathSoundEffect;
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
                GameOver();
            }
        }
    }

    private void Die()
    {
        // tạm thời bỏ cái này đi vì đã sử dụng audio manager
        //deathSoundEffect.Play();
        audioManager.PlaySFX(audioManager.death);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Instead of reloading the scene, reset the player's position
        transform.position = respawnPoint.position;
        // You can also reset any other necessary variables or components here
        // For example, you might want to reset the player's velocity
        rb.bodyType = RigidbodyType2D.Dynamic;


        // If needed, you can deactivate the death animation trigger
        //anim.ResetTrigger("death");

        anim.SetTrigger("alive");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("End Screen");
    }
}
