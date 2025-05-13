using System;
using UnityEngine;
using UnityEngine.Video;

namespace FinisOmnibus.Core
{
    public class LogoLoaderService : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _player;
        [SerializeField] private VideoClip[] _clips;

        public event Action OnAllVideosFinished;
        private int _currentClipIndex = 0;

        public void RunStartLogo()
        {
            if (_clips == null || _clips.Length == 0)
                return;

            _player.loopPointReached += OnVideoFinished;
            PlayClip(_currentClipIndex);
        }

        private void PlayClip(int index)
        {
            if (index >= 0 && index < _clips.Length)
            {
                _player.clip = _clips[index];
                _player.Play();
            }
        }

        private void OnVideoFinished(VideoPlayer vp)
        {
            _currentClipIndex++;

            if (_currentClipIndex < _clips.Length)
            {
                PlayClip(_currentClipIndex);
            }
            else
            {
                _player.loopPointReached -= OnVideoFinished;
                OnAllVideosFinished?.Invoke();
            }
        }
    }
}