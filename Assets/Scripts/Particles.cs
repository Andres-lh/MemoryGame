using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] GameObject _ParticlesSystem;
    [SerializeField] float lifeTime;

    public void GenerateParticles(Transform transform)
    {
        if (_ParticlesSystem == null)
        {
            return;
        }
        GameObject particleSystem = Instantiate(_ParticlesSystem, transform.position, _ParticlesSystem.transform.rotation);
        particleSystem.transform.SetParent(this.gameObject.transform);
        Destroy(particleSystem, lifeTime);  
    }

}
