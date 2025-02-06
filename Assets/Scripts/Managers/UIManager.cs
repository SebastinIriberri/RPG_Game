using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;
    
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDañoTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpReqTMP;
    [Header("Atributos")]
    [SerializeField] private TextMeshProUGUI atributoFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributoInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributoDestrezaTMP;
    [Header("Puntos disponibles")]
    [SerializeField] private TextMeshProUGUI puntosDisponiblesTMP;

    private float vidaActual;
    private float manaActual;
    private float expActual;
    private float vidaMax;
    private float manaMax;
    private float expRequeridaNuevoNivel;
    private void Update() {
        ActualizarUIPersonaje();
        PanelStats();
    }
    private void ActualizarUIPersonaje() {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual / vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount,manaActual / manaMax, 10 * Time.deltaTime);
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, expActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);

        vidaTMP.text = $"{vidaActual}/{vidaMax}";
        manaTMP.text = $"{manaActual}/{manaMax}";
        expTMP.text  =  $"{((expActual / expRequeridaNuevoNivel) * 100):F2} %";
        nivelTMP.text = $"Nivel: {stats.Nivel}";
    }
    private void PanelStats() {
        if (panelStats.activeSelf == false) { 
            return;
        }
        statDañoTMP.text = stats.Daño.ToString();
        statDefensaTMP.text = stats.Defensa.ToString();
        statCriticoTMP.text = $"{(stats.PorcentajeCritico):F2}%";
        statBloqueoTMP.text = $"{(stats.PorcentajeBloqueo):F2}%";
        statVelocidadTMP.text = $"{(stats.Velocidad):F2}";
        statNivelTMP.text = stats.Nivel.ToString();
        statExpTMP.text = stats.ExpActual.ToString();
        statExpReqTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
        atributoFuerzaTMP.text = stats.Fuerza.ToString();
        atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
        atributoDestrezaTMP.text = stats.Destreza.ToString();
        puntosDisponiblesTMP.text = $"{"Puntos: " + stats.PuntosDisponibles}";
    }
    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax) {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
    public void ActualizarManaPersonaje(float pManaActual, float pManaMax) {
        manaActual = pManaActual;
        manaMax = pManaMax;
    }
    public void ActualizarExpPersonaje(float pExpActual, float pExpRequerida) {
       expActual = pExpActual;
       expRequeridaNuevoNivel = pExpRequerida; 
    }

}
