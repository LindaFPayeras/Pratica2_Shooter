using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Enemy : MonoBehaviour
{
    public Health health;
    protected NavMeshAgent agent;
    protected Transform player;

    // Para el ataque
    [SerializeField] protected float detectionRange = 20f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;
    private float lastAttackTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateBehaviour();
    }

    protected virtual void UpdateBehaviour()
    {
        // Si estás o no dentro del rango de deteccion
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
            
        }
        else
        {
            agent.ResetPath(); // Quieto si no detecta
        }
    }

    public void OnDeath()
    {
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }

    protected virtual void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Health playerHealth = other.GetComponent<Health>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    Debug.Log("Daño al jugador");
                }

                lastAttackTime = Time.time;
            }
        }        
    }
    
}
