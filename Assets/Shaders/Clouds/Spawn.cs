using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public float height; // Base height at which clouds are spawned    
    public float heightVariation; // Range of variation allowed for the cloud spawn height
    public float spawnPoint; // Horizontal distance from the spawner's position within which clouds can be spawned
    public GameObject cloud; // Cloud prefab to be spawned
    public int cloudNumber; // Total number of clouds to spawn.

    void Start()
    {
        // Loop to spawn the specified number of clouds
        for (int i = 0; i < cloudNumber; i++) 
        {
            // Generate a random position for the cloud.
            // X and Z positions are randomized within the spawnPoint range around the spawner's position.
            // Y position is randomized within the height range specified by heightVariation.
            Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - spawnPoint, transform.position.x + spawnPoint), Random.Range(height - heightVariation, height + heightVariation), Random.Range(transform.position.z - spawnPoint, transform.position.z + spawnPoint));

            /* Instantiate a cloud prefab at the calculated position with no rotation (Quaternion.identity),
            and set its parent to this spawner object for better organization in the hierarchy */

            Instantiate(cloud, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}
