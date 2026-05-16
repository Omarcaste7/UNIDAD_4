using UnityEngine;
using UnityEngine.SceneManagement; // Obligatorio para recargar la escena

public class BallController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaRebote = 7f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(movX * velocidadMovimiento, rb.linearVelocity.y, movZ * velocidadMovimiento);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bucle al perder: Si chocamos contra un obstáculo
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // Si es plataforma normal, rebota
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaRebote, rb.linearVelocity.z);
        }
    }
}