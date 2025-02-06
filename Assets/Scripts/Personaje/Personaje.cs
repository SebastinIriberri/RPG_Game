using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
    [SerializeField] PersonajeStats stats;
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeMana PersonajeMana { get; private set; }
    public PersonajeAnimaciones PersonajeAnimaciones { get; private set; }


    private void Awake() {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeMana = GetComponent<PersonajeMana>();
        PersonajeAnimaciones = GetComponent<PersonajeAnimaciones>();
    }

    public void RestaurarPersonaje() { 
        PersonajeVida.RestaurarPersonaje();
        PersonajeMana.RestablecerMana();
        PersonajeAnimaciones.RevivirPersonaje();
    }
    private void AtribitoRespuesta(TipoAtributo tipo) {
        if (stats.PuntosDisponibles <= 0) {
            return;
        }
        switch (tipo) { 
            case TipoAtributo.Fuerza:
                stats.AñadirBoundPorAtributoFuerza();
                break;
            case TipoAtributo.Inteligencia:
                stats.AñadirBoundPorAtributoInteligencia();
                break;
            case TipoAtributo.Destreza:
                stats.AñadirBoundPorAtributoDestreza();
                break;
        }
        stats.PuntosDisponibles--;
    }
    private void OnEnable() {
        AtributoButton.EventoAgregarAtributo += AtribitoRespuesta;
    }

    private void OnDisable() {
        AtributoButton.EventoAgregarAtributo -= AtribitoRespuesta;
    }
}
