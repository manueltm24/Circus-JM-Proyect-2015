using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.Serialization;

/// <summary>
/// Describe el desplazamiento del personaje principal y las interrupciones que puede encontrar en su trayecto
/// </summary>
public class Desplazamiento : Personaje
{
    public Vector3 Altura { get; set; }
    public Transform Ganador;
    public Transform Muerto1;
    public int NivelActual;

    public float VelocidadInicialAnimacion { get; set; }

    public Vector3 PosicionGuardada { get; set; }

    public static Vector3 CheckPoint { get; set; }

    public static bool ResetRequestCompletado { get; set; }

    public static bool Gano { get; set; }

    void Awake()
    {
        NivelActual = Application.loadedLevel;
        Velocidad = new Vector3(4f, 2f);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = E_Direcciones.Reposo;
        PosicionInicialY = transform.localPosition.y;
        VelocidadInicialAnimacion = this.gameObject.GetComponent<Animator>().speed;
        CheckPoint = transform.localPosition;
        Gano = false;
        if (!Application.loadedLevelName.Contains("Rueda") && Enterrado)
        {
            Enterrado = false;
        }
    }

    void Update()
    {
        Altura = this.gameObject.transform.position;
        if (Altura.y >= -1f)
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        if (!Gano && Vidas > 0)
        {
            if (!Application.loadedLevelName.Contains("Cuerda"))
                if (Application.loadedLevelName.Contains("Aro"))
                    DesplazarseX(LevantarTelon.DificultadActual.ModoAutomatico);
                else
                    DesplazarseX();
            else
                MovimientoEnElAire();


            EmpezarSalto();
            Saltar();
            CambioVelocidad();

            if (Saltando)
                this.gameObject.GetComponent<Animator>().speed = 0;
        }
    }

    void FixedUpdate()
    {
        Tiempo = (int)Time.timeSinceLevelLoad + TiempoAntesMorir;
    }

    /// <summary>
    /// Maneja las colisiones del personaje con respecto a \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        /*if (colisionado.name.Contains("Aro") || colisionado.name.Contains("Final") || (colisionado.name.Contains("Suelo") && !Application.loadedLevelName.Contains("Aro")))
        {
            GameObject.Find(gameObject.name).GetComponent<AudioSource>().Play();
        }ESTO DEBERIA IR EN EL START() DE MUERTO Y VICTORIA*/



        if (colisionado.name.Contains("Suelo") || colisionado.name.Contains("Rueda") || colisionado.name.Contains("Final"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
            Saltando = false;
            this.gameObject.GetComponent<Animator>().speed = VelocidadInicialAnimacion;
        }

        if (colisionado.name.Contains("Rueda") || colisionado.name == "PF_CuerdaBalanceo(Clone)" || colisionado.name.Contains("CheckPointAros"))
        {
            Puntuacion += 200;
            CheckPoint = transform.localPosition;
        }
        
        if (colisionado.name.Contains("Final"))
        {
            PosicionGuardada = transform.localPosition;
            Destroy(this.gameObject);
            Instantiate(Ganador, new Vector3(PosicionGuardada.x, PosicionGuardada.y, PosicionGuardada.z), transform.rotation);
            Personaje.TraslacionX = 0;

            if (Puntuacion > CambiarTextoActuacion.PuntuacionMaxima)
                XML_GuardarNuevaPuntuacionMaxima();

            if (Tiempo < CambiarTextoActuacion.TiempoRecord)
                XML_GuardarNuevoTiempoRecord();

            Gano = true;
        }

        if (colisionado.name.Contains("Cuerda") && SaltandoDeTrampolin)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            DireccionActual = E_Direcciones.Reposo;
            SaltandoDeTrampolin = false;
            Saltando = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            TraslacionX = 0;
        }

        if (colisionado.name.Contains("Trampolin"))
        {
      
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
            Saltando = false;
            DireccionActual = E_Direcciones.Arriba;
            SaltandoDeTrampolin = true;
            Saltar();
        }

        if (colisionado.name.Contains("Barra"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        //Maneja la perdida de vidas del personaje al colisionar con objetos asesinos
        if (colisionado.name.Contains("Jarron") || colisionado.name.Contains("AroFuego") || colisionado.name.Contains("Palo"))
            Morir(Muerto1);

        //Maneja la perdida de vidas del personaje al caer al suelo
        if (colisionado.name.Contains("Suelo") && (Application.loadedLevelName.Contains("Cuerda")  || Application.loadedLevelName.Contains("Rueda") || Application.loadedLevelName.Contains("Trampolin")))
            Morir(Muerto1);

    }

    /// <summary>
    /// Maneja cuando el personaje deja de colisionar con \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Suelo") || colisionado.name.Contains("Rueda"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    /// <summary>
    /// Acelera al personaje
    /// </summary>
	public void CambioVelocidad()
    {
        if (Input.GetKey(KeyCode.W))
            Velocidad = new Vector3(6f, 0);
        else
            Velocidad = new Vector3(4f, 0);
    }

    /// <summary>
    /// Guarda la puntuación maxima
    /// </summary>
    private void XML_GuardarNuevaPuntuacionMaxima()
    {
        using (var fileStream = new FileStream(Actuacion.ListaActuaciones[Application.loadedLevel - 1].PuntuacionMaximaArchivo + LevantarTelon.DificultadActual.Sufijo + ".xml", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));
            serializer.WriteObject(fileStream, Personaje.Puntuacion);
        }
    }

    /// <summary>
    /// Guarda el tiempo record
    /// </summary>
    private void XML_GuardarNuevoTiempoRecord()
    {
        using (var fileStream = new FileStream(Actuacion.ListaActuaciones[Application.loadedLevel - 1].TiempoRecordArchivo + LevantarTelon.DificultadActual.Sufijo + ".xml", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(double));
            serializer.WriteObject(fileStream, Personaje.Tiempo);
        }
    }
}