using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
    //Parametros iniciales del jugador
    public float velocidadJugador;
    public float velocidadRotacion;
    // private Transform camara;
    private CharacterController PLARE;
    private Vector3 movementVector;
    private float jumpPower = 23;
    private float gravity = 0;
    public float runningVelocity;
    private float evadeCooldown;
    private float timePassSinceEvade;
    public float runningFieldOfView;
    public HUDHandler hudHandler;
    public AudioSource audioSource;
    public AudioClip runClip;
    //Parametros de los metodos de movimiento
    float rotacionx;
    bool rangoMovSup;
    bool rangoMovInf;
    bool arriba;
    bool abajo;
    private bool isRunning = false;
    // Use this for initialization
    void Start()
    {
        audioSource.clip = runClip;
        timePassSinceEvade = 0;
        evadeCooldown = 5;
        initRangosRotacionVista();
      //  camara = this.gameObject.transform.GetChild(0);
        runningFieldOfView = 60;
    }

    private void initRangosRotacionVista() {
        rotacionx = this.transform.rotation.eulerAngles.x;
        rangoMovSup = (rotacionx >= 277 && rotacionx <= 360);
        rangoMovInf = (rotacionx >= 0 && rotacionx <= 60);
        arriba = rotacionx <= 277 && rotacionx > 270;
        abajo = rotacionx >= 60 && rotacionx < 70;
    }

    public void unsopported()
    {
        Debug.Log("Unsupported");
    }
    public void fowardMovement()
    {
        this.transform.Translate((Vector3.forward * (Input.GetAxis("PSLeftJoystickY")) * -1) * velocidadJugador * Time.deltaTime);
    }
    public void backwardsMovement()
    {
        this.transform.Translate((Vector3.back * (Input.GetAxis("PSLeftJoystickY"))) * velocidadJugador * Time.deltaTime);
    }
    public void rigthMovement()
    {
        this.transform.Translate((Vector3.right * (Input.GetAxis("PSLeftJoystickX"))) * velocidadJugador * Time.deltaTime);
    }
    public void leftMovement()
    {
        this.transform.Translate((Vector3.left * (Input.GetAxis("PSLeftJoystickX")) * -1) * velocidadJugador * Time.deltaTime);
    }

    public void validarLimitesVista()
    {
     /*   rotacionx = camara.rotation.eulerAngles.x;
        rangoMovSup = (rotacionx >= 277 && rotacionx <= 360);
        rangoMovInf = (rotacionx >= 0 && rotacionx <= 60);
        if (rangoMovSup && !rangoMovInf)
        {
            this.arriba = true;
            this.abajo = false;
        }
        else if (!rangoMovSup && rangoMovInf)
        {
            this.abajo = true;
            this.arriba = false;
        }*/
    }
    public void UpAndDown()
    {
        Debug.Log("It´s going up");
        this.transform.Translate((Vector3.down * (Input.GetAxis("PSRigthJoystickY")) * -1) * velocidadJugador * Time.deltaTime);
        /* validarLimitesVista();

         if (rangoMovSup || rangoMovInf)
         {
             camara.transform.Rotate(new Vector3(Input.GetAxis("RigthJoystickY") * velocidadRotacion * Time.deltaTime, 0, 0));
         }
         else if (arriba && Input.GetAxis("RigthJoystickY") > 0)
         {
             camara.transform.Rotate(new Vector3(Input.GetAxis("RigthJoystickY") * velocidadRotacion * Time.deltaTime, 0, 0));
         }
         else if (abajo && Input.GetAxis("RigthJoystickY") < 0)
         {
             camara.transform.Rotate(new Vector3(Input.GetAxis("RigthJoystickY") * velocidadRotacion * Time.deltaTime, 0, 0));
         }*/
    }

    public void run() {
        if (!isRunning)
        {
            isRunning = true;
            velocidadJugador+=runningVelocity;
            audioSource.Play();
            hudHandler.setMiraOff();
        }else {
            velocidadJugador -=runningVelocity;
            isRunning = false;
            audioSource.Stop();
            hudHandler.setMiraOff();
        }
 
    }
    public void changeCameraRunning() {
        Camera.main.fieldOfView = 100;
    }
    public void lookSides()
    {
        this.transform.Rotate(new Vector3(0, Input.GetAxis("RigthJoystickX") * velocidadRotacion * Time.deltaTime, 0));
    }

    public void cambiarVelocidadMira(float nuevaVelocidad)
    {
        velocidadRotacion = nuevaVelocidad;
    }

    void Update() {
        this.transform.rotation = Camera.main.transform.rotation;
        Camera.main.transform.position = this.transform.position;
        timePassSinceEvade += Time.deltaTime;
        if (isRunning) {
            changeCameraRunning();
        }
    }
}
