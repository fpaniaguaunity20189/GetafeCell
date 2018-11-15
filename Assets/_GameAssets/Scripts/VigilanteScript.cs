using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VigilanteScript : MonoBehaviour {
    public Transform[] puntosPatrulla = new Transform[4];
    NavMeshAgent agente;
    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando };
    Estado estado = Estado.Idle;
    const int TIEMPO_ESPERA = 1;//TIEMPO DE ESPERA ENTRE ASIGNACIONES DE PUNTOS DE PATRULLA

    void Start () {
        agente = GetComponent<NavMeshAgent>();
        AsignarPuntoPatrulla();
    }
    void Update () {
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

    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance+0.1) {
                //animador.SetBool("andando", false);
                estado = Estado.Idle;
                Invoke("AsignarPuntoPatrulla", TIEMPO_ESPERA);
            }
        }
    }
    private void AsignarPuntoPatrulla() {
        int pp = Random.Range(0, puntosPatrulla.Length);
        agente.destination = puntosPatrulla[pp].position;
        estado = Estado.Andando;
    }
    public void SetTarget(Vector3 position) {
        agente.destination = position;
        estado = Estado.Andando;
    }
    /* ASIGNACION DE PUNTOS DE PATRULLA SECUENCIAL
    int pp = 0;
    private void AsignarPuntoPatrulla() {
        if (pp == puntosPatrulla.Length) pp = 0;
        agente.destination = puntosPatrulla[pp].position;
        estado = Estado.Andando;
        pp++;
    }
    */
}
