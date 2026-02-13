using UnityEngine;
using UnityEngine.Video;

namespace WallpaperChanger
{
    public class WallpaperChanger : MonoBehaviour
    {
        [Header("VideoWallpapers")]
        [SerializeField] private VideoPlayer videoWallpaperPlayer;
        [SerializeField] private VideoClip[] videoWallpapers;
        
        private int _videoWallpaperIndex = 0;

        public void ChangeWallpaper()
        {
            _videoWallpaperIndex = 
                _videoWallpaperIndex >= videoWallpapers.Length - 1 ? 
                    0 : 
                    ++_videoWallpaperIndex;
            
            videoWallpaperPlayer.clip = videoWallpapers[_videoWallpaperIndex];
            
            Debug.Log($"Changing video wallpaper {_videoWallpaperIndex}");
        }
    }
}
