
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public float updatePos = 0.1f;

    private float currentUpdate = 0.0f;
    private int lenght = 1024;

    public float clipSound;
    public float clipSoundForWheels;
    private float[] clipSam;


    public GameObject[] spectreObjects;
    public float sizeFacto = 1;
    public float wheelFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;

    public GameObject[] wheelsObjects;


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
                clipSoundForWheels += Mathf.Abs(sample);
            }

            clipSound /= lenght;

            clipSound *= sizeFacto;
            clipSound = Mathf.Clamp(clipSound, minSize, maxSize);

            clipSoundForWheels /= lenght;
            clipSoundForWheels *= wheelFactor;
            clipSoundForWheels = Mathf.Clamp(clipSoundForWheels, 1f, maxSize);

            foreach (var gameOb in spectreObjects)
            {
                gameOb.transform.localScale = new Vector3(clipSound, clipSound, clipSound);
            }

            foreach (var gameOb in wheelsObjects)
            {
                gameOb.transform.localScale = new Vector3(clipSoundForWheels, clipSoundForWheels, clipSoundForWheels);
            }


        }
    }


}
