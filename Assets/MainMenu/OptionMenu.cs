using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Text cherryCountText;

    // Start is called before the first frame update
    void Start()
    {
        // Lấy giá trị số lượng cherry từ PlayerPrefs
        int cherryCount = PlayerPrefs.GetInt("Cherries", 0);

        // Hiển thị số lượng cherry trong Text
        cherryCountText.text = cherryCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("from optionmenu");
    }
}
