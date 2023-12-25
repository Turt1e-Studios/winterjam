using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem boostEffect;
    [SerializeField] private TextMeshProUGUI boostText;
    [SerializeField] private float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    [SerializeField] private float lookRateSpeed = 90f;
    [SerializeField] private float rollSpeed = 90f, rollAcceleration = 3.5f;
    [SerializeField] private float boostMultiplier = 50f;
    [SerializeField] private float boostDuration = 3f;
    private Transform _transform;
    private Vector3 _position;
    private Vector2 _lookInput, _screenCenter, _mouseDistance;
    private float _forwardAcceleration = 2.5f, _strafeAcceleration = 2f, _hoverAcceleration = 2f;
    private float _activeForwardSpeed, _activeStrafeSpeed, _activeHoverSpeed;
    private float _rollInput;
    private int _boostCount;

    // Start is called before the first frame update
    void Start()
    {
        // Keep cursor in center
        Cursor.lockState = CursorLockMode.Confined;
        
        // Local variables for more efficient lookup
        _transform = transform;
        _position = _transform.position;

        // Set location of screen center
        _screenCenter.x = Screen.width * 0.5f;
        _screenCenter.y = Screen.height * 0.5f;

        // Replace later
        _boostCount = 3;
        UpdateBoostText();
    }

    // Change cursor mode for straight flying
    void ChangeCursorMode()
    {
        // Player has to click on the screen at least once for this to work
        Debug.Log("Cursor mode change");
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    void UpdateBoostText()
    {
        boostText.text = "Boosts: " + _boostCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        _lookInput.x = Input.mousePosition.x;
        _lookInput.y = Input.mousePosition.y;
        
        // Rotate player
        _mouseDistance.x = (_lookInput.x - _screenCenter.x) / _screenCenter.y;
        _mouseDistance.y = (_lookInput.y - _screenCenter.y) / _screenCenter.y;
        _mouseDistance = Vector2.ClampMagnitude(_mouseDistance, 1f);
        _rollInput = Mathf.Lerp(_rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        transform.Rotate(-_mouseDistance.y * lookRateSpeed * Time.deltaTime, _mouseDistance.x * lookRateSpeed * Time.deltaTime, _rollInput * rollSpeed * Time.deltaTime, Space.Self);

        // Get player input
        _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, _forwardAcceleration * Time.deltaTime);
        _activeStrafeSpeed = Mathf.Lerp(_activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, _strafeAcceleration * Time.deltaTime);
        _activeHoverSpeed = Mathf.Lerp(_activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, _hoverAcceleration * Time.deltaTime);
        
        // Boost
        if (Input.GetKeyDown(KeyCode.LeftShift) && _boostCount > 0)
        {
            _boostCount--;
            boostEffect.Play();
            StartCoroutine(Boost());
            UpdateBoostText();
        }
        
        // Change position of player
        _position += _transform.forward * (_activeForwardSpeed * Time.deltaTime);
        _position += _transform.right * (_activeStrafeSpeed * Time.deltaTime);
        _position += _transform.up * (_activeHoverSpeed * Time.deltaTime);
        _transform.position = _position;

        // Change cursor mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCursorMode();
        }
    }

    IEnumerator Boost()
    {
        forwardSpeed *= boostMultiplier;
        strafeSpeed *= boostMultiplier;
        hoverSpeed *= boostMultiplier;
        yield return new WaitForSeconds(boostDuration);
        forwardSpeed /= boostMultiplier;
        strafeSpeed /= boostMultiplier;
        hoverSpeed /= boostMultiplier;
    }
}
