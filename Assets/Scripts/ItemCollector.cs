using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    static private int cherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;
    private void Start()
    {
        cherriesText.text = "Cherries: " + cherries;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;

        }

        if (collision.gameObject.CompareTag("HeartItem"))
        {
            HealthSystem.Health++;
            Destroy(collision.gameObject);
        }
    }
}
