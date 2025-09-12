using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    public float Speed = 50f;

    void Update()
    {
        transform.Rotate(rotationAxis * Speed * Time.deltaTime, Space.Self);

    }
}
