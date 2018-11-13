using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FernanditoScript : MonoBehaviour {
    public GameObject targetCircle;
    public Camera camara;

    Animator animador;
    NavMeshAgent agente;
	void Start () {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
        }
        print(agente.remainingDistance);
        if (agente.remainingDistance <= agente.stoppingDistance) {
            animador.SetBool("andando", false);
        }
	}

    private void ManageMouseClick() {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        bool hasTouch = Physics.Raycast(ray, out rch);
        if (hasTouch) {
            targetCircle.transform.position = rch.point;
            targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
            agente.destination = targetCircle.transform.position;
            animador.SetBool("andando", true);
        }
    }

}
