using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IMarcadorEventHandler : IEventSystemHandler
{
    void ActualizarPuntos(string nombreCoche, int puntos);
}

public class ControlMarcador : MonoBehaviour, IMarcadorEventHandler
{
    public void ActualizarPuntos(string nombreCoche, int puntos)
    {
        GetComponent<Text>().text = nombreCoche +  ": " +puntos;   
    }
}
