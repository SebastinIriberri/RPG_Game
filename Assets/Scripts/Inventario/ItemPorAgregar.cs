using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPorAgregar : MonoBehaviour {
    [Header("Configuracion")]
    [SerializeField] private InventarioItem inventarioIteamReferencia;
    [SerializeField] private int cantidadPorAgregar;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Inventario.Instance.A�adirItem(inventarioIteamReferencia, cantidadPorAgregar);
            Destroy(this.gameObject);
        }
    }
}
