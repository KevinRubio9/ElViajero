using System.Collections;
using System.Net.Sockets;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    // movimiento 
    CharacterController character;
    private float movHori;
    private float movVert;
    public float speed;
    public float sdRotate;
    private float gravity = -9.81f;
    private Vector3 velocity;
    [SerializeField] float forceJump;
    public Transform cam; //Enlazar la freelookcamera desde el prefab de camara

    //deteccion del piso
    private bool isGrounded;
    [SerializeField] Transform centerPoint;
    [SerializeField] Vector3 sizeDetection;
    [SerializeField] LayerMask layerGround;

    //dash
    private Vector3 movDash;
    private bool canDash = true;
    [SerializeField] float speedDash;
    [SerializeField] float cooldownDash;
    [SerializeField] float timeDash;


    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
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

        float camDirection = cam.eulerAngles.y;
        Vector3 movByCam = Quaternion.Euler(0f,camDirection,0f)*mov;

        character.Move(movByCam * speed*Time.deltaTime);
        if (mov != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movByCam);                      
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sdRotate * Time.deltaTime);

        }
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity*Time.deltaTime);
        
        // condicion de dash
        if (Input.GetButtonDown("Fire3") && canDash)
        {
            
            StartCoroutine(dash());
            Debug.Log("se oprimio shift");
        }

    }

    IEnumerator dash()
    {
        Debug.Log("entro a la coruutina");
        canDash = false;
        float horiDash = Input.GetAxisRaw("Horizontal");
        float vertDash = Input.GetAxisRaw("Vertical");
        movDash = new Vector3(horiDash, 0, vertDash);

        if (movDash == Vector3.zero)
        {
            movDash = transform.forward;
        }

        float timer =0;
        while (timer<timeDash)
        {
            character.Move(movDash*speedDash*Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(cooldownDash);
        canDash = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(centerPoint.position, sizeDetection);
    }
}
