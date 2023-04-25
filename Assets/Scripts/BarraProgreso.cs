using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public int vidaBarra;
    public Slider barraProgreso;
   
    void Update()
    {
        barraProgreso.GetComponent<Slider>().value = vidaBarra - Time.time;

    }
}
