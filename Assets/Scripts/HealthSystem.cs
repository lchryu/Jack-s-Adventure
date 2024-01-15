//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class HealthSystem : MonoBehaviour
//{
//    public static int Health = 2;

//    public int NumberOfHearts;

//    public Image[] Hearts;

//    public Sprite FullHeart;

//    public Sprite EmptyHeart;
//    // Update is called once per frame
//    void Update()
//    {
//        if (Health > NumberOfHearts) Health = NumberOfHearts;
//        for (int i = 0; i < Hearts.Length; i++)
//        {
//            Hearts[i].sprite = i < Health ? FullHeart : EmptyHeart;

//            Hearts[i].enabled = i < NumberOfHearts;
//        }
//    }
//}
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
        // Kiểm tra xem mảng Hearts đã được gán giá trị chưa
        if (Hearts == null || Hearts.Length == 0)
        {
            Debug.LogError("Mảng Hearts chưa được gán giá trị. Hãy đảm bảo bạn đã gán giá trị cho mảng này trong Inspector.");
            return;
        }

        // Kiểm tra xem mảng Hearts có đủ phần tử để truy cập không
        if (Hearts.Length < NumberOfHearts)
        {
            Debug.LogError("Số lượng phần tử trong mảng Hearts không đủ để thể hiện số lượng Hearts cần thiết.");
            return;
        }

        if (Health > NumberOfHearts) Health = NumberOfHearts;

        for (int i = 0; i < NumberOfHearts; i++) // Đổi Hearts.Length thành NumberOfHearts
        {
            // Kiểm tra xem mảng Hearts[i] đã được gán giá trị chưa
            if (Hearts[i] == null)
            {
                Debug.LogError("Phần tử thứ " + i + " trong mảng Hearts chưa được gán giá trị.");
                continue;
            }

            Hearts[i].sprite = i < Health ? FullHeart : EmptyHeart;
            Hearts[i].enabled = i < NumberOfHearts;
        }
    }
}
