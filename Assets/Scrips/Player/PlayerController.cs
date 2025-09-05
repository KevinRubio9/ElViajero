using System.Collections;
using System.Net.Sockets;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour

{
    CharacterController character;

    [Header("Envenenamiento")]
    public float timePoisoned;
    public bool poisoned = false;


    [Header("Movimiento")]

    public float speed;
    public float speedCorrupted;
    public float sdRotate;
    [SerializeField] float forceJump;
    [SerializeField] float forceJumpCorrupted;
    public Transform cam; //Enlazar la freelookcamera desde el prefab de camara
    private float movHori;
    private float movVert;
    private float gravity = -9.81f;
    private Vector3 velocity;


    [Space]
    [Header("Detecion de suelo")]

    [SerializeField] Transform centerPoint;
    [SerializeField] Vector3 sizeDetection;
    [SerializeField] LayerMask layerGround;
    private bool isGrounded;

    [Space]
    [Header("Dash")]

    [SerializeField] float speedDash;
    [SerializeField] float speedDashCorrupted;
    [SerializeField] float cooldownDash;
    [SerializeField] float timeDash;
    private Vector3 movDash;
    private bool canDash = true;


    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckBox(centerPoint.position, sizeDetection, Quaternion.identity, layerGround);


        // condicion de salto
        if (Input.GetButtonDown("Jump") && isGrounded && !poisoned)
        {
            velocity.y = Mathf.Sqrt(forceJump * -2 * gravity);
        }
        else if (Input.GetButtonDown("Jump") && isGrounded && poisoned)
        {
            velocity.y = Mathf.Sqrt(forceJumpCorrupted * -2 * gravity);
        }
        // movimiento eje X y Z
        movHori = Input.GetAxis("Horizontal");
        movVert = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(movHori, 0, movVert);

        float camDirection = cam.eulerAngles.y;
        Vector3 movByCam = Quaternion.Euler(0f, camDirection, 0f) * mov;
        if (!poisoned)
        {
            character.Move(movByCam * speed * Time.deltaTime);

        }
        else { character.Move(movByCam * speedCorrupted * Time.deltaTime); }
        if (mov != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movByCam);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sdRotate * Time.deltaTime);

        }
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);

        // condicion de dash
        if (Input.GetButtonDown("Fire3") && canDash)
        {

            StartCoroutine(dash());
        }

    }

    IEnumerator dash()
    {
        canDash = false;
        float horiDash = Input.GetAxisRaw("Horizontal");
        float vertDash = Input.GetAxisRaw("Vertical");
        movDash = new Vector3(horiDash, 0, vertDash);

        if (movDash == Vector3.zero)
        {
            movDash = transform.forward;
        }

        float timer = 0;
        while (timer < timeDash)
        {
            character.Move(movDash * speedDash * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(cooldownDash);
        canDash = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
           StartCoroutine(Poisoned());
        }
 
    }

    IEnumerator Poisoned ()
    {
        poisoned = true;

        yield return new WaitForSeconds(timePoisoned);
        poisoned = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(centerPoint.position, sizeDetection);
    }
}
