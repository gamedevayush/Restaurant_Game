using UnityEngine;

public class MouthScaler : MonoBehaviour
{
    public Transform boyMouthTransform; // Assign the mouth's transform here in the inspector
    public Transform girlMouthTransform; // Assign the mouth's transform here in the inspector
    private float[] clipSampleData = new float[1024];
    public bool isBoySpeaking;// Array size can be adjusted based on need
    public bool isGirlSpeaking;
    public float AudioData;// Array size can be adjusted based on need
    public float lerpTime = 10f;

    void Start()
    {
        if (boyMouthTransform == null|| girlMouthTransform==null)
        {
            Debug.LogError("Mouth transform is not assigned!");
            return;
        }
    }

    void Update()
    {
        if (!isBoySpeaking && !isGirlSpeaking)
            return;// Get audio data from the Audio Listener
        AudioListener.GetOutputData(clipSampleData, 0);
        float currentAverageVolume = GetCurrentAverageVolume(clipSampleData);
        AudioData = currentAverageVolume;
        // Scale the volume to a range suitable for mouth scaling
        float scale = Mathf.Lerp(-0.00696f, -0.00422f, currentAverageVolume * lerpTime);
        float scale2 = Mathf.Lerp(0.8f, 1, currentAverageVolume * lerpTime);
        if (isBoySpeaking)
        {
            boyMouthTransform.transform.localPosition= new Vector3(scale, boyMouthTransform.transform.localPosition.y, boyMouthTransform.transform.localPosition.z);
            boyMouthTransform.transform.localScale= new Vector3(1,1,scale2 );
        }
        if (isGirlSpeaking)
        {
            girlMouthTransform.transform.localPosition = new Vector3(scale, girlMouthTransform.transform.localPosition.y, girlMouthTransform.transform.localPosition.z);
        }
    }

    float GetCurrentAverageVolume(float[] data)
    {
        float total = 0;
        foreach (float datum in data)
        {
            total += Mathf.Abs(datum); // sum the absolute values to get a volume level
        }
        return total / 1024; // return the average volume
    }
}
 