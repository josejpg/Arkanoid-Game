using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Author>Jose J. Pardines Garcia</Author>
///<Author>Jose Manuel Esparcia Cañizares</Author>

///<summary>
///Clase ManejadorEscenarios del juego
///</summary>
public class Bola : MonoBehaviour
{
    /// <summary>
    /// Declaracion de variables
    /// </summary>

    /// variable para la velocidad de la bola
    private float velocidad = 225.0f;

    [SerializeField]
    private AudioClip[] SonidosBolaEnBarra;

    [SerializeField]
    private AudioClip[] SonidosBolaEnBloques;

    ///variable para indicar que debe empezar a moverse la bola
    private bool comienzaMovimiento = false;

    /// Variable para vincular el componente con el origen del audio
    private AudioSource audioSource;

    /// <summary>
    /// Funcion para asignar el audiosource
    /// </summary>
    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Funcion para comprobar por cada frame que el movimiento de la bola haya comenzado
    /// </summary>
    private void Update()
    {
        if (!this.comienzaMovimiento)
        {
            this.PulsarClickRaton();
        }
    }

    /// <summary>
    /// Funcion para comprobar si se ha pulsado el boton del raton y en caso de que si, la bola comienza a moverse
    /// </summary>
    public void PulsarClickRaton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.comienzaMovimiento = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
        }
    }

    /// <summary>
    /// Funcion que se llama cuando la bola colisione, en este caso cuando colisione con la barra haremos
    /// que tome una cierta direccion lógica
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision2d)
    {
        // This function is called whenever the ball
        // collides with something
        if (collision2d.gameObject.name == "racket")
        {
            ///Asignamos los sonidos de la barra al golpear con la bola y hacemos que suenen de manera aleatoria
            AudioClip audioClip = SonidosBolaEnBarra[UnityEngine.Random.Range(0, SonidosBolaEnBarra.Length)];
            this.audioSource.PlayOneShot(audioClip);

            ///Calculamos el factor de impacto
            float x = FactorImpacto(transform.position, collision2d.transform.position, collision2d.collider.bounds.size.x);

            ///Calculamos la direccion que tomara
            Vector2 vector2Direccion = new Vector2(x, 1).normalized;

            ///Modificamos la velocidad que tomará
            GetComponent<Rigidbody2D>().velocity = vector2Direccion * velocidad;
        }
        else
        {
            ///Si no golpea con la barra que realice siempre el sonido de los golpes en bloques
            AudioClip audioClip = SonidosBolaEnBloques[UnityEngine.Random.Range(0, SonidosBolaEnBloques.Length)];
            audioSource.PlayOneShot(audioClip);
        }
    }

    /// <summary>
    /// funcion que devuelve un float con el calculo del factor de impacto
    /// </summary>
    public float FactorImpacto(Vector2 PosicionBola, Vector2 PosicionBarra, float AnchoBarra)
    {
        return (PosicionBola.x - PosicionBarra.x) / AnchoBarra;
    }

}
