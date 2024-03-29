﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    SpriteRenderer sprite;

    [SerializeField] public GameObject[] movePoints; // Mảng chứa các điểm di chuyển của Devil
    public Spear spearPrefab; // Prefab của Spear
    public float speed = 1;

    private int currentMovePointIndex = 0;
    private float shotTime = 0;

    // ref -> player để jump khi đạp vào devil
    [SerializeField]private PlayerMovement playerMovement;

    void Start()
    {
        try
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
        catch (System.Exception)
        {

            throw;
        }
        if (playerMovement != null) Debug.Log("Devil.playerMove != null");
        else Debug.Log("Devil.playerMove == null");
        shotTime = Time.time;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    void Update()
    {
        MoveDevil();
        ShootSpear();
    }

    void MoveDevil()
    {
        if (movePoints.Length == 0)
        {
            Debug.LogError("No move points assigned to Devil.");
            return;
        }

        // Di chuyển đến điểm di chuyển và đảo hướng khi đến gần điểm cuối
        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentMovePointIndex].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoints[currentMovePointIndex].transform.position) < 0.1f)
        {
            currentMovePointIndex = (currentMovePointIndex + 1) % movePoints.Length;
            sprite.flipX = !sprite.flipX;
        }
    }

    void ShootSpear()
    {
        if (Time.time - shotTime > speed)
        {
            shotTime = Time.time;

            // Xác định hướng của giáo dựa trên hướng di chuyển của Devil
            float facingDirection = sprite.flipX ? -1 : 1;

            Spear newSpear = Instantiate(spearPrefab, transform.position, Quaternion.identity);

            // Truyền hướng cho giáo
            newSpear.SetDirection(facingDirection);

            // Đặt tốc độ cho giáo = 150% tốc độ di chuyển của devil
            newSpear.speed = speed * 1.5f;

            // Lật hình ảnh của giáo
            newSpear.transform.localScale = new Vector3(facingDirection, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerMovement.DoubleJump();
        }
    }
}
