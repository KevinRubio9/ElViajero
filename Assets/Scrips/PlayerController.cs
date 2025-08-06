using UnityEngine;

public class PlayerController : MonoBehaviour

{
    CharacterController character;
    private float movHori;
    private float movVert;
    public float speed;
    private float gravity = -9.81f;

    private void Awake()
    {
        
    }
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento eje X y Z
        movHori = Input.GetAxis("Horizontal");
        movVert = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(movHori, 0, movVert);

       character.Move(mov * speed*Time.deltaTime);


    }
}
