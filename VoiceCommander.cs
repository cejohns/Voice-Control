using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

using System.Linq;
using UnityEngine.UI;

public class VoiceCommander : MonoBehaviour {

    public string[] keywords = new string[] { "Turn on", "turn off", "Check Fridge", "Check Oven" ,"'Check Freezer" , "Leave Room" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public int OvenTemp; public int FrigdeTemp; public int FreezerTemp;
    //public float speed = 1;
    public Light OverheadLight;
    //public GameObject Counterlights;
   public Text results;
    //public Image target;
    public AudioClip command; public bool _useMic; public AudioSource Lexi;
    protected PhraseRecognizer recognizer;
    protected string word = "turn off";

    private void Start()
    {
        
        if (_useMic)
        {
            if (Microphone.devices.Length > 0)
            {Lexi.clip = Microphone.Start(null, true, 5, AudioSettings.outputSampleRate); }
            else
                { _useMic = false; }
            
        }
        if(!_useMic) { Lexi.clip = command; }

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        //var x = target.transform.position.x;
        //var y = target.transform.position.y;

        switch (word)
        {
            case "Turn on":
                results.text = "lgiht on! "; Debug.Log("light on!");
                OverheadLight.enabled = true;
                break;
            case "turn off":
                results.text = " lights off!"; Debug.Log("light off!");
                OverheadLight.enabled = false;
                break;
            case "Check Fridge":
                results.text = " Tempe" + FrigdeTemp; Debug.Log(" Temp:  " + FrigdeTemp);
                break;
            case "check Oven":
                results.text = " Temp is" + OvenTemp; Debug.Log(" Temp:  " + OvenTemp);
                break;
            case "Check Freezer":
                results.text = " temp is" + FreezerTemp; Debug.Log(" temp:  " + FreezerTemp);
                break;
            case "Leave Room":
                Application.Quit();
                break;
        }

        //target.transform.position = new Vector3(x, y, 0);
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
