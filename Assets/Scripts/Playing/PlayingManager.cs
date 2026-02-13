using System;
using UnityEngine;
using UnityEngine.UI;

namespace Playing
{
    public class PlayingManager : MonoBehaviour
    {
        private const int NotesCount = 36;
            
        [System.Serializable]
        private class SoundInstrument
        {
            public ModeChanger.Mods mode;
            public AudioClip[] notes = new AudioClip[NotesCount];
        }
        
        [Header("Instruments")]
        [SerializeField] private SoundInstrument[] instruments;
        [SerializeField] private AudioSource[] sources;
        [SerializeField] private Button[] buttons;

        public ModeChanger.Mods CurrentMode
        {
            set
            {
                for (var i = 0; i < NotesCount; ++i)
                    sources[i].clip = instruments[(int)value].notes[i];
            }
        }

        [Header("Keys")] [SerializeField] private KeyCode[] keyMapping = new KeyCode[]
        {
            KeyCode.Z,
            KeyCode.X,
            KeyCode.C,
            KeyCode.V,
            KeyCode.B,
            KeyCode.N,
            KeyCode.M,
            KeyCode.S,
            KeyCode.D,
            KeyCode.G,
            KeyCode.H,
            KeyCode.J,
            KeyCode.Comma,
            KeyCode.Period,
            KeyCode.Slash,
            KeyCode.Q,
            KeyCode.W,
            KeyCode.E,
            KeyCode.R,
            KeyCode.L,
            KeyCode.Semicolon,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.T,
            KeyCode.Y,
            KeyCode.U,
            KeyCode.I,
            KeyCode.O,
            KeyCode.P,
            KeyCode.LeftBracket,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha9,
            KeyCode.Alpha0,
            KeyCode.Minus
        };

        private void Update()
        {
            for (var i = 0; i < keyMapping.Length; i++)
            {
                if (Input.GetKeyDown(keyMapping[i]))
                    ButtonClickSimulation(i);
            }
        }

        public void PlayNote(int noteIndex) =>
            sources[noteIndex].Play();

        private void ButtonClickSimulation(int noteIndex)
        {
            buttons[noteIndex].onClick.Invoke();
        }
    }
}
