using UnityEngine;
using TMPro;

public class HintsVisabilityManager : MonoBehaviour
{
    [SerializeField] private GameObject[] notes;
    [SerializeField] private Animator anim;
    
    private TMP_Text[] _text;
    private bool _isActive = true;

    private void OnValidate()
    {
        _text = new TMP_Text[notes.Length];

        /* getting the hints of the notes */
        for (int i = 0; i < notes.Length; i++)
            _text[i] = notes[i].GetComponentInChildren<TMP_Text>();

        /* getting the animator */
        if (anim is null) anim = GetComponent<Animator>();
    }

    public void StateChange()
    {
        _isActive = !_isActive;

        /* changing the hints visability */
        foreach (TMP_Text text in _text)
            text.enabled = _isActive;

        /* eye animation */
        anim.Play(_isActive ? "Open" : "Close");
    }
}
