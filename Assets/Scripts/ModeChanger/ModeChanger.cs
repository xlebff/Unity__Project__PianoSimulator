using System;
using Playing;
using UnityEngine;

namespace ModeChanger
{
    public enum Mods
    {
        Piano,
        Cat,
        Pig
    };

    public class ModeChanger : MonoBehaviour
    {
        [SerializeField] private Mods currentMode = Mods.Piano;
        [SerializeField] private PlayingManager playingManager;
        
        public Mods CurrentMode 
        {
            get => currentMode;
            set
            {
                currentMode = value;
                playingManager.CurrentMode = value;
            }
        }

    private int _modeIndex = 0, _modsCount;

        private void OnValidate() =>
            _modsCount = Enum.GetNames(typeof(Mods)).Length;

        public void ChangeMode()
        {
            _modeIndex = 
                _modeIndex >= _modsCount - 1 ? 
                    0 : 
                    ++_modeIndex;
            
            CurrentMode = (Mods)_modeIndex;
            
            Debug.Log($"Changing mode {_modeIndex}");
        }
    }
}