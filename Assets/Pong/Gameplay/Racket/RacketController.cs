using UnityEngine;

public class RacketController : MonoBehaviour
{
    float verticalInput;
    public float movementSpeed = 5f;

    public string axisName;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. read input
        verticalInput = Input.GetAxisRaw(axisName);

        // 2. update object state
        // transform.position += Vector3.up * verticalInput * movementSpeed * Time.deltaTime;

        // (3. communicate updated state)
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.up * verticalInput * movementSpeed;
    }
}
