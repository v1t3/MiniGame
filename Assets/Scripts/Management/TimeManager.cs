using UnityEngine;

namespace Management
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float timeScale = 0.3f;

        private float _startFixedDeltaTime;
        private float _timeScaleBeforeStop;
        private bool _isStopped;

        private void Start()
        {
            _startFixedDeltaTime = Time.fixedDeltaTime;
        }

        private void Update()
        {
            if (_isStopped) return;

            Time.timeScale = Input.GetMouseButton(1) ? timeScale : 1f;

            Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
        }

        public void StopTime()
        {
            if (!_isStopped)
            {
                _isStopped = true;
                _timeScaleBeforeStop = Time.timeScale;
                Time.timeScale = 0;
            }
        }

        public void StartTime()
        {
            Time.timeScale = _timeScaleBeforeStop;
            _isStopped = false;
        }

        private void OnDestroy()
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = _startFixedDeltaTime;
        }
    }
}