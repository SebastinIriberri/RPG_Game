using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour {
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;
    [Header("Configuración")]
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    private float expActual;
    private float expActualTmp;
    private float expRequeridaSiguienteNivel;
    private void Start() {
        stats.Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
        stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
        ActualizarBarraExp();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            AñadirExperiencia(10f);
        }
    }

    public void AñadirExperiencia(float expObtenida) {
        if (expObtenida > 0f) {
            float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTmp;
            if (expObtenida >= expRestanteNuevoNivel) {
                expObtenida -= expRestanteNuevoNivel;
                expActual += expObtenida;
                ActualizarNivel();
                AñadirExperiencia(expObtenida);
            }
            else {
                expActual += expObtenida;
                expActualTmp += expObtenida;
                if (expActualTmp == expRequeridaSiguienteNivel) {
                    ActualizarNivel();
                }
            }
        }
        stats.ExpActual = expActual;
        ActualizarBarraExp();
    }

    private void ActualizarNivel() {
        if (stats.Nivel < nivelMax) { 
            stats.Nivel++;
            expActualTmp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
            stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
            stats.PuntosDisponibles += 3;
        }
    }

    private void ActualizarBarraExp() {
        UIManager.Instance.ActualizarExpPersonaje(expActualTmp,expRequeridaSiguienteNivel);
    }
}
