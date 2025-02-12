using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField] private Vector3[] puntos;
    [SerializeField] private float radiusSphereGizmos;
    [SerializeField] private float lineThickness = 3f;

    public Vector3 PosicionActual { get; set; }
    private bool juegoIniciado; 

    private void Start() {
        juegoIniciado = true;
        PosicionActual = transform.position;
    }
    public int MyProperty { get; set; }
    private void OnDrawGizmos() {
        if (juegoIniciado == false && transform.hasChanged) {
            PosicionActual = transform.position; 
        }
        if (puntos == null || puntos.Length <= 0) {
            return;
        }
        for (int i = 0; i < puntos.Length; i++) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(puntos[i] + PosicionActual, radiusSphereGizmos);
            if (i < puntos.Length - 1) {
                Gizmos.color = Color.red;
                Handles.color = Color.red;
                Handles.DrawAAPolyLine(lineThickness, puntos[i] + PosicionActual, puntos[i + 1] + PosicionActual);
                //Gizmos.DrawLine(puntos[i] + PosicionActual, puntos[i + 1] + PosicionActual);
            }
        }
    }
}
