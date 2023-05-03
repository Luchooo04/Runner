using UnityEngine;

public class Controller_JetPack : MonoBehaviour
{
    public ParticleSystem particles;
    public KeyCode activationKey;

    private bool isActivated = false;

    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            particles.Play();
            isActivated = true;
        }
        else if (Input.GetKeyUp(activationKey))
        {
            particles.Stop();
            isActivated = false;
        }
        else if (isActivated && !particles.isPlaying)
        {
            particles.Play();
        }
    }
}