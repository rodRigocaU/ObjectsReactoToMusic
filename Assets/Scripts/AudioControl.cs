
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public float updatePos = 0.1f;

    private float currentUpdate = 0.0f;
    private int lenght = 1024;

    public float clipSound;
    private float[] clipSam;


    public GameObject[] spectreObjects;
    public float sizeFacto = 1;

    public float minSize = 0;
    public float maxSize = 500;


    private void Awake()
    {
        clipSam = new float[lenght];

    }

    private void Update()
    {
        currentUpdate += Time.deltaTime;
        if(currentUpdate >= updatePos)
        {
            currentUpdate = 0f;
            audioSource.clip.GetData(clipSam,audioSource.timeSamples);
            clipSound = 0f;
            foreach(var sample in clipSam)
            {
                clipSound += Mathf.Abs(sample);
            }

            clipSound /= lenght;

            clipSound *= sizeFacto;
            clipSound = Mathf.Clamp(clipSound, minSize, maxSize);

            foreach(var gameOb in spectreObjects)
            {
                gameOb.transform.localScale = new Vector3(clipSound, clipSound, clipSound);
            }

        }
    }


}
