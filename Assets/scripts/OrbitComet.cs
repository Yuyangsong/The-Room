using UnityEngine;

public class OrbitComet : MonoBehaviour
{
    public Transform planet;
    public float gravity = 0.2f;
    public Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePosition = transform.position - planet.position;
        float distance = relativePosition.magnitude;
        Vector3 acceleration = -gravity * relativePosition / Mathf.Pow(distance, 3);
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
