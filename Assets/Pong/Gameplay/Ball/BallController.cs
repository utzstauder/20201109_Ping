using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private Vector3 initialPosition;

    public float initialSpeed = 5f;
    public float deviationScale = 3f;

    private void Awake()
    {
        initialPosition = transform.position;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    private void ResetBall()
    {
        // rigidbody2D.MovePosition(initialPosition);
        transform.position = initialPosition;
        rigidbody2D.velocity = Random.insideUnitCircle.normalized * initialSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // calculate deviation factor
            float deviationFactor = transform.position.y - collision.gameObject.transform.position.y;

            // normalize deviationFactor
            deviationFactor /= (collision.collider.bounds.size.y + collision.otherCollider.bounds.size.y) / 2f;

            // copy existing velocity vector
            Vector2 newVelocity = rigidbody2D.velocity;

            // modify y-component of velocity vector
            newVelocity.y += deviationFactor * deviationScale;

            // normalize resulting vector
            newVelocity.Normalize();

            // "restore" initial velocity
            newVelocity *= rigidbody2D.velocity.magnitude;

            // set new velocity
            rigidbody2D.velocity = newVelocity;
        }
    }
}
