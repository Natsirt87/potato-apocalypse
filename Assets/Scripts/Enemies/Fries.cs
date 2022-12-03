using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fries : Potato
{
    public GameObject fry;
    public float movementForce = 4f;
    public float shootInterval = 1f;
    public float projectileForce = 5f;

    [Header("Rotation Controller")]
    [SerializeField] private float rotPGain = 1f;
    [SerializeField] private float rotDGain = 1f;
    [SerializeField] private float rotIGain = 1f;
    [SerializeField] private float rotIMax = 1f;
    [SerializeField] private float rotatePower = 1f;
    
    private bool _canShoot = false;
    private float _shootTimer = 0f;

    private bool _derivativeInit = false;
    private float _valueLast = 0f;
    private float _integrationStored = 0f;

    public override void Start()
    {
        base.Start();
    }

    void OnBecameVisible()
    {
        _canShoot = true;
    }

    void FixedUpdate()
    {
        RotateToPlayer();
        Vector2 vectorToPlanet = Vector2.zero - Body.position;
        Body.AddForce((vectorToPlanet / vectorToPlanet.magnitude) * movementForce, ForceMode2D.Force);
    }

    new void Update()
    {
        base.Update();
        if (_canShoot)
        {
            if (_shootTimer >= shootInterval)
            {
                _shootTimer = 0;
                ShootFry();
            }
            else
            {
                _shootTimer += Time.deltaTime;
            }
        }
    }
    
    private void ShootFry()
    {
        GameObject spawnedFry = Instantiate(fry);
        
        spawnedFry.transform.position = this.transform.position;

        Vector2 toPlayer = player.transform.position - spawnedFry.transform.position;
        spawnedFry.transform.up = toPlayer.normalized;
        
        Rigidbody2D fryRB = spawnedFry.GetComponent<Rigidbody2D>();

        fryRB.velocity = GetComponent<Rigidbody2D>().velocity;
        Vector3 force = toPlayer.normalized * projectileForce;
        fryRB.AddForce(force, ForceMode2D.Impulse);
    }

    private void RotateToPlayer()
    {
        float current = Body.rotation;
        Vector3 toPlayer = player.transform.position - Body.transform.position;
        float target = Quaternion.LookRotation(Vector3.forward, toPlayer).eulerAngles.z;
        float dt = Time.fixedDeltaTime;
        
        float error = AngleDifference(target, current);
        float p = rotPGain * error;

        float valueRateOfChange = AngleDifference(current, _valueLast);
        _valueLast = current;

        float d = 0f;
        if (_derivativeInit)
        {
            d = rotDGain * -valueRateOfChange;
        }
        else
        {
            _derivativeInit = true;
        }

        _integrationStored += (error * dt);
        _integrationStored = Mathf.Clamp(_integrationStored + (error * dt), -rotIMax, rotIMax);
        float i = rotIGain * _integrationStored;
        
        Body.AddTorque((p + i + d) * rotatePower, ForceMode2D.Force);
    }

    private float AngleDifference(float a, float b)
    {
        float diff = a - b;
        while (diff < -180) diff += 360;
        while (diff > 180) diff -= 360;
        return diff;
    }
}
