using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    private Light light;
    public InputActionReference action;
    private int colorIndex = -1;
    public Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += (ctx) => ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        light.color = colors[colorIndex];
    }
}
