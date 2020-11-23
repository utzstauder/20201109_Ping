using UnityEngine;

public class RacketController : MonoBehaviour
{
    float verticalInput;
    public float movementSpeed = 5f;

    public string axisName;
    public bool aiControlled;
    public Transform aiMovementTarget; // default = null

    private Rigidbody2D rigidbody2D; // default = null

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (aiControlled)
        {
            if (aiMovementTarget != null)
            {
                // ball.y > this.y
                if (aiMovementTarget.position.y > transform.position.y)
                {
                    // move up
                    verticalInput = 1f;
                } else
                {
                    // move down
                    verticalInput = -1f;
                }
            } else
            {
                //GameObject targetObject = GameObject.Find("Ball");

                BallController ball = GameObject.FindObjectOfType<BallController>();

                if (ball != null)
                {
                    aiMovementTarget = ball.transform;
                } else
                {
                    Debug.LogError("AiMovementTarget has not been assigned!");
                }
            }

        } else
        {
            verticalInput = Input.GetAxisRaw(axisName);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.up * verticalInput * movementSpeed;
    }
}
