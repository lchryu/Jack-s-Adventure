//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class roteChainBall : MonoBehaviour
//{
//    [SerializeField] float rotationSpeed = 60f;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Xoay đối tượng quanh điểm point trên trục Z
//        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
//    }
//}
using UnityEngine;

public class RotateChainBall : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 60f;
    private float currentAngle = -90f; // Góc quay hiện tại, bắt đầu từ 180 độ
    private bool isClockwise = true; // Hướng quay, theo chiều kim đồng hồ hay ngược lại
    [SerializeField] private float angleStart = -90f;
    [SerializeField] private float angleEnd = 90f;

    // Update is called once per frame
    void Update()
    {
        // Tính toán góc quay mới
        currentAngle += rotationSpeed * Time.deltaTime * (isClockwise ? 1 : -1);

        // Kiểm tra nếu đã quay đủ 180 độ, đảo chiều quay
        if (currentAngle >= angleEnd || currentAngle <= angleStart)
        {
            isClockwise = !isClockwise;
        }

        // Xoay đối tượng quanh chính nó trên trục Z
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}
