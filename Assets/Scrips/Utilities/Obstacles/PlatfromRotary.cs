using UnityEngine;

public class PlatfromRotary : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Vector3 rotationAxis = Vector3.forward;
    public float Speed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * Speed * Time.deltaTime, Space.Self);
    }
}
