using Unity.VisualScripting;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    // CAMBIO PARA GIT
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float lifeTime = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
