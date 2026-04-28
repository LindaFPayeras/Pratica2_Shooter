public class EnemyFast : Enemy
{
     protected override void Start()
    {
        base.Start();

        detectionRange = 10f;   // Menos rango
        agent.speed = 6f;       // Más rápido
    }
}