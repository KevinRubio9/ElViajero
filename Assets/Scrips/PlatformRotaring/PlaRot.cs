using UnityEngine;

public class PlaRot : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis = Vector3.forward;
    public float Speed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * Speed * Time.deltaTime, Space.Self);
    }
}
