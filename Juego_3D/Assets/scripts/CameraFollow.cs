using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo; // Aquí arrastraremos la pelota
    public Vector3 offset;
    private float posicionZFija;

    void Start()
    {
        // Guarda la posición Z inicial para que nunca cambie (criterio de la rúbrica)
        posicionZFija = transform.position.z;
        
        if(objetivo != null)
        {
            offset = transform.position - objetivo.position;
        }
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Sigue al objetivo en X e Y, pero clava el valor de Z
            Vector3 nuevaPosicion = objetivo.position + offset;
            nuevaPosicion.z = posicionZFija;
            
            transform.position = nuevaPosicion;
        }
    }
}