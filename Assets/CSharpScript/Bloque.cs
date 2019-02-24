using UnityEngine;
using System.Collections;
using System;

///<Author>Jose J. Pardines Garcia</Author>
///<Author>Jose Manuel Esparcia Cañizares</Author>

///<summary>
///Clase Bloque del juego
///</summary>
public class Bloque : MonoBehaviour
{
    /// <summary>
    /// Declaracion de variables
    /// </summary>
    Nivel nivel;

    /// <summary>
    /// Funcion para llamar a cuentabloques y contar todos los bloques de pantalla
    /// </summary>
    private void Start()
    {
        CuentaBloques();
    }

    /// <summary>
    /// Funcion para se encarga de comprobar que sea un bloque con la equiqueta Rompible
    /// y de ser así, llama a ContarBLoques de nivel para hacer el sumatorio
    /// </summary>
    public void CuentaBloques()
    {
        this.nivel = FindObjectOfType<Nivel>();
        if (tag == "Rompible")
        {
            this.nivel.ContarBloques();
        }
    }

    /// <summary>
    /// Funcion que se llama cuando un bloque tenga colision se compruebe que sea del tipo Rompible
    /// para así destruirlo
    /// </summary>
    /// <param name="col"></param>
    public void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (tag == "Rompible")
        {
            ///Destruimos el bloque
            Destroy(gameObject);

            ///Llamamos a esta funcion para que haga la resta de los destruidos
            this.nivel.BloquesDestruidos();

            ///Sumamos puntuación por bloque destruido
            FindObjectOfType<SesionJuego>().SumarPuntuacion();
        }
    }

}