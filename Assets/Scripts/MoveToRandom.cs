using UnityEngine;

public class MoveToRandom : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _step;
    private float _progress;

    void Start()
    {
        _startPosition = transform.position;
        _endPosition = transform.position;
        _step = 0.001f;
        _progress = 1f;    
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _progress);
        _progress += _step;

        if (_progress >= 1f)
        {
            _startPosition = _endPosition;
            _endPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            _step = Random.Range(0.001f, 0.005f);
            _progress = 0f;
        }
    }
}
