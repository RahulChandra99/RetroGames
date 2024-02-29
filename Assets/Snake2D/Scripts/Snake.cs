using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    [SerializeField] private float gameDifficultyValue = 0.02f;

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
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);
    }
}
