using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetardoScript : MonoBehaviour {
    public int timeToDestroy = 3;
    private VigilanteScript vs;
    private bool primeraVez = true;
    private void Start() {
        vs = GameObject.Find("Vigilante").GetComponent<VigilanteScript>();
    }
    private void OnCollisionEnter(Collision collision) {
        if (primeraVez) {
            vs.SetDistraccion(transform.position);
            primeraVez = false;
            Destroy(this.gameObject, timeToDestroy);
        }
    }
}
