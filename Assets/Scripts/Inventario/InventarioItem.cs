using UnityEngine;

public enum TipoDeItem {Armas,Pociones,Pergaminos,Ingredientes,Tesoros }
public  class InventarioItem:ScriptableObject {
    [Header("Parametros")]
    public string ID;
    public string Nombre;
    public Sprite Icono;
    [TextArea] public string Descripcion;

    [Header("Informacion")]
    public TipoDeItem Tipo;
    public bool EsConsumible;
    public bool EsAcumulable;
    public int AcumulacionMax;

    [HideInInspector] public int Cantidad;

    public InventarioItem CopiarInventrarioItem() { 
        InventarioItem nuevoInstancia = Instantiate(this);
        return nuevoInstancia;
    }

    public virtual bool UsarItem() { 
        return true;
    }
    public virtual bool EquiparIteam() { 
        return true;
    }

    public virtual bool RemoverItem() { 
        return true;
    }
}

