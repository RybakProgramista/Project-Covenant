using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRgb;
    private bool canMove;
    public bool getCanMove() { return canMove; }
    public void setCanMove(bool canMove) { this.canMove = canMove; }   


    [SerializeField]
    private float speed;
    public void setSpeed(float speed) {  this.speed = speed; }
    public float getSpeed() { return this.speed; }
    private float _baseSpeed = 1f;
    private float _baseMultiplier = 100f;
    private Vector2 _movement;

    private void Awake()
    {
        _playerRgb = GetComponent<Rigidbody2D>();
        _movement = new Vector2(0, 0);
        speed = _baseSpeed;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            _playerRgb.linearVelocity = _movement * speed * _baseMultiplier * Time.deltaTime;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movement = inputValue.Get<Vector2>();
    }
}
