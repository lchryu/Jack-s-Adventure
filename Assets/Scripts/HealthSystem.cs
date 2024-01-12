using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static int Health = 2;

    public int NumberOfHearts;

    public Image[] Hearts;

    public Sprite FullHeart;

    public Sprite EmptyHeart;
    // Update is called once per frame
    void Update()
    {
        if (Health > NumberOfHearts) Health = NumberOfHearts;
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].sprite = i < Health ? FullHeart : EmptyHeart;

            Hearts[i].enabled = i < NumberOfHearts;
        }
    }
}
