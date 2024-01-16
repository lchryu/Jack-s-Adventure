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
        cherriesText = GameObject.FindGameObjectWithTag("CherriesText").GetComponent<Text>();
        // Log the result
        if (cherriesText != null)
        {
            Debug.Log("cherriesText successfully obtained!");
        }
        else
        {
            Debug.LogError("Failed to get cherriesText!");
        }
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

    public static void SaveCherriesToPlayerPrefs()
    {
        // Lưu số lượng cherry vào PlayerPrefs khi người chơi chết
        int currentCherries = PlayerPrefs.GetInt("Cherries", 0);
        currentCherries += ItemCollector.cherries; // Thêm vào số lượng cherry đã kiếm được
        PlayerPrefs.SetInt("Cherries", currentCherries);
        PlayerPrefs.Save();

        cherries = 0;
        Debug.Log("current cherry" + currentCherries);
    }
}
