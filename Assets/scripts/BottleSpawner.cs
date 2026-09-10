using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleSpawner : MonoBehaviour
{
    public InputActionReference action;
    public Transform spawnPoint;
    public BottleMotion bottlePrefab;
    public GameObject feedbackPrefab;

    public float launchSpeed = 2f;
    public float bottleLifetime = 5f;
    public float feedbackLifetime = 4f;

    public bool perfectOrbit = false;
    public Transform planet;
    public float gravity = 20f;
    public float orbitLifetime = 120f;

    public TMP_Text modeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) => ThrowBottle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleOrbitMode()
    {
        perfectOrbit = !perfectOrbit;
        UpdateModeText();
    }

    void UpdateModeText()
    {
        modeText.text = perfectOrbit
            ? "ORBIT MODE"
            : "THROW MODE";
    }

    void ThrowBottle()
    {
        Vector3 position = spawnPoint.position;
        Quaternion rotation = spawnPoint.rotation;

        // A circular orbit needs a nonzero radius.
        if (perfectOrbit &&
            Vector3.Distance(position, planet.position) < 0.1f)
        {
            return;
        }

        BottleMotion bottle = Instantiate(
            bottlePrefab, position, rotation);

        if (perfectOrbit)
        {
            Vector3 relativePosition =
                position - planet.position;

            float distance = relativePosition.magnitude;
            Vector3 radialDirection = relativePosition.normalized;

            Vector3 tangentDirection = Vector3.ProjectOnPlane(
                spawnPoint.forward, radialDirection);

            // Choose a tangent if the controller points at the center.
            if (tangentDirection.sqrMagnitude < 0.0001f)
            {
                tangentDirection = Vector3.Cross(
                    radialDirection, Vector3.up);

                if (tangentDirection.sqrMagnitude < 0.0001f)
                {
                    tangentDirection = Vector3.Cross(
                        radialDirection, Vector3.right);
                }
            }

            bottle.attractor = planet;
            bottle.gravity = gravity;

            bottle.velocity = tangentDirection.normalized *
                Mathf.Sqrt(gravity / distance);

            Destroy(bottle.gameObject, orbitLifetime);
        }
        else
        {
            bottle.attractor = null;
            bottle.velocity = spawnPoint.forward * launchSpeed;

            Destroy(bottle.gameObject, bottleLifetime);
        }

        GameObject feedback = Instantiate(
            feedbackPrefab, position, rotation);

        feedback.GetComponentInChildren<ParticleSystem>().Play();
        feedback.GetComponentInChildren<AudioSource>().Play();

        Destroy(feedback, feedbackLifetime);
    }
}
