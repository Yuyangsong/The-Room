using UnityEngine;

public class BottleMotion : MonoBehaviour
{
    public Vector3 velocity;
    public Transform attractor;
    public float gravity = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attractor != null)
        {
            Vector3 relativePosition =
                transform.position - attractor.position;

            float distance = relativePosition.magnitude;

            if (distance > 0.05f)
            {
                Vector3 acceleration =
                    -gravity * relativePosition /
                    Mathf.Pow(distance, 3);

                velocity += acceleration * Time.deltaTime;
            }
        }

        transform.position += velocity * Time.deltaTime;
    }
}
