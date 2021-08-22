using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private GameRunner gameRunner;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private float rotateValue;

    [SerializeField] private float minDot = -.5f;
    [SerializeField] private float rotateSpeed = 360f;
    [SerializeField] private PlayerControl control;
    
    void Start()
    {
        gameRunner = GameObject.Find("GameRunner").GetComponent<GameRunner>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        
        rotateValue = control == null ? 0f : control.SteerAmount;
        transform.Rotate(_transform.up, rotateSpeed * rotateValue * Time.fixedDeltaTime);
        var dot = Vector3.Dot(gameRunner.WindDirection, _transform.forward);
        var speed = Mathf.Clamp01((dot + minDot) / 1f + minDot);
        _rigidbody.velocity = _transform.forward * (gameRunner.WindDirection.magnitude * speed);
    }

    public void SetControl(PlayerControl newControl)
    {
        control = newControl;
    }

    private void OnDrawGizmos()
    {
        if(gameRunner == null) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(_transform.position, gameRunner.WindDirection * 30f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position, _rigidbody.velocity * 30f);
    }
}
