using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;


    private void Awake() 
    {
        material = GetComponent<SpriteRenderer>().material;
    
    }
  
    void Update()
    {
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }


}
