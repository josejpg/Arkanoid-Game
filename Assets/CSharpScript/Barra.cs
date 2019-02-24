using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Author>Jose J. Pardines Garcia</Author>
///<Author>Jose Manuel Esparcia Cañizares</Author>

///<summary>
///Clase de la barra del juego
///</summary>
public class Barra : MonoBehaviour
{
    /// <summary>
    /// Declaracion de variables
    /// </summary>
    private float minX = -70f;
    private float maxX = 69f;

    ///<summary>
    ///Funcion para controlar que la barra este dentro de los margenes segun la posicion del raton o dedo si es pantalla tactil
    ///</summary>
    private void Update()
    {
        Vector2 v2Pos = Input.mousePosition;
        v2Pos = Camera.main.ScreenToWorldPoint(v2Pos);
        v2Pos.y = transform.position.y;

        if (v2Pos.x > maxX)
        {
            v2Pos.x = maxX;
        }
        else if (v2Pos.x < minX)
        {
            v2Pos.x = minX;

        }
        transform.position = v2Pos;
    }
}