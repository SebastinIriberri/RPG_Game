using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimineto : MonoBehaviour {

    [SerializeField] private float _velocidad;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direcionMovimiento;
    public Vector2 DireccionMovimineto => _direcionMovimiento;
    public bool EnMovimiento => _direcionMovimiento.magnitude > 0f;
    private Vector2 _input;
    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        PlayerMove();
        
    }
    private void FixedUpdate() {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direcionMovimiento * _velocidad * Time.fixedDeltaTime);
    }

    private void PlayerMove() {
        _input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
        //X
        if (_input.x > 0.1f) {
            _direcionMovimiento.x = 1f;
        }
        else if (_input.x < 0f) {
            _direcionMovimiento.x = -1f;
        }
        else {
            _direcionMovimiento.x = 0f;
        }
        //Y
        if (_input.y > 0.1f) {
            _direcionMovimiento.y = 1f;
        }
        else if (_input.y < 0f) {
            _direcionMovimiento.y = -1f;
        }
        else {
            _direcionMovimiento.y = 0f;
        }
    }
}

