using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject crystalPrefab;
    public GameObject feedbackPrefab;

    public float crystalLifetime = 10f;
    public float feedbackLifetime = 4f;

    private GameObject currentCrystal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCrystal()
    {
        if (currentCrystal != null)
        {
            Destroy(currentCrystal);
        }

        Vector3 position = spawnPoint.position;
        Quaternion rotation = spawnPoint.rotation;

        currentCrystal = Instantiate(
            crystalPrefab, position, rotation);

        GameObject feedback = Instantiate(
            feedbackPrefab, position, rotation);

        feedback.GetComponentInChildren<ParticleSystem>().Play();
        feedback.GetComponentInChildren<AudioSource>().Play();

        Destroy(currentCrystal, crystalLifetime);
        Destroy(feedback, feedbackLifetime);
    }
}
