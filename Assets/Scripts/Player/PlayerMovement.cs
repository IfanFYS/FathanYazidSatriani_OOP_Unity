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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = moveDirection * moveVelocity * Time.fixedDeltaTime * 20;
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );

        MoveBound();
    }
    public void MoveBound()
    {
        Vector3 pos = transform.position;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(pos);

        viewPos.x = Mathf.Clamp(viewPos.x, 0.03f, 0.97f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.01f, 0.9f);

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    public Vector2 GetFriction()
    {
        return moveDirection != Vector2.zero ? moveFriction : stopFriction;
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }
}