using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FernanditoScript : MonoBehaviour {
    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando };
    Estado estado = Estado.Idle;

    public Transform puntoGeneracionPetardos;
    public GameObject prefabPetardo;

    public GameObject targetCircle;
    public Camera camara;
    public LayerMask walkableLayer;

    public int fuerzaLanzamientoPetardo;

    Animator animador;
    NavMeshAgent agente;


    void Start() {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            GenerarYLanzarPetardo();
        }
        if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
        }
        switch (estado) {
            case Estado.Idle:
                //NO HAGO NADA
                break;
            case Estado.Andando:
                ComprobarDestino();
                break;
            case Estado.Saltando:

                break;
            case Estado.Corriendo:

                break;
            case Estado.Disparando:

                break;
        }
    }

    private void GenerarYLanzarPetardo() {
        GameObject nuevoPetardo = Instantiate(
                        prefabPetardo,
                        puntoGeneracionPetardos.position,
                        puntoGeneracionPetardos.rotation);
        nuevoPetardo.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaLanzamientoPetardo);
    }

    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance) {
                animador.SetBool("andando", false);
                estado = Estado.Idle;
            }
        }
    }

    private void ManageMouseClick() {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        bool hasTouch = Physics.Raycast(ray, out rch, Mathf.Infinity, walkableLayer);
        if (hasTouch) {
            switch (estado) {
                case Estado.Idle:
                    Andar(rch);
                    break;
                case Estado.Andando:

                    break;
                case Estado.Saltando:

                    break;
                case Estado.Corriendo:

                    break;
                case Estado.Disparando:

                    break;
            }
        }
    }
    private void Andar(RaycastHit rch) {
        targetCircle.transform.position = rch.point;
        targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
        agente.destination = targetCircle.transform.position;
        animador.SetBool("andando", true);
        estado = Estado.Andando;
    }

}
