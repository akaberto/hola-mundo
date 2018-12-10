using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface ICarEventHandler : IEventSystemHandler
{
    void FinalizarPartida();
}

public class car : MonoBehaviour, ICarEventHandler
{
    float velocidad = 100f;
    public KeyCode teclaAsignada = KeyCode.F1;
    int cuenta = 0;
    bool estaParado = false;
    public GameObject otroCoche;
    public GameObject miMarcador;

    void Update()
    {
        if (!estaParado) {
            if (cuenta >= 26)
            {
                estaParado = true;
                ExecuteEvents.Execute<ICarEventHandler>(otroCoche, null, (x, y) => x.FinalizarPartida());
            }
            else
            {
                if (Input.GetKeyDown(teclaAsignada))
                {
                    this.transform.Translate(new Vector3(0, velocidad, 0));
                    cuenta++;
                    ExecuteEvents.Execute<IMarcadorEventHandler>(miMarcador, null, (x, y) => x.ActualizarPuntos(this.name, cuenta));
                }
 
            }
        }

    }

    public void FinalizarPartida()
    {
        estaParado = true;
    }
}
