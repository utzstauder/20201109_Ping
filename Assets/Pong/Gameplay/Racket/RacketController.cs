using UnityEngine;

public class RacketController : MonoBehaviour
{
    float verticalInput;
    public float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        // 1. read input
        verticalInput = Input.GetAxisRaw("Vertical");

        // 2. update object state
        transform.position += Vector3.up * verticalInput * movementSpeed * Time.deltaTime;

        // (3. communicate updated state)
    }
}
