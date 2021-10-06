using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeScale = 0.3f;
    
    private float _startFixedDeltaTime;
    
    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        Time.timeScale = Input.GetMouseButton(1) ? timeScale : 1f;

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }
}
