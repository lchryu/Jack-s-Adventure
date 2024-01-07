using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Transform respawnPoint; // Set this in the inspector

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
        deathSoundEffect.Play();
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
        SceneManager.LoadScene(3);
    }
}
