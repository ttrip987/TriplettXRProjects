using UnityEngine;

public enum FeatureUsage
{
    Once, 
    Toggle 
}

public class CoreFeatures : MonoBehaviour
{
   //Accessors - Accessing code outside of this specific class
   //This can be done with public variables, this is a more condensed approach.
   //PROPERTIES - Encapuslates filed
   //GET Accessor (READ) - returns encapsulated values
   //SET Accessor (WRITE) - allocates/assigns new values to field.
   //Note: Must use Pascal case for Property - example: PropertyName

    public bool AudioSFXSourceCreated { get; set; }

    [Header("Clip Start")]
    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }

    [Header("Clip End")]
    [field: SerializeField]
    public AudioClip AudioClipOnExit { get; set; }

    private AudioSource audioSource;

    public FeatureUsage featureUsage = FeatureUsage.Once;

    protected virtual void Awake()
    {
        MakeSFXAudioSource();
    }

    private void MakeSFXAudioSource()
    {
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        AudioSFXSourceCreated = true;
    }

    protected void PlayOnStart()
    {
        if(AudioSFXSourceCreated && AudioClipOnExit != null)
        {
            audioSource.clip = AudioClipOnStart;
            audioSource.Play();

        }
    }


    protected void PlayOnEnd()
    {
        if(AudioSFXSourceCreated && AudioClipOnExit != null)
        {
            audioSource.clip = AudioClipOnExit;
            audioSource.Play();
        }
    }





}
