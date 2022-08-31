using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration = 3f;

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] float _movementSpeed = 1;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        // Calculate rotation
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }


    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Feedback();
            StartCoroutine(PowerUpDuration(player));
        }
    }

    IEnumerator PowerUpDuration(Player player)
    {
        PowerUp(player);
        Debug.Log("Started.");

        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(_powerUpDuration);

        PowerDown(player);
        Debug.Log("Finished.");
        Destroy(this.gameObject);
    }

    private void Feedback()
    {
        // Particles
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }

        // #AUDIO TODO: Consider "Object Pooling" for performance
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}
