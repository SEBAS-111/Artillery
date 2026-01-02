using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Cañon : MonoBehaviour
{
    public Slider fuerzaSlider;
    public float fuerzaMinima = 0.5f;
    public float fuerzaMaxima = 1.5f;
    public static bool Bloqueado;

    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;


    [SerializeField] private GameObject BalaPrefab;
    public GameObject ParticulasDisparo;
    private GameObject puntaCañon;
    private float rotacion;

    public _CañonControles canonControl;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    public AdministradorJuego administrador;

    private void Awake()
    {
        canonControl = new _CañonControles();
    }

    private void OnEnable()
    {
        apuntar = canonControl.Cañon.Apuntar;
        modificarFuerza = canonControl.Cañon.ModificarFuerza;
        disparar = canonControl.Cañon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
    }


    private void Start()
    {
        puntaCañon = transform.Find("PuntaCañon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if (rotacion > 90) rotacion = 90;
        if (rotacion <0) rotacion = 0;



        if (Input.GetKeyDown(KeyCode.Space)&&!Bloqueado)
        {
            if (AdministradorJuego.DisparosPorJuego > 0)
            {

                AdministradorJuego.DisparosPorJuego--;
            }
            else
            {
                Debug.Log("¡Ya no quedan disparos!");
            }
        }
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if (Bloqueado == false && AdministradorJuego.DisparosPorJuego > 0)
        {
            GameObject temp = Instantiate(BalaPrefab, puntaCañon.transform.position, transform.rotation);

            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            GameObject Particulas = Instantiate
                (ParticulasDisparo, puntaCañon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.linearVelocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala * fuerzaSlider.value;
            //SourceDisparo.PlayOneShot(clipDisparo);
            AdministradorJuego.DisparosPorJuego--;
            SourceDisparo.Play();
            Bloqueado = true;
        }

        disparar.performed += Disparar;
        modificarFuerza.performed += ModFuerza_ejemploFuncion;
    }

    private void OnDisable()
    {
        disparar.performed -= Disparar;
        modificarFuerza.performed -= ModFuerza_ejemploFuncion;
    }

    private void ModFuerza_ejemploFuncion(InputAction.CallbackContext context)
    {
        float valorinput = context.ReadValue<float>();

        if (valorinput == 1f)
        {
            fuerzaSlider.value += 1f;
        }
        else if (valorinput == -1f)
        {
            fuerzaSlider.value -= 1f;
        }

    }
}
