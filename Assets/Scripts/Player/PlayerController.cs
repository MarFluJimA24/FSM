using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Referencias")]
    public Rigidbody rb;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 movement;
    private bool isGrounded;

    void Start()
    {
        // Si no tenemos Rigidbody, lo añadimos automáticamente
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        // Si no tenemos groundCheck, lo creamos
        if (groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform);
            groundCheckObj.transform.localPosition = new Vector3(0, -1f, 0);
            groundCheck = groundCheckObj.transform;
        }
    }

    void Update()
    {
        // Verificar si está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // MOVIMIENTO WASD
        float x = Input.GetAxis("Horizontal"); // A / D
        float z = Input.GetAxis("Vertical");   // W / S

        movement = transform.right * x + transform.forward * z;

        // SALTO
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento en FixedUpdate (mejor para físicas)
        if (movement.magnitude >= 0.1f)
        {
            Vector3 moveVelocity = movement.normalized * moveSpeed;
            rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
        }
    }

    // Dibujar gizmos en el editor para ver el groundCheck
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}