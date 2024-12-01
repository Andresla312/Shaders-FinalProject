using UnityEngine;

public class CloudSize : MonoBehaviour
{
    
    public float minSize; // Minimum size the cloud object can have
    public float maxSize; // Maximum size the cloud object can have
    public float yMultiply; // Y-axis multiplier for the cloud's size to achieve a stretched effect
    public float speed; // Clouds movement speed

    void Start()
    {
        // Generate a random size between the minimum and maximum size
        float randomSize = Random.Range(minSize, maxSize);

        /* Create a new Vector3 for the cloud's size, applying the random size to X and Z,
           and scaling the Y-axis by the yMultiply value */
        Vector3 size = new Vector3(randomSize, randomSize * yMultiply, randomSize);

        // Set the cloud's scale to the calculated size
        transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the cloud horizontally to the right based on the speed value
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}