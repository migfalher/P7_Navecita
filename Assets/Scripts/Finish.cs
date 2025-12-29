using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // public components
    public TMP_Text estadoTMP;
    public TMP_Text estadoShadow;
    public TMP_Text puntuacionTMP;

    // private components
    private string estado = "";
    private int puntuacion = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estado = (Data.victoria) ? "HAS GANADO" : "HAS PERDIDO";
        puntuacion = Data.segundos + (Data.monedas * 2);

        estadoTMP.text = estado;
        estadoShadow.text = estado;
        puntuacionTMP.text = puntuacion.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
