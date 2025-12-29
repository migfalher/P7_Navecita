using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AroManager : MonoBehaviour
{
    // public components
    public TMP_Text aroTMP;
    public Material matEspera;
    public Material matSiguiente;
    public Material matCruzado;

    // private components
    private List<GameObject> aroList = new List<GameObject>();
    private int aroCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i < 11; i++)
        {
            GameObject aro = GameObject.Find(string.Format("Aro ({0})", i));
            aro.GetComponent<Renderer>().material = matEspera;
            aro.GetComponent<Aro>().manager = this;
            aroList.Add(aro);
        }

        aroList[0].GetComponent<Renderer>().material = matSiguiente;

        aroCount = aroList.Count;
        aroTMP.text = aroCount.ToString("00");
    }

    // each individual 'aro' calls method 'updateAro' to update itself and the next 'aro'
    public void updateAro(int index)
    {
        GameObject aroActual = aroList[index - 1];
        GameObject aroSiguiente = (index < aroList.Count) ? aroList[index] : null;

        if (index - 1 < aroList.Count) {
            Material mat = aroActual.GetComponent<Renderer>().sharedMaterial;
            if (mat == (matSiguiente)) {
                if (aroSiguiente != null) { aroSiguiente.GetComponent<Renderer>().material = matSiguiente; }
                aroActual.GetComponent<Renderer>().material = matCruzado;
                aroCount--;
                aroTMP.text = aroCount.ToString("00");
            } else {
                Debug.Log("ORDEN INCORRECTO");
            }
        }
    }
}
