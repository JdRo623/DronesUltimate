using UnityEngine;
using System.Collections;
using System;

public class PlayerLife : MonoBehaviour {
    public float saludInicial;
    public float saludActual;
    private float escudosIniciales;
    public float tiempoRecargaEscudos;
    public float volumenRecargaEscudos;
    public float escudosActual;
    public static bool muerte = false;
    public CharacterController jugador;
    private Vector3 movementVector;
    public HUDHandler hudHandler;
    private bool shieldIsActivated;
    private float alturaEnPiso;
    private float caida;
    private float gravity = 40;
    public AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip hitSound;
    // Use this for initialization
    void Start () {
        hudHandler.refreshLifeBar(saludInicial);
        escudosActual = escudosIniciales;
        saludActual = saludInicial;
        shieldIsActivated = false;
        Debug.Log("asdf"+saludActual);
        hudHandler.refreshLifeBar(saludInicial);
        audioSource.clip = hitSound;
    }

    internal void RestoreHealt()
    {
        saludActual = saludInicial;
        hudHandler.refreshLifeBar(saludActual);
    }

    public void dañoRecibido(float daño)
    {
        saludActual -= daño;
        if(!muerte)
        audioSource.Play();
        hudHandler.refreshLifeBar(saludActual);
    }

    public void dañoRecibidoEscudos(float daño)
    {
        escudosActual -= daño;
    }

    void comprobarMuerte()
    {
        if (saludActual <= 0)
        { 
            audioSource.clip = deathSound;
            if (muerte == false)
                audioSource.Play();
            muerte = true;
            hudHandler.setDeathScreen();
        }
    }
    public void recibirDaño(float daño)
    {
        if (escudosActual <= 0 || !shieldIsActivated)
        {
            dañoRecibido(daño);
        }
        else if (daño > escudosActual)
        {
            dañoRecibido(daño - escudosActual);
            dañoRecibidoEscudos(escudosActual);
            Invoke("recargarEscudos", tiempoRecargaEscudos);
        }
        else {
            dañoRecibidoEscudos(daño);
            Invoke("recargarEscudos", tiempoRecargaEscudos);
        }
    }
    float getAlturaActual()
    {
        return this.transform.localPosition.y;
    }

    void reiniciarCaida()
    {
        alturaEnPiso = getAlturaActual();
        caida = 0;
    }

    void dañoCaida()
    {
        if (alturaEnPiso > getAlturaActual())
        {

            caida += alturaEnPiso - getAlturaActual();
        }
        alturaEnPiso = getAlturaActual();

        if (caida > 7 && jugador.isGrounded)
        {
            recibirDaño(caida * 35);
            reiniciarCaida();
        }
        if (caida <= 7 && jugador.isGrounded)
        {
            reiniciarCaida();
        }

        if (caida > 40)
        {
            muerte = true;
            this.gameObject.SetActive(false);
        }
    }
    public void validarPiso()
    {
        if (jugador.isGrounded)
        {
            movementVector.y = 0;
        }
        movementVector.y -= gravity * Time.deltaTime;
        jugador.Move(movementVector * Time.deltaTime);

    }
    // Update is called once per frame
    void Update () {
        validarPiso();
        comprobarMuerte();
    }
}
