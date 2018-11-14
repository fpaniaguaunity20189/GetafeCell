using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScript : MonoBehaviour {
    public Animator animatorPuerta;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Fernandito") {
            AbrirPuerta();
        }
    }
    private void AbrirPuerta() {
        animatorPuerta.SetBool("AbreteSesamo", true);
        Destroy(gameObject);
    }
}