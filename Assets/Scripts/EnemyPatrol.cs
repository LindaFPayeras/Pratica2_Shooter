using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : Enemy
{
    [SerializeField] private Transform[] patrolPoints;
    private int currentPoint = 0;

    protected override void UpdateBehaviour()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            // Perseguir jugador
            agent.SetDestination(player.position);
        }
        else
        {
            // Patrullar
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPoint].position);

        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}