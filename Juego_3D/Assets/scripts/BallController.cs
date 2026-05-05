using UnityEngine;

public class BallController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaRebote = 7f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Desplazamiento en X y Z (con flechas del teclado o WASD)
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        // Mantiene la velocidad actual en Y (para la gravedad/rebote)
        rb.linearVelocity = new Vector3(movX * velocidad, rb.linearVelocity.y, movZ * velocidad);
    }

    // Integración de colisiones
    private void OnCollisionEnter(Collision collision)
    {
        // Al tocar un objeto con Collider (la plataforma), rebota en el eje Y
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaRebote, rb.linearVelocity.z);
    }
}