using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de nivel

public class BallController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Para moverse a los lados con las flechas
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(movX * velocidad, rb.linearVelocity.y, movZ * velocidad);

        // Para saltar con la barra espaciadora o tocando la pantalla
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, rb.linearVelocity.z);
        }
    }

    // Cuando la bolita choca con la caja invisible de la META
    private void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject.CompareTag("Meta"))
        {
            // Pasa al siguiente nivel
            int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
            
            // Revisa si hay más niveles, si no, regresa al menú
            if (siguienteNivel < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(siguienteNivel);
            }
            else
            {
                SceneManager.LoadScene(0); 
            }
        }
    }

    // Cuando la bolita choca con las púas de abajo
    private void OnCollisionEnter(Collision choque)
    {
        if (choque.gameObject.CompareTag("Obstaculo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
        }
    }
}