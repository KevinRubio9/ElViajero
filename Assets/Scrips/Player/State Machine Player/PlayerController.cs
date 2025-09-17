using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour

{

    public CharacterController character;
    BaseState currentState;
    public IdleState idle;
    public RunState run;
    public JumpState jump;
    public DashState dash;
    public ShootState shoot;

    [Header("Envenenamiento")]
    public float timePoisoned;
    public bool poisoned = false;


    [Header("Movimiento")]

    public float speed;
    public float speedCorrupted;
    public float sdRotate;
    public float forceJump;
    public float forceJumpCorrupted;
    public Transform cam; //Enlazar la freelookcamera desde el prefab de camara
    public float movHori;
    public float movVert;
    public float gravity = -9.81f;
    public Vector3 velocity;


    [Space]
    [Header("Detecion de suelo")]

    public Transform centerPoint;
    public Vector3 sizeDetection;
    public LayerMask layerGround;
    public bool isGrounded;

    [Space]
    [Header("Dash")]

    public float speedDash;
    public float speedDashCorrupted;
    public float cooldownDash;
    public float timeDash;
    public Vector3 movDash;
    public bool canDash = true;

    [Space]
    [Header("Tackle")]
    public bool isTackled;
    public Vector3 tackleDirection;
    public float tackleForce;
    public float tackleTimer;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        idle = new IdleState (this);
        run = new RunState (this);
        jump = new JumpState (this);
        dash = new DashState (this);
        shoot = new ShootState (this);
        ChangeState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckBox(centerPoint.position, sizeDetection, Quaternion.identity, layerGround);

        // condicion de salto
        if (Input.GetButtonDown("Jump"))
        {
            ChangeState(jump);
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
            ChangeState(dash);
        }

        if (isTackled)
        {
            character.Move(tackleDirection * tackleForce * Time.deltaTime);
            tackleTimer -= Time.deltaTime;

            if (tackleTimer <= 0)
            {
                isTackled = false;
            }
        }
    }

    public void ChangeState(BaseState newState)
    {
        currentState = newState;
        currentState.EnterState();
    }

    public void StartDash()
    {
        StartCoroutine(Dash());

    }

    public IEnumerator Dash()
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
    IEnumerator Poisoned()
    {
        poisoned = true;

        yield return new WaitForSeconds(timePoisoned);
        poisoned = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            StartCoroutine(Poisoned());
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(centerPoint.position, sizeDetection);
    }
    public void Tackle(Transform pusher, float force, float duration = 1f)
    {
        tackleDirection = (transform.position - pusher.position).normalized;
        tackleForce = force;
        tackleTimer = duration;
        isTackled = true;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        FallingPlatform platform = hit.collider.GetComponent<FallingPlatform>();
        if (platform != null)
        {
            platform.ActivateFalling();
        }
    }
}
