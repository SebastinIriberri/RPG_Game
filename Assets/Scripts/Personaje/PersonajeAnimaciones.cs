using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour {
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private PersonajeMovimineto _personajeMovimineto;

    private readonly int direccionX = Animator.StringToHash("X");
    private readonly int direccionY = Animator.StringToHash("Y");
    private readonly int derrotado = Animator.StringToHash("Derrotado");

    private void Awake() {
        _animator = GetComponent<Animator>();
        _personajeMovimineto = GetComponent<PersonajeMovimineto>();
    }

    private void Update() {
        ActualizarLayers();
        if (_personajeMovimineto.EnMovimiento == false) {
            return;
        }
        _animator.SetFloat(direccionX,_personajeMovimineto.DireccionMovimineto.x);
        _animator.SetFloat(direccionY, _personajeMovimineto.DireccionMovimineto.y);
    }

    private void ActivarLayer(string nombreDeLayer) {
        int layerIndex = _animator.GetLayerIndex(nombreDeLayer);
        if (layerIndex == -1) {
            Debug.LogWarning($"El nombre de la capa '{nombreDeLayer}' no se encuentra en el Animator Controller.");
            return;
        }
        for (int i = 0; i < _animator.layerCount;i++) {
            _animator.SetLayerWeight(i,weight:0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(layerName:nombreDeLayer),weight:1);
    }

    private void ActualizarLayers() {
        if (_personajeMovimineto.EnMovimiento) {
            ActivarLayer(layerCaminar);
        }else {
            ActivarLayer(layerIdle);
        }
    }

    public void RevivirPersonaje() {
        ActivarLayer(layerIdle);
        _animator.SetBool(derrotado,false);
    }

    private void PersonajeDerrotadoRespuesta() {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle))==1) {
            _animator.SetBool(derrotado,true);
        }
    }

    private void OnEnable() {
        PersonajeVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }

    private void OnDisable() {
        PersonajeVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;
    }  
}
