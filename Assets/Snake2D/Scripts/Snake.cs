using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    [SerializeField] private float gameDifficultyValue = 0.02f;
    private List<Transform> _segments;
    [SerializeField] private Transform _segmentPrefab;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            _direction = Vector2.up;
        else if(Input.GetKeyDown(KeyCode.S))
            _direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.D))
            _direction = Vector2.right;
        else if ((Input.GetKeyDown(KeyCode.A)))
            _direction = Vector2.left;

    }

    private void FixedUpdate()
    {
        Time.fixedDeltaTime = gameDifficultyValue;

        for(int i = _segments.Count - 1; i > 0; i--) 
        {
            _segments[i].position = _segments[i-1].transform.position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);
    }

    void Grow()
    {
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
            Grow();
    }
}
