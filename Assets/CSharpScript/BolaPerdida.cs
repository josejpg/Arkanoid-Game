using UnityEngine;
using UnityEngine.SceneManagement;

/// <Author>Jose J. Pardines Garcia</Author>
/// <Author>Jose Manuel Esparcia Cañizares</Author>

/// <summary>
///Clase para que cuando perdamos la bola del juego se llame a OnTriggerEnter2D desde Unity 
///y cargue la escena de Game Over que le pasamos
/// </summary>
public class BolaPerdida : MonoBehaviour
{
    /// <summary>
    /// evento que llamara Unity cuando la bola se pierda por abajo en la que hemos agregado el cargar la escena de Game Over
    /// </summary>
    private void OnTriggerEnter2D()
    {
        ///nombre de la escena a cargar
        string escena = "EscenarioGameOver";

        ///llamamos al manejador de escenas para cargar la escena de Game Over
        SceneManager.LoadScene(escena);
    }
}
