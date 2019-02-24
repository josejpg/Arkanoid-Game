using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<Author>Jose J. Pardines Garcia</Author>
///<Author>Jose Manuel Esparcia Cañizares</Author>

///<summary>
///Clase ManejadorEscenarios del juego
///</summary>
public class ManejadorEscenarios : MonoBehaviour
{
    /// <summary>
    /// Obligamos a que la aplicación se ejecute en modo LandscapeLeft
    /// </summary>
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    /// <summary>
    /// Funcion para cargar la escena siguiente a partir de la actual
    /// </summary>
	public void CargarSiguienteEscenario()
    {
        ///Obtenemos el numero del próximo escenario e 
        ///incrementamos en 1 la escena actual para obtener el identificador (numero) de la siguiente escena
        int proximoEscenario = SceneManager.GetActiveScene().buildIndex + 1;

        ///Cargamos la nueva escena
        SceneManager.LoadScene(proximoEscenario);
    }

    /// <summary>
    /// Funcion para cargar la primera escena 
    /// </summary>
    public void CargarPrimerEscenario()
    {
        ///Asignamos el numero de la primera escena
        int PrimeraEscena = 1;

        ///Cargamos la primera escena
        SceneManager.LoadScene(PrimeraEscena);

        ///Reiniciamos la puntuacion para que empiece en 0
        FindObjectOfType<SesionJuego>().ReiniciarPuntuacion();
    }

    /// <summary>
    /// funcion para finalizar el juego
    /// </summary>
    public void SalirJuego()
    {
        Application.Quit();
    }
}
