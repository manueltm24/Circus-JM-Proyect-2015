using UnityEngine;
using System.IO;
using System.Collections;

public class GenerarMapaActuacionArosFuego : MonoBehaviour {
	string archivo = "mapa-arosfuego.txt";
	public Transform PF_ArosFuegoGrande;
	public Transform PF_LeonPersonaje;
	
	public float Contador { get; set; }
	
	void Start()
	{
		var sr = new StreamReader(Application.dataPath + "/" + archivo);
		while (!sr.EndOfStream)
		{
			string contenido = sr.ReadLine();
			var contenido2 = contenido.Split(" "[0]);
			for (int i = 0; i < contenido2.Length; i++)
			{
				switch (contenido2[i])
				{
					
				case "$":
					Instanciador(i, PF_ArosFuegoGrande, contenido2.Length);
					break;
					
				case "P":
					Instanciador(i, PF_LeonPersonaje, contenido2.Length);
					break;
				}
			}
			
			Contador += (float)PF_LeonPersonaje.transform.localScale.y * 1 / -4f;
		}
		
		sr.Close();
		
		
	}
	
	public void Instanciador(int i, Transform aInstanciar, int limite)
	{
		Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador, aInstanciar.localPosition.z), transform.rotation);
	}
}
