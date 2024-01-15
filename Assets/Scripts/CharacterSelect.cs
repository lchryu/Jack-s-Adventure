//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharacterSelect : MonoBehaviour
//{
//    public GameObject[] skins;
//    public int selectedCharacter;
//    private void Awake()
//    {
//        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
//        foreach (GameObject player in skins) { 
//            player.SetActive(false);
//        }
//        skins[selectedCharacter].SetActive(true);
//    }
//    public void ChangeNext()
//    {
//        skins[selectedCharacter].SetActive(false);
//        selectedCharacter++;
//        if (selectedCharacter == skins.Length) selectedCharacter = 0;
//        skins[selectedCharacter].SetActive(true);

//        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
//    }
//    public void ChangePrevious()
//    {
//        skins[selectedCharacter].SetActive(false);
//        selectedCharacter--;
//        if (selectedCharacter == -1) selectedCharacter = skins.Length - 1;
//        skins[selectedCharacter].SetActive(true);

//        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CharacterSelect : MonoBehaviour
//{
//    public GameObject[] skins;
//    public int selectedCharacter;
//    public Text cherryCountText; // Thêm reference đến Text

//    private void Awake()
//    {
//        cherryCountText = GameObject.FindGameObjectWithTag("BankCherry").GetComponent<Text>();
//        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
//        foreach (GameObject player in skins)
//        {
//            player.SetActive(false);
//        }
//        skins[selectedCharacter].SetActive(true);
//    }

//    void Start()
//    {
//        UpdateCherryCountText(); // Gọi hàm để cập nhật Text số cherry
//    }

//    void UpdateCherryCountText()
//    {
//        int cherryCount = PlayerPrefs.GetInt("Cherries", 0);
//        cherryCountText.text = cherryCount.ToString();
//    }

//    public void ChangeNext()
//    {
//        ChangeCharacter(1);
//    }

//    public void ChangePrevious()
//    {
//        ChangeCharacter(-1);
//    }

//    public void SelectCharacter()
//    {
//        // Kiểm tra nếu nhân vật đã được mua
//        bool characterPurchased = PlayerPrefs.GetInt("Character" + selectedCharacter + "Purchased", 0) == 1;

//        if (characterPurchased)
//        {
//            // Nếu đã mua, chọn nhân vật
//            skins[selectedCharacter].SetActive(true);
//            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
//            Debug.Log($"Đã chọn nhân vật số {selectedCharacter}");
//        }
//        else
//        {
//            // Nếu chưa mua, hiển thị thông báo hoặc mở giao diện mua
//            Debug.Log("Bạn chưa mua nhân vật này");
//        }
//    }

//    void ChangeCharacter(int direction)
//    {
//        skins[selectedCharacter].SetActive(false);
//        selectedCharacter += direction;
//        if (selectedCharacter >= skins.Length) selectedCharacter = 0;
//        else if (selectedCharacter < 0) selectedCharacter = skins.Length - 1;
//        skins[selectedCharacter].SetActive(true);
//    }

//    public void PurchaseCharacter()
//    {
//        int cherryCount = PlayerPrefs.GetInt("Cherries", 0);

//        // Thay đổi giá trị này theo giá của nhân vật
//        int characterCost = 50;

//        if (cherryCount >= characterCost)
//        {
//            // Trừ cherry khi mua nhân vật
//            cherryCount -= characterCost;
//            PlayerPrefs.SetInt("Cherries", cherryCount);

//            // Đặt trạng thái đã mua cho nhân vật
//            PlayerPrefs.SetInt("Character" + selectedCharacter + "Purchased", 1);

//            // Cập nhật Text số cherry
//            UpdateCherryCountText();

//            // Chọn nhân vật sau khi mua
//            SelectCharacter();
//        }
//        else
//        {
//            // Hiển thị thông báo hoặc mở giao diện không đủ cherry
//            Debug.Log("Not enough cherries to purchase the character.");
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    private int selectedCharacter;
    private Text cherryCountText;
    private Text notificationText, priceText;

    // Thay đổi giá trị này theo giá của nhân vật
    [SerializeField] private int characterCost = 50;
    private void Awake()
    {
        cherryCountText = GameObject.FindGameObjectWithTag("BankCherry").GetComponent<Text>();
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        notificationText = GameObject.FindGameObjectWithTag("Notifi").GetComponent<Text>();
        priceText = GameObject.FindGameObjectWithTag("PriceText").GetComponent<Text>();
        priceText.text = characterCost.ToString();

        if (notificationText != null) Debug.Log("noti ok");
        else Debug.Log("noti null");
        // Kiểm tra nếu nhân vật số 0 chưa được mua, thì mua nó mặc định
        bool characterPurchased = PlayerPrefs.GetInt("Character0Purchased", 0) == 1;
        if (!characterPurchased)
        {
            // Thay đổi giá trị này theo giá của nhân vật số 0
            int characterCost = 0; // Giả sử nhân vật số 0 có giá là 0 cherry

            int cherryCount = PlayerPrefs.GetInt("Cherries", 0);

            if (cherryCount >= characterCost)
            {
                // Trừ cherry khi mua nhân vật số 0
                cherryCount -= characterCost;
                PlayerPrefs.SetInt("Cherries", cherryCount);

                // Đặt trạng thái đã mua cho nhân vật số 0
                PlayerPrefs.SetInt("Character0Purchased", 1);
                Debug.Log("Đã mua nhân vật số 0 với giá 0");
                // Cập nhật Text số cherry
                UpdateCherryCountText();
            }
            else
            {
                // Hiển thị thông báo hoặc mở giao diện không đủ cherry
                Debug.Log("Not enough cherries to purchase the default character.");
            }
        }

        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }
        skins[selectedCharacter].SetActive(true);
    }

    void Start()
    {
        UpdateCherryCountText();
        SelectCharacter(); // Chọn nhân vật mặc định khi bắt đầu
    }

    void UpdateCherryCountText()
    {
        int cherryCount = PlayerPrefs.GetInt("Cherries", 0);
        cherryCountText.text = cherryCount.ToString();
    }

    public void ChangeNext()
    {
        ChangeCharacter(1);
    }

    public void ChangePrevious()
    {
        ChangeCharacter(-1);
    }

    public void SelectCharacter()
    {
        // Kiểm tra nếu nhân vật đã được mua
        bool characterPurchased = PlayerPrefs.GetInt("Character" + selectedCharacter + "Purchased", 0) == 1;

        if (characterPurchased)
        {
            // Nếu đã mua, chọn nhân vật
            skins[selectedCharacter].SetActive(true);
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
            Debug.Log($"Đã chọn nhân vật số {selectedCharacter}");
            notificationText.text = $"Selected skin number {selectedCharacter}";
        }
        else
        {
            // Nếu chưa mua, hiển thị thông báo hoặc mở giao diện mua
            Debug.Log("Bạn chưa mua nhân vật này");
            notificationText.text = "You have not purchased this skin yet";
        }
    }

    void ChangeCharacter(int direction)
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter += direction;
        if (selectedCharacter >= skins.Length) selectedCharacter = 0;
        else if (selectedCharacter < 0) selectedCharacter = skins.Length - 1;
        skins[selectedCharacter].SetActive(true);
    }

    public void PurchaseCharacter()
    {
        // Kiểm tra nếu nhân vật đã được mua, không thực hiện mua lại nếu đã mua
        bool characterPurchased = PlayerPrefs.GetInt("Character" + selectedCharacter + "Purchased", 0) == 1;

        if (!characterPurchased)
        {
            int cherryCount = PlayerPrefs.GetInt("Cherries", 0);



            if (cherryCount >= characterCost)
            {
                // Trừ cherry khi mua nhân vật
                cherryCount -= characterCost;
                PlayerPrefs.SetInt("Cherries", cherryCount);

                // Đặt trạng thái đã mua cho nhân vật
                PlayerPrefs.SetInt("Character" + selectedCharacter + "Purchased", 1);

                // Cập nhật Text số cherry
                UpdateCherryCountText();

                // Chọn nhân vật sau khi mua
                SelectCharacter();
            }
            else
            {
                // Hiển thị thông báo hoặc mở giao diện không đủ cherry
                Debug.Log("Not enough cherries to purchase the character.");
                notificationText.text = "Not enough cherries";
            }
        }
        else
        {
            Debug.Log("Nhân vật này đã được mua rồi");
            notificationText.text = "This character has already been purchased";
        }
    }
}
