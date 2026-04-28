using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 2f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        // Rayo desde el centro de la pantalla (donde apunta el jugador)
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 direction = ray.direction;

        // Disparo desde el arma, pero con dirección de la cámara
        if (Physics.Raycast(firePoint.position, direction, out hit, range))
        {
            Debug.Log("He dado a: " + hit.collider.name);

            // Si tiene vida
            Health target = hit.transform.GetComponentInParent<Health>();
            if (target != null)
                target.TakeDamage(50);
        }

        // Debug visual
        Debug.DrawRay(firePoint.position, direction * range, Color.red, 1f);
    }
}