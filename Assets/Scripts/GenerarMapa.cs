using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Genera el mapa de la actuación a partir de un archivo de texto
/// </summary>
public class GenerarMapa : MonoBehaviour {
    
    public List<Transform> PFs;

    public float Contador { get; set; }

    /// <summary>
    /// Lee el archivo para generar el mapa
    /// </summary>
    void Start()
    {
        var sr = new StreamReader(Application.dataPath + "/" + Actuacion.ListaActuaciones[MainMenu_MoverCamara.Actual].Mapa + LevantarTelon.DificultadActual.Sufijo + ".txt");
        while (!sr.EndOfStream)
        {
            string contenido = sr.ReadLine();

            //Lee los distintos caracteres de la línea
            for (int i = 0; i < contenido.Length; i++)
            {
                //Dependiendo del caracter leído instancia uno u otro objeto prefabricado
                switch (contenido[i])
                {
                    case '$':
                        Instanciador(i, PFs[0]);
                        break;

                    case '#':
                        Instanciador(i, PFs[1]);
                        break;

                    case '@':
                        Instanciador(i, PFs[2]);
                        break;

                    case '_':
                        Instanciador(i, PFs[3]);
                        break;

                    case '*':
						Instanciador(i, PFs[4]);
						break;

                    case 'P':
                        Instanciador(i, PFs.First(P => P.name.Contains("Personaje")));
                        break;

                    case 'F':
                        Instanciador(i, PFs.First(F => F.name.Contains("Final")));
                        break;
                }
            }

            if (!Application.loadedLevelName.Contains("Trampolin"))
            {
                Contador += (float)PFs[0].transform.localScale.y * 1 / -4.37f;
            }
            else
            {
                
                Contador += (float)PFs[0].transform.localScale.y * 1 / -8.37f;
            }

                
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
        if (!Application.loadedLevelName.Contains("Trampolin")) {
            if (Actuacion.ListaActuaciones[MainMenu_MoverCamara.Actual].Tipo == Actuacion.E_TipoActuacion.Techo)
                Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador + 5.3f, aInstanciar.localPosition.z), transform.rotation);
            else
                Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador, aInstanciar.localPosition.z), transform.rotation);
        }
        else if (Application.loadedLevelName.Contains("Trampolin"))
        {
            if(aInstanciar!=PFs[2] && aInstanciar != PFs[1])
                Instantiate(aInstanciar, new Vector3((float)((i / 2.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador + 10, aInstanciar.localPosition.z), transform.rotation);
            else if (aInstanciar == PFs[1])
            {
                if (aInstanciar == PFs[1])
                    Instantiate(aInstanciar, new Vector3((float)((i / 2.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador + 10.28f, aInstanciar.localPosition.z), transform.rotation);
            }
            else
                Instantiate(aInstanciar, new Vector3((float)((i / 2.4f) * aInstanciar.transform.localScale.x) - 6.8f, Contador +10.25f , aInstanciar.localPosition.z), transform.rotation);

        }
    }
}
