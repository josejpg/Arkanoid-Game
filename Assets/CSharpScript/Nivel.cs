using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    /// <summary>
    /// Declaracion de variables
    /// </summary>
    [SerializeField]
    private int bloquesTotales;

    private ManejadorEscenarios manejadorEscenarios;

    // Start is called before the first frame update
    void Start()
    {
        this.manejadorEscenarios = FindObjectOfType<ManejadorEscenarios>();
    }

    /// <summary>
    /// Con esta función contamos el número de bloques que hay en la pantalla
    /// </summary>
    public void ContarBloques()
    {
        ///Aumentamos en 1 el número de bloques
        this.bloquesTotales++;
    }

    /// <summary>
    /// Funcion para restar bloques destruidos y en caso de que no haya ninguno avanzamos a la siguiente escena
    /// </summary>
    public void BloquesDestruidos()
    {
        try
        {
            ///Reducimos en 1 el número de bloques
            this.bloquesTotales--;
            ///Si el número de bloques es menor o igual a cero avanzamos la escena
            if (this.bloquesTotales == 0)
            {
                ///Pasamos a la siguiente escena
                this.manejadorEscenarios.CargarSiguienteEscenario();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
