using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : Singleton<Inventario> {
    [SerializeField] private int numeroDeSlots;
    public int NumeroDeSloats => numeroDeSlots;
    [Header("Items")]
    [SerializeField] private InventarioItem[] itemsInventario;

    private void Start() {
        itemsInventario = new InventarioItem[numeroDeSlots];        
    }
}
