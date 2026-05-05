using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Busca al GameManager en la escena para poder enviarle la orden de sumar puntos
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que atraviesa esta zona se llama "Ball"
        if (other.gameObject.name == "Ball")
        {
            gameManager.SumarPuntos(10); // Sumamos 10 puntos
            Destroy(gameObject); // Destruimos esta zona para no sumar puntos infinitos
        }
    }
}