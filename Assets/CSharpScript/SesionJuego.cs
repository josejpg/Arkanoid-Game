using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<Author>Jose J. Pardines Garcia</Author>
///<Author>Jose Manuel Esparcia Cañizares</Author>

///<summary>
///Clase de la sesion del juego
///</summary>
public class SesionJuego : MonoBehaviour
{

    /// <summary>
    /// Declaracion de variables
    /// </summary>
    [Range(0.1f, 10f)]
    [SerializeField]
    private float velocidadJuego = 1f;

    [SerializeField]
    private int PuntosPorBloqueDestruido = 83;

    [SerializeField]
    private TextMeshProUGUI puntuacionEnTexto;

    [SerializeField]
    private int puntuacionActual = 0;

    /// <summary>
    /// Awaike se usa para inicializar cualquier variable o estado del juego antes de que comience el juego. 
    /// Awake se llama solo una vez durante la vida útil de la instancia de script. 
    /// Se llama a Awake después de que todos los objetos se inicializan para que pueda hablar de forma segura 
    /// con otros objetos o consultarlos utilizando, por ejemplo, GameObject.FindWithTag. 
    /// Cada GameObject's Awake se llama en un orden aleatorio entre objetos. Debido a esto, debe usar Awake 
    /// para configurar referencias entre scripts, y usar Start para pasar cualquier información de un lado a otro. 
    /// Awake siempre se llama antes de cualquier función de inicio. Esto le permite ordenar la inicialización de scripts. 
    /// Awake no puede actuar como una coroutina.
    /// </summary>
    private void Awake()
    {
        ///Usamos al mismo script para mantener la puntuación en cada nivel
        int estadoContadorJuego = FindObjectsOfType<SesionJuego>().Length;

        ///Comprobamos si ya hay un objeto estadoContadorJuego y si es así destruimos el nuevo.
        if (estadoContadorJuego > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            ///Ayudamos a pasar datos de una escena a otra y conserva el mismo gameObject.
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    ///Funcion que asigna la puntuación actual
    /// </summary>
    private void Start()
    {
        this.puntuacionEnTexto.text = this.puntuacionActual.ToString();
    }

    /// <summary>
    /// Funcion para reiniciar el marcador en caso de reiniciar la partida
    /// </summary>
    public void ReiniciarPuntuacion()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Funcion que añade puntuación al marcador
    /// </summary>
    public void SumarPuntuacion()
    {
        ///Sumamos el puntos por bloque destruido (100 puntos) a la puntuacion actual
        this.puntuacionActual += PuntosPorBloqueDestruido;
        this.puntuacionEnTexto.text = puntuacionActual.ToString();
    }
}
