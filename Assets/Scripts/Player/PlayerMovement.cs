using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Mengambil informasi dari Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Kalkulasi awal untuk moveVelocity, moveFriction, dan stopFriction
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        // Logika pergerakan Player menggunakan input
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Menggunakan Rigidbody2D untuk menggerakkan Player (dikali 10 untuk demo)
        rb.velocity = moveDirection * moveVelocity * Time.fixedDeltaTime * 10;
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );
    }

    public Vector2 GetFriction()
    {
        // Nilai gesekan tergantung kondisi bergerak atau berhenti
        return moveDirection != Vector2.zero ? moveFriction : stopFriction;
    }

    public void MoveBound()
    {
        // Isi kosong saja dulu
    }

    public bool IsMoving()
    {
        // true jika Player bergerak
        return rb.velocity != Vector2.zero;
    }
}
