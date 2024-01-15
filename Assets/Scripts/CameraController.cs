//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    [SerializeField] private Transform player;


//    private bool getPLayer()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//        return GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//    }
//    void Update()
//    {
//        if (!getPLayer() && player == null) { return; }
//        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        // Gọi hàm để tìm và gán player trong Start thay vì trong Update
        //FindPlayer();
    }

    private void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<Transform>();
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng với tag 'Player'. Hãy đảm bảo rằng bạn đã đặt đúng tag cho đối tượng Player.");
        }
    }

    void Update()
    {
        // Kiểm tra xem player có tồn tại không trước khi cố gắng sử dụng nó
        if (player == null)
        {
            // Nếu không tìm thấy player, thì cố gắng tìm lại
            FindPlayer();

            // Nếu vẫn không tìm thấy, thoát khỏi Update
            if (player == null)
            {
                return;
            }
        }

        // Cập nhật vị trí của Camera theo vị trí của player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
