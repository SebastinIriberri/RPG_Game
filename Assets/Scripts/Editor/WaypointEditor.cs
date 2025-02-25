using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor {
    Waypoint waypointTarget => target as Waypoint;
    private void OnSceneGUI() {
        Handles.color = Color.red;
        if (waypointTarget.Puntos == null) { 
            return;
        }
        for (int i = 0; i < waypointTarget.Puntos.Length; i++) { 
            //Crear el handle
            EditorGUI.BeginChangeCheck();
            Vector3 puntoActual = waypointTarget.PosicionActual + waypointTarget.Puntos[i];
            Vector3 nuevoPunto = Handles.FreeMoveHandle(puntoActual,Quaternion.identity,0.7f, new Vector3(0.3f,0.3f,0.3f),Handles.SphereHandleCap);
            //Crear texto 
            GUIStyle texto = new GUIStyle(); 
            texto.fontStyle = FontStyle.Bold;
            texto.fontSize = 16;
            texto.normal.textColor = Color.black;
            Vector3 alinamiento = Vector3.down * 0.3f + Vector3.right * 0.3f;
            Handles.Label(waypointTarget.PosicionActual + waypointTarget.Puntos[i] + alinamiento, $"{i+1}",texto);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target,"Free Move Handle");
                waypointTarget.Puntos[i] = nuevoPunto - waypointTarget.PosicionActual;  
            }

        }
    }

}
