using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cañon : MonoBehaviour
{

    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCañon;
    private float rotacion;



    private void Start()
    {
        puntaCañon = transform.Find("PuntaCañon").gameObject;

    }
    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if (rotacion > 90) rotacion = 90;
        if (rotacion <0) rotacion = 0;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(BalaPrefab, puntaCañon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            tempRB.linearVelocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
        }
    }
}
