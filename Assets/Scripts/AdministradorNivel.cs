using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Este script se encarga de administrar elementos generales del nivel, como la m�sica de fondo, los canvas de inicio
 * y final, al igual que la actualizaci�n de los textos del puntaje y multiplicadores
*/

public class AdministradorNivel : MonoBehaviour
{
    public static AdministradorNivel instancia;

    public AudioSource CancionNivel;

    public int PuntajeActual;
    private int PuntajeGolpeExitoso = 100;
    private int MultiplicadorActual = 1;
    private int ContadorMultiplicador = 0;

    public TextMeshProUGUI TextoPuntajeActual;
    public TextMeshProUGUI TextoMultiplicadorActual;
    public TextMeshProUGUI TextoFinalNivel;

    public bool ComenzarNivel = false;

    public GameObject CanvasInicioNivel;
    public GameObject CanvasInfoNivel;

    void Start()
    {
        instancia = this;
        CanvasInicioNivel.SetActive(true);
        CanvasInfoNivel.SetActive(false);
    }

    void Update()
    {
        if (!ComenzarNivel)
        {
            if (Input.anyKeyDown)
            {
                empezarNivel();
            }
        }
    }

    public void empezarNivel()
    {
        ComenzarNivel = true;
        CancionNivel.Play();
        CanvasInicioNivel.SetActive(false);
        CanvasInfoNivel.SetActive(true);
    }

    public void NotaExitosa()
    {
        Debug.Log("�Nota exitosa!");
        PuntajeActual += PuntajeGolpeExitoso * MultiplicadorActual;
        TextoPuntajeActual.text = "Puntaje: " + PuntajeActual;

        ContadorMultiplicador++;

        if (ContadorMultiplicador >= 4)
        {
            MultiplicadorActual++;
            ContadorMultiplicador = 0;
        }
        else { }
        TextoMultiplicadorActual.text = "Multiplicador: x" + MultiplicadorActual;
    }

    public void NotaFallida()
    {
        Debug.Log("�Fallaste!");
        ContadorMultiplicador = 0;
        MultiplicadorActual = 1;
        TextoMultiplicadorActual.text = "Multiplicador: x" + MultiplicadorActual;
    }
}