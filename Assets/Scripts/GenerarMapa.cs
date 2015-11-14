using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class GenerarMapa : MonoBehaviour {

    public string Archivo;
    public List<Transform> PFs;

    public float Contador { get; set; }

    void Start()
    {
        var sr = new StreamReader(Application.dataPath + "/" + Archivo);
        while (!sr.EndOfStream)
        {
            string contenido = sr.ReadLine();

            for (int i = 0; i < contenido.Length; i++)
            {
                switch (contenido[i])
                {

                    case '$':
                        Instanciador(i, PFs[0]);
                        break;

                    case '#':
                        Instanciador(i, PFs[1]);
                        break;

                    case 'P':
                        Instanciador(i, PFs.First(P => P.name.Contains("Personaje")));
                        break;
                }
            }

            Contador += (float)PFs[0].transform.localScale.y * 1 / -4.37f;
        }

        sr.Close();


    }

    /// <summary>
    /// Instancia objetos prefabricados tomando en cuenta su posición en la línea para colocarlos en cuanto X
    /// </summary>
    /// <param name="i"></param>
    /// <param name="aInstanciar"></param>
    public void Instanciador(int i, Transform aInstanciar)
    {
        Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador, aInstanciar.localPosition.z), transform.rotation);
    }
}
