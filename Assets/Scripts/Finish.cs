using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // public components
    public TMP_Text estadoTMP;
    public TMP_Text estadoShadow;
    public TMP_Text arosTMP;
    public TMP_Text monedasTMP;
    public TMP_Text tiempoTMP;
    public TMP_Text puntuacionTMP;

    // private components
    private int minutos = 0;
    private int segundos = 0;
    private string estado = "";
    private int puntuacion = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minutos = Mathf.FloorToInt(Data.segundos / 60F);
        segundos = Mathf.FloorToInt(Data.segundos - (minutos * 60F));

        estado = (Data.victoria) ? "HAS GANADO" : "HAS PERDIDO";
        puntuacion = Data.segundos + (Data.monedas * 2);

        estadoTMP.text = estado;
        estadoShadow.text = estado;
        arosTMP.text = Data.aros.ToString();
        monedasTMP.text = Data.monedas.ToString();
        tiempoTMP.text = $"{minutos:00}:{segundos:00}";
        puntuacionTMP.text = puntuacion.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
