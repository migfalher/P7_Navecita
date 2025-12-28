using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AroManager : MonoBehaviour
{
    // public components
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
    }

    public void updateAro(int index)
    {
        if (index < aroList.Count) { aroList[index].GetComponent<Renderer>().material = matSiguiente; }
        aroList[index - 1].GetComponent<Renderer>().material = matCruzado;
        aroCount++;
    }
}
