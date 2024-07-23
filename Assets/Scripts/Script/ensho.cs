using UnityEngine;

public class ensho : MonoBehaviour
{
    public Rigidbody projectilePrefab; // Prefab of the projectile to shoot
    public float shootingForce = 10f; // Force applied to the projectile when shooting
    public float projectileSpeed = 5f; // Speed of the projectile after being shot
    public float detectionRadius = 60f; // Radius within which the GameObject detects the player
    public float shootCooldown = 2f; // Cooldown time between shots

    public Rigidbody player; // Reference to the player's Rigidbody component

    private float lastShootTime; // Time when the last shot was fired

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time - lastShootTime >= shootCooldown)
        {
            // Check if the player is within the detection radius
            if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRadius)
            {
                // Calculate the direction towards the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Calculate the velocity required to hit the player
                Vector3 velocity = CalculateProjectileVelocity(transform.position, player.position, projectileSpeed);

                // Instantiate the projectile at the current GameObject's position
                Rigidbody projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                // Apply force to the projectile in the calculated direction
                projectile.AddForce(velocity * shootingForce, ForceMode.Impulse);

                // Destroy the projectile after 4 seconds
                Destroy(projectile.gameObject, 4f);

                // Update the last shoot time
                lastShootTime = Time.time;
            }
        }
    }

    // Calculate the velocity required to hit a target with a given speed
    Vector3 CalculateProjectileVelocity(Vector3 origin, Vector3 target, float speed)
    {
        // Calculate the direction to the target
        Vector3 direction = target - origin;

        // Calculate the time it takes for the projectile to reach the target
        float time = direction.magnitude / speed;

        // Calculate the velocity required to hit the target
        Vector3 velocity = direction / time;

        return velocity;
    }

    // Draw a visual representation of the detection radius in the Scene view for easier visualization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}