using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LlaveScript : MonoBehaviour {
    public Animator animatorPuerta;
    public VigilanteScript vs;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Fernandito") {
            AbrirPuerta();
        }
    }
    private void AbrirPuerta() {
        vs.SetDistraccion(transform.position);
        animatorPuerta.SetBool("AbreteSesamo", true);
        Destroy(gameObject);
    }
}