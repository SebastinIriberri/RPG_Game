﻿using UnityEngine;
[CreateAssetMenu(menuName = ("Items/Pocion Vida"))]
public  class ItemPocionVida: InventarioItem {
    [Header("Pocion Info")]
    public float HPRestauracion;

    public override bool UsarItem() {
        if (Inventario.Instance.Personaje.PersonajeVida.PuedeSerCurado) {
            Inventario.Instance.Personaje.PersonajeVida.RestaurarSalud(HPRestauracion);
            return true;
        }
        else { 
            return false;
        }
    }
}

