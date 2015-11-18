﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Genera el mapa de la actuación a partir de un archivo de texto
/// </summary>
public class GenerarMapa : MonoBehaviour {

    public string Archivo;
    public List<Transform> PFs;
    public float Contador { get; set; }

    /// <summary>
    /// Lee el archivo para generar el mapa
    /// </summary>
    void Start()
    {
        var sr = new StreamReader(Application.dataPath + "/" + Archivo);
        while (!sr.EndOfStream)
        {
            string contenido = sr.ReadLine();

            //Lee los distintos caracteres de la línea
            for (int i = 0; i < contenido.Length; i++)
            {
                //Dependiendo del caracter leído instancia uno u otro objeto prefabricado
                switch (contenido[i])
                {
					case '_':
						Instanciador(i, PFs[3]);
						break;
                    case '$':
                        Instanciador(i, PFs[0]);
                        break;

                    case '#':
                        Instanciador(i, PFs[1]);
                        break;
<<<<<<< HEAD
                    case '@':
                        Instanciador(i, PFs[2]);
                        break;

                    case '*':
                        Instanciador(i, PFs[3]);
                        break;
=======
					case '*':
						Instanciador(i, PFs[4]);
						break;
>>>>>>> a6cc4adc12d834764cb5ce1a60503e7f93f048e0

                    case 'P':
                        Instanciador(i, PFs.First(P => P.name.Contains("Personaje")));
                        break;

                    case 'F':
                        Instanciador(i, PFs.First(F => F.name.Contains("Final")));
                        break;
                }
            }

            Contador += (float)PFs[0].transform.localScale.y * 1 / -4.37f;

        }

        sr.Close();
    }

    /// <summary>
    /// Instancia objetos prefabricados tomando en cuenta su posición en la línea del archivo para colocarlos en cuanto X
    /// </summary>
    /// <param name="i"></param>
    /// <param name="aInstanciar"></param>
    public void Instanciador(int i, Transform aInstanciar)
    {
        Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador, aInstanciar.localPosition.z), transform.rotation);
    }
}
