using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {


    // Projectile prefab with a RigidBody component
    public GameObject Projectile;

    void Awake()
    {
        gameObject.tag = "projectilePrefab";
    }

    void OnSelect()
    {
        Vector3 projectilePosition = Camera.main.transform.position + Camera.main.transform.forward * 0.8f;
        Vector3 projectileDirection = Camera.main.transform.forward;
        ShootProjectile(projectilePosition, projectileDirection);
    }

    // need to clean up projectile, should dissapear after a set time
    void ShootProjectile(Vector3 start, Vector3 direction)
    {
        GameObject spawnedProjectile = (GameObject)Instantiate(Projectile);
        Destroy(spawnedProjectile.gameObject, 3);
        // set the projectile's starting location to be just in front of user
        spawnedProjectile.transform.position = start;
        // get the RigidBody to apply force to projectile
        Rigidbody rigidBody = spawnedProjectile.GetComponent<Rigidbody>();

        // give projectile a velocity           
        rigidBody.velocity = 50 * direction;

        // make the projectile spin
        rigidBody.angularVelocity = Random.onUnitSphere * 20;
    }
}
