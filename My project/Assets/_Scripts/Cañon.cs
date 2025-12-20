using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cañon : MonoBehaviour
{
    public static bool Bloqueado;


    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCañon;
    private float rotacion;
    public AdministradorJuego administrador;


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

        if(Input.GetKeyDown(KeyCode.Space)&&!Bloqueado)
        {
            if (AdministradorJuego.DisparosPorJuego > 0)
            {
                GameObject temp = Instantiate(BalaPrefab, puntaCañon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                SeguirCamara.objetivo = temp;
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;
                tempRB.linearVelocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
                Bloqueado = true;

                AdministradorJuego.DisparosPorJuego--;
            }
            else
            {
                Debug.Log("¡Ya no quedan disparos!");
            }
        }
    }
}
