using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DireccionMovimineto {Horizontal,Vertical }
public class WaypointMovimineto : MonoBehaviour {
    [SerializeField] protected float velocidad;
    public Vector3 PuntoPorMoverse => _waypoint.ObtenerPosicionMovimineto(puntoActualIndex);

    protected Waypoint _waypoint;
    protected int puntoActualIndex;
    protected Vector3 ultimaPosicion;
    protected Animator _animator; 

    private void Start() {
        _waypoint = GetComponent<Waypoint>();
        _animator = GetComponent<Animator>();
        puntoActualIndex = 0; 
    }
    private void Update() {
        MoverPersonaje();
        RotarPersonaje();
        RotarVertical();
        if (ComprobarPuntoActualAlcanzado()) { 
            ActualizarIndexMovimiento();
        }
    }
    private void MoverPersonaje() {
        transform.position = Vector3.MoveTowards(transform.position, PuntoPorMoverse, velocidad * Time.deltaTime);
    }
    private bool ComprobarPuntoActualAlcanzado() {
        float distanciaHaciaPuntoActual = (transform.position - PuntoPorMoverse).magnitude;
        if (distanciaHaciaPuntoActual < 0.1f) { 
            ultimaPosicion = transform.position;
            return true;
        } 
        return false;
    }

    private void ActualizarIndexMovimiento() {
        if (puntoActualIndex == _waypoint.Puntos.Length -1) {
            puntoActualIndex = 0;
        }
        else {
            if (puntoActualIndex < _waypoint.Puntos.Length) {
                puntoActualIndex++;
            }
        }
    }

    protected virtual void RotarPersonaje() {}
    protected virtual void RotarVertical() { }
}
