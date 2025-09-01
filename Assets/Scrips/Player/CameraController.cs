using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float velocity = 10f;
    public float rotateX = 0f;

    public Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX= Input.GetAxis("Mouse X") * velocity * Time.deltaTime;
        float mouseY= Input.GetAxis("Mouse Y") * velocity * Time.deltaTime;

        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    
    }
}
