using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float panSpeed = 100f; // Vitesse de pano
    public float tiltSpeed = 100f; // Vitesse de tilt
    public float maxTiltAngle = 45f; // Angle de tilt maximal
    public GameObject projectilePrefab; // Préfabriqué du projectile
    public Transform firePoint; // Point de départ du projectile
    public float fireRate = 0.5f; // Taux de tir en secondes

    private float nextFireTime;

    void Update()
    {
        // Pano de la tourelle en fonction de la souris
        float pan = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, pan);

        // Tilt de la tourelle en fonction de la souris
        float tilt = -Input.GetAxis("Mouse Y") * tiltSpeed * Time.deltaTime;
        float currentTiltAngle = transform.localRotation.eulerAngles.x;
        float newTiltAngle = Mathf.Clamp(currentTiltAngle + tilt, 0f, maxTiltAngle);
        transform.localRotation = Quaternion.Euler(newTiltAngle, 0f, 0f);

        // Tir du projectile avec le clic gauche de la souris
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        // Ajoutez ici la logique pour tirer le projectile
    }
}
