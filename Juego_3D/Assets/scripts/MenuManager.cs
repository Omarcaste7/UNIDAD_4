using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void IniciarJuego()
    {
        // Carga la escena con el índice 1 (Nivel1)
        SceneManager.LoadScene(1);
    }
}