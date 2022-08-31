using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Backing field
    [SerializeField] int _maxHealth = 3;
    // Property; can be retrieved, but not set
    public int MaxHealth
    {
        get { return _maxHealth; }
        private set
        {
            // Value represents new value to set
            // -> Makes sure new value is not above max
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            // Assign newly adjusted value
            _currentHealth = value;
        }
    }
    int _currentHealth;

    [SerializeField] bool _invincible = false;
    public bool Invincible
    {
        get => _invincible;
        set => _invincible = value;
    } 

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        // Fill current health at start
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); // Ensure player health stays in specified range
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHeath(int amount)
    {
        if (_invincible == false)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);

            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        // Play particles
        // Play sounds
    }
}
