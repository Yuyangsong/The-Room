using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;
    public Vector3 outsidePosition = new Vector3(0f, 0f, -20f);
    private Vector3 insidePosition;
    private bool isOutside = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        insidePosition = transform.position;
        action.action.Enable();
        action.action.performed += (ctx) => SwitchPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchPosition()
    {
        if (isOutside)
            transform.position = insidePosition;
        else
            transform.position = outsidePosition;

        isOutside = !isOutside;
    }
}
