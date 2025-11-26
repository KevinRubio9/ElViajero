using UnityEngine;

public class RotatingTeleportLvlBoss : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
    }
}
