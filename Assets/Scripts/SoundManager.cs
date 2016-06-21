using UnityEngine;
using System.Collections;

    public class SoundManager : MonoBehaviour 
	{
		public AudioSource efxSource;					
		public AudioSource musicSource;					
		public static SoundManager instance = null;						
		public float lowPitchRange = .75f;				
		public float highPitchRange = 1.05f;			
		
		
		void Awake ()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy (gameObject);
            			
			DontDestroyOnLoad (gameObject);
        AudioListener.volume = 0.15f;
		}
		
		
		public void PlaySingle(AudioClip clip)
		{
            efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.clip = clip;			
			efxSource.Play ();
		}
		
		
		public void RandomizeSfx (params AudioClip[] clips)
		{
			int randomIndex = Random.Range(0, clips.Length);			
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);			
			efxSource.pitch = randomPitch;			
			efxSource.clip = clips[randomIndex];			
			efxSource.Play();
		}
	}
