// using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
// public class PlayerController : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5.0f;
//     [SerializeField] private float mouseSensitivity = 2.0f;
//     [SerializeField] private float minLookAngle = -80.0f; // si no da vueltas raras
//     [SerializeField] private float maxLookAngle = 80.0f; 
//     [SerializeField] private Camera playerCamera;

//     private Rigidbody rb;
//     private float cameraPitch; // variacion para la camara 

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.freezeRotation = true;

//         if (playerCamera == null)
//         {
//             playerCamera = GetComponentInChildren<Camera>(); // por si no está incluido; control de erroes
//         }
//     }

//     private void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//     }

//     private void Update()
//     {
//         float mouseX = Input.GetAxis("Mouse X");
//         float mouseY = Input.GetAxis("Mouse Y");

//         transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

//         cameraPitch -= mouseY * mouseSensitivity;
//         cameraPitch = Mathf.Clamp(cameraPitch, minLookAngle, maxLookAngle);
//         playerCamera.transform.localRotation = Quaternion.Euler(cameraPitch, 0.0f, 0.0f);
//     }

//     private void FixedUpdate()
//     {
//         float h = Input.GetAxisRaw("Horizontal");
//         float v = Input.GetAxisRaw("Vertical");

//         Vector3 moveDir = transform.right * h + transform.forward * v;
//         Vector3 velocity = moveDir.normalized * moveSpeed;
//         velocity.y = rb.linearVelocity.y;

//         rb.linearVelocity = velocity;
//     }
// }
