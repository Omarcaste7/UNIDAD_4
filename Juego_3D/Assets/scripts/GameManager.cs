using UnityEngine;
using TMPro; // Librería obligatoria para controlar la UI de texto

public class GameManager : MonoBehaviour
{
    public int scoreActual = 0;
    public int highScore = 0;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Referencia al script de tu bola para aumentar su velocidad (curva de dificultad)
    public BallController ballController; 

    void Start()
    {
        // Recuperamos el récord guardado. Si no existe, por defecto es 0.
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        ActualizarTextos();
    }

    public void SumarPuntos(int puntos)
    {
        scoreActual += puntos;

        // Comprobamos si rompimos el récord
        if (scoreActual > highScore)
        {
            highScore = scoreActual;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Guardamos los datos permanentemente
        }

        ActualizarTextos();
        AumentarDificultad();
    }

    void ActualizarTextos()
    {
        scoreText.text = "Score: " + scoreActual;
        highScoreText.text = "High Score: " + highScore;
    }

    void AumentarDificultad()
    {
        // Curva de dificultad: Cada vez que sumamos puntos, la velocidad de movimiento de la bola aumenta ligeramente
        if (ballController != null)
        {
            ballController.velocidadMovimiento += 0.2f; 
        }
    }
}