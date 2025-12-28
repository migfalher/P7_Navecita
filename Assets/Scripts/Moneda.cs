using Unity.VisualScripting;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Public components
    public float velocidadRotacion = 0;
    public float distanciaPlayer = 0;
    public MonedaManager manager;

    // private components
    private Vector3 rotVector;
    private GameObject player;
    private bool entered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotVector = new Vector3(0, 0, velocidadRotacion);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(this.transform.position, player.transform.position);

        rotVector.z = (distancia < 20) ? velocidadRotacion * 5 : velocidadRotacion * 1;

        this.transform.Rotate(rotVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (entered == false)
        {
            entered = true;
            this.gameObject.SetActive(false);
            manager.sumUpMonedaCount();
        }
    }
}
