using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectPool
{
    private ParticleSystem _particlePrefab;
    private Queue<ParticleSystem> _pool;

    public ParticleEffectPool(ParticleEffect effectConfig)
    {
        _particlePrefab = effectConfig.particlePrefab;
        _pool = new Queue<ParticleSystem>();

        for (int i = 0; i < effectConfig.initialPoolSize; i++)
        {
            ParticleSystem newParticle = GameObject.Instantiate(_particlePrefab);
            newParticle.gameObject.SetActive(false);
            _pool.Enqueue(newParticle);
        }
    }

    public ParticleSystem Get()
    {
        if (_pool.Count == 0)
        {
            ParticleSystem newParticle = GameObject.Instantiate(_particlePrefab);
            newParticle.gameObject.SetActive(false);
            _pool.Enqueue(newParticle);
        }

        return _pool.Dequeue();
    }

    public void ReturnToPool(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        _pool.Enqueue(particle);
    }
}
