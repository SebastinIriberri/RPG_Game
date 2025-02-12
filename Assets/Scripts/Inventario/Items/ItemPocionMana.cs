using UnityEngine;
[CreateAssetMenu(menuName = ("Items/Pocion Mana"))]

public  class ItemPocionMana: InventarioItem {
    [Header("Pocion Info")]
    public float MRRestauracion;

    public override bool UsarItem() {
        if (Inventario.Instance.Personaje.PersonajeMana) {
            Inventario.Instance.Personaje.PersonajeMana.RestaurarMana(MRRestauracion);
            return true;
        }
        else { 
            return false;
        }
    }
}

