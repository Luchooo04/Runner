using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;
    private int Puntos;
    public Text HighScoreTxt;
    int HighScore;


    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
        HighScoreTxt.gameObject.SetActive(false);

        Puntos = 0;

    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + ((int)distance).ToString() + "km";
            gameOverText.gameObject.SetActive(true);
            HighScoreTxt.text = "H I G H S C O R E : " + Puntos + " Pts";
            HighScoreTxt.gameObject.SetActive(true);

            UltimoPuntajeAlto();
        }
        else
        {
            PuntosAumentan();
            distance += Time.deltaTime;
            distanceText.text = ((int)distance).ToString();
        }
    }

    private void UltimoPuntajeAlto()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);



    }
    private void GuardarPuntuacionMaxima(int puntajeMaximo)
    {
        PlayerPrefs.SetInt("HighScore", puntajeMaximo);


    }
    public void EstablecerPuntuacionMasAltaSiEsMayor()
    {
        if (Puntos > HighScore)
        {
            HighScore = Puntos;
            GuardarPuntuacionMaxima(HighScore);


        }


    }
    void PuntosAumentan()
    {
        if (distance >= 0)
        {
            Puntos++;


        }
    }
}
