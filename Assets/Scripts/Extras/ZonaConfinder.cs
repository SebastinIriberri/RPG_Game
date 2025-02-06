using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZonaConfinder : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera camara;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            camara.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            camara.gameObject.SetActive(false);
        }
    }
}
