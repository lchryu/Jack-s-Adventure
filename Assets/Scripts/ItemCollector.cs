using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    static public int cherries = 0;

    [SerializeField] private Text cherriesText;
    
    // tạm thời bỏ cái này đi vì đã sử dụng audio manager
    //[SerializeField] private AudioSource collectionSoundEffect;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        cherriesText.text = "Cherries: " + cherries;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            // tạm thời bỏ cái này đi vì đã sử dụng audio manager
            //collectionSoundEffect.Play();
            audioManager.PlaySFX(audioManager.collect);
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;

        }

        if (collision.gameObject.CompareTag("HeartItem"))
        {
            HealthSystem.Health++;
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.collect);
        }
    }
}
