using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour

{
    // movimiento 
    CharacterController character;
    private float movHori;
    private float movVert;
    public float speed;
    [SerializeField] float speedDash;
    private float gravity = -9.81f;
    private Vector3 velocity;
    [SerializeField] float forceJump;

    //deteccion del piso
    private bool isGrounded;
    [SerializeField] Transform centerPoint;
    [SerializeField] Vector3 sizeDetection;
    [SerializeField] LayerMask layerGround;

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
        // deteccion de suelo
        isGrounded = Physics.CheckBox(centerPoint.position,sizeDetection, Quaternion.identity ,layerGround);
        
        // condicion de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(forceJump*-2*gravity);
        }

        // movimiento eje X y Z
        movHori = Input.GetAxis("Horizontal");
        movVert = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(movHori, 0, movVert);

        character.Move(mov * speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity*Time.deltaTime);
        
        if (Input.GetButtonDown("Fire3"))
        {
            character.Move(mov*speedDash*Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(centerPoint.position, sizeDetection);
    }
}
