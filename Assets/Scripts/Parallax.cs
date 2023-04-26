using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;
    private bool isPlayerDead = false;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (!isPlayerDead) // Si el jugador no está muerto, el Parallax sigue moviéndose
        {
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
            if (transform.localPosition.x < -20)
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    public void StopMovement() // Método para detener el movimiento del Parallax
    {
        isPlayerDead = true;
    }



    void DestroyEnemies()
    {
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(Enemy);
        }
    }
}

