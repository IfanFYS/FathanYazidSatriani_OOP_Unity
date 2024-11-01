using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Static instance dari Player yang dapat diakses secara global
    public static Player Instance { get; private set; }

    public PlayerMovement playerMovement;
    private Animator animator;

    void Awake()
    {
        // Singleton checker
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika ada instance, hancurkan GameObject yang duplikat
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Mengambil informasi dari script PlayerMovement
        playerMovement = GetComponent<PlayerMovement>();

        // Mengambil informasi dari Animator dari GameObject EngineEffect
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Memanggil method Move dari PlayerMovement
        playerMovement.Move();
    }

    void LateUpdate()
    {
        // Mengatur nilai Bool dari parameter IsMoving di Animator
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}

