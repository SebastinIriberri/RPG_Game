using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour {
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    public float Salud { get; protected set; }

    protected virtual void Start() {
        Salud = saludInicial;
    }

    public void RecibirDa�o(float cantidadDa�o) {
        if (cantidadDa�o <= 0) {
            return;
        }
        if (Salud > 0f ) { 
            Salud -= cantidadDa�o;
            ActualizarBarraVida(Salud,saludMax);
            if (Salud <= 0) {
                ActualizarBarraVida(Salud,saludMax);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual , float vidaMax) { 
    
    }

    protected virtual void PersonajeDerrotado() { 
    
    }
}
