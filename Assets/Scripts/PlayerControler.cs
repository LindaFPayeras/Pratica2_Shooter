using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerFPS : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float minAngle = -80f;
    [SerializeField] private float maxAngle = 80f;
    [SerializeField] private Vector3 spawnPoint;

    private float xRotation = 0f;

    private Rigidbody rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Mouse();
        Jump();
    }

    void FixedUpdate()
    {
        movimientoASDW();
    }

    
    void movimientoASDW()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;

        Vector3 velocity = move * speed;
        velocity.y = rb.linearVelocity.y;

        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Mouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle); // Para que no de vueltas la cabeza
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal (player)
        transform.Rotate(Vector3.up * mouseX);
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnDeath()
    {
        Debug.Log("Jugador muerto");

        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Respawn()
    {
        transform.position = spawnPoint;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}