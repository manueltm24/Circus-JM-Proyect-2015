using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Define una dificultad del juego
/// </summary>
public class Dificultad : MonoBehaviour {
    #region "Atributos"

    public string Nombre { get; set; }

    private string sufijo;

    public string Sufijo
    {
        get { return "-" + Nombre.ToLower(); }
    }

    public Vector3 VelocidadMinima { get; set; }

    public Vector3 VelocidadMaxima { get; set; }

    public int VidasIniciales { get; set; }

    public bool ModoAutomatico { get; set; }

    #endregion

    #region "Constructores"

    public Dificultad()
    {

    }

    public Dificultad(string nombre, Vector3 velocidadMinima, Vector3 velocidadMaxima, int vidasIniciales, bool modoAutomatico)
    {
        Nombre = nombre;
        VelocidadMinima = velocidadMinima;
        VelocidadMaxima = velocidadMaxima;
        VidasIniciales = vidasIniciales;
        ModoAutomatico = modoAutomatico;
    }

    #endregion

    #region "Datos estaticos"

    /// <summary>
    /// Genera una pseudo-base de datos con las dificultades actualmente existentes
    /// </summary>
    private static List<Dificultad> listaDificultades = null;
    public static List<Dificultad> ListaDificultades
    {
        get
        {
            if (listaDificultades == null)
            {
                listaDificultades = new List<Dificultad>
                    {
                        new Dificultad("Facil", new Vector3(4f, 2f), new Vector3(6f, 0), 3, false),
                        new Dificultad("Medio", new Vector3(4.5f, 2f), new Vector3(7f, 0), 3, true),
                        new Dificultad("Dificil", new Vector3(5f, 2f), new Vector3(9f, 0), 2, true)
                    };
            }
            return listaDificultades;
        }

        set { listaDificultades = value; }
    }

    #endregion
}
