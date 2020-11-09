using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private Vector3 initialPosition;

    public float initialSpeed = 5f;

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
}
