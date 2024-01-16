//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Spear : MonoBehaviour
//{
//    [SerializeField] public float speed = 2f;
//    private void Start()
//    {

//    }
//    void Update()
//    {
//        transform.Translate(Vector3.right * speed * Time.deltaTime);
//        if (transform.position.y > 6)
//            DestroyImmediate(this.gameObject);
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Destroy(this.gameObject);
//            Debug.Log("destroy spear");
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spear : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    private float initialPositionX; // Vị trí khởi tạo của Spear
    private float direction = 1f; // Hướng mặc định là right

    void Start()
    {
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // Di chuyển theo hướng được truyền từ Devil
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        CheckDestroyCondition();
    }

    // Truyền hướng từ Devil
    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            HealthSystem.Health--;
            Debug.Log("destroy spear");
            if (HealthSystem.Health <= 0)
            {
                HealthSystem.ResetHealthSystem();
                ItemCollector.SaveCherriesToPlayerPrefs();
                SceneManager.LoadScene("End Screen");
            }
        }
    }
    void CheckDestroyCondition()
    {
        // Khoảng cách tối đa Spear có thể đi từ vị trí khởi tạo của Devil
        float maxDistance = 10f;

        // Nếu Spear đi xa quá maxDistance, hủy nó
        if (Mathf.Abs(transform.position.x - initialPositionX) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
