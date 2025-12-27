using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Public components
    public float velocidadRotacion = 0;
    public float distanciaPlayer = 0;

    // private components
    private float rotSpeed;
    private Vector3 rotVector;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotSpeed = velocidadRotacion;
        rotVector = new Vector3(0, 0, rotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.transform.parent.parent.gameObject;
        rotSpeed = velocidadRotacion * 10;
        rotVector.z = rotSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        float distancia = Vector3.Distance(this.transform.position, player.transform.position);
        if (distancia < 10) { this.gameObject.SetActive(false); }
    }

    private void OnTriggerExit(Collider other)
    {
        rotSpeed = velocidadRotacion * 1;
        rotVector.z = rotSpeed;
    }

    public void setRotSpeed(float speed) {  rotSpeed = velocidadRotacion * speed; }
}
