using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private AudioSource _musicSource;
    public void OnScrollBarValueChange()
    {
        _musicSource.volume = _scrollBar.value;
    }
}
