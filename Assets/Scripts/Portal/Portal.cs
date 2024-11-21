using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Vector2 newPosition;
    private Vector2 moveDirection;
    private bool isActive = false; // Menyimpan status apakah asteroid aktif bergerak

    private void Start()
    {
        ChangePosition(); // Inisialisasi posisi baru saat game dimulai
        SetAsteroidVisibility(false); // Sembunyikan asteroid di awal
    }

    private void Update()
    {
        // Cek apakah Player memiliki weapon
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && !isActive)
        {
            Weapon weapon = player.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                // Jika Player memiliki weapon, aktifkan asteroid dan mulai gerakan
                isActive = true;
                SetAsteroidVisibility(true);
            }
        }

        // Jika asteroid aktif, lakukan pergerakan dan batasan
        if (isActive)
        {
            // Gerakkan asteroid menuju newPosition
            transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

            // Batasi pergerakan asteroid agar tidak keluar dari batas kamera
            MoveBound();
        }
    }

    private void MoveBound()
    {
        Vector3 pos = transform.position;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(pos);

        bool hitBoundary = false;

        // Periksa apakah asteroid menyentuh batas viewport
        if (viewPos.x <= 0.03f || viewPos.x >= 0.99f)
        {
            moveDirection.x = -moveDirection.x; // Balik arah horizontal
            hitBoundary = true;
        }
        if (viewPos.y <= 0.01f || viewPos.y >= 0.91f)
        {
            moveDirection.y = -moveDirection.y; // Balik arah vertikal
            hitBoundary = true;
        }

        // Jika asteroid menyentuh batas, ubah posisi tujuan ke arah yang berlawanan
        if (hitBoundary)
        {
            ChangePosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player collided with the asteroid, loading Main scene...");
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.LoadScene("Main");
        }
        else
        {
            Debug.LogWarning("LevelManager tidak ditemukan di scene!");
        }
    }
}


    private void ChangePosition()
    {
        // Atur arah gerakan baru secara acak
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        // Tentukan posisi baru yang lebih jauh dari batas viewport
        newPosition = (Vector2)transform.position + moveDirection * 5f;
    }

    private void SetAsteroidVisibility(bool isVisible)
    {
        // Mengatur visibilitas dan collider asteroid
        GetComponent<SpriteRenderer>().enabled = isVisible;
        GetComponent<Collider2D>().enabled = isVisible;
    }
}

