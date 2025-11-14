using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour

{

    public Animator anim;

    //public CharacterController character;
    public Rigidbody rigid;
    BaseState currentState;
    public IdleState idle;
    public RunState run;
    public JumpState jump;
    public FallState fall;
    public DashState dash;
    public ShootState shoot;
    public DeadStatePlayer dead;

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
    public bool inDash = false;

    [Space]
    [Header("Disparo")]
    ShootPlayer shootPlayer;

    [Space]
    [Header("Muerte")]

    LifeController life;

    [Space]
    [Header("Tackle")]
    public bool isTackled;
    public Vector3 tackleDirection;
    public float tackleForce;
    public float tackleTimer;


    private Vector3 lastPosition;
    //public float VelocityY { get => _velocityY; set => _velocityY = value; }
    //public float _velocityY;
    Vector3 mov;

    [SerializeField] AnimationInvoker animInvoker;

    private void Awake()
    {
        //character = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        life = GetComponent<LifeController>();
        shootPlayer = GetComponent<ShootPlayer>();

    }

    void Start()
    {
        idle = new IdleState(this);
        run = new RunState(this);
        jump = new JumpState(this);
        fall = new FallState(this);
        dash = new DashState(this);
        shoot = new ShootState(this);
        dead = new DeadStatePlayer(this);
        ChangeState(idle);
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckBox(centerPoint.position, sizeDetection, Quaternion.identity, layerGround);


        movHori = Input.GetAxis("Horizontal");
        movVert = Input.GetAxis("Vertical");

        // condicion de dash


        if (isTackled)
        {
            rigid.linearVelocity = tackleDirection * tackleForce * Time.deltaTime;
            tackleTimer -= Time.deltaTime;

            if (tackleTimer <= 0)
            {
                isTackled = false;
            }
        }

        currentState?.UpdateState();


        mov = new Vector3(movHori, 0, movVert);

        float camDirection = cam.eulerAngles.y;
        Vector3 movByCam = Quaternion.Euler(0f, camDirection, 0f) * mov;

        if (mov != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movByCam);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sdRotate * Time.deltaTime);
        }

        if (life.currentHealth <= 0)
        {
            ChangeState(dead);
            this.enabled = false;
            GetComponent<ShootPlayer>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }
    public void Movement()
    {
        Vector3 direction = transform.forward * mov.magnitude * speed;
        direction.y = rigid.linearVelocity.y;
        rigid.linearVelocity = direction;
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


        float timer = 0;
        rigid.linearVelocity = transform.forward * speedDash ;
        while (timer < timeDash)
        {
            inDash = true;
            timer += Time.deltaTime;
            yield return null;
        }
        inDash = false;
        rigid.linearVelocity = Vector3.zero;
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
    public void Tackle(Transform pusher, float force, float duration = 0.5f)
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

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lava")
        {
            SceneManager.LoadScene("DisenoTutorial");
        }
    }
}
