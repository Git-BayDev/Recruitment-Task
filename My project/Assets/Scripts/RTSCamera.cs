using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    
    void Update()
    {
        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 right = new Vector3(transform.right.x,0, transform.right.z).normalized;

        // Ruch kamery
        if (Input.GetKey("w"))
            transform.position += forward * movementSpeed * Time.deltaTime;
        if (Input.GetKey("s"))
            transform.position -= forward * movementSpeed * Time.deltaTime;
        if (Input.GetKey("a"))
            transform.position -= right * movementSpeed * Time.deltaTime;
        if (Input.GetKey("d"))
            transform.position += right * movementSpeed * Time.deltaTime;

        // Obrot kamery
        if (Input.GetKey("q"))
            transform.Rotate(Vector3.up, - rotationSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey("e"))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Ograniczenie ruchu kamery
        
        Vector3 blockPosition = transform.position;

        blockPosition.x = Mathf.Clamp(blockPosition.x, minX, maxX);
        blockPosition.z = Mathf.Clamp(blockPosition.z, minZ, maxZ);

        transform.position = blockPosition;

    }
}
