using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public static ParticleEffectManager Instance { get; private set; }

    [SerializeField] private List<ParticleEffect> _particleEffectConfigs;
    private Dictionary<string, ParticleEffectPool> _particlePools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializePools();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializePools()
    {
        _particlePools = new Dictionary<string, ParticleEffectPool>();

        foreach (var effectConfig in _particleEffectConfigs)
        {
            ParticleEffectPool pool = new ParticleEffectPool(effectConfig);
            _particlePools[effectConfig.effectName] = pool;
        }
    }

    public static void PlayEffect(string effectName, Vector3 position)
    {
        if (Instance._particlePools.ContainsKey(effectName))
        {
            ParticleSystem particle = Instance._particlePools[effectName].Get();
            particle.transform.position = position;
            particle.gameObject.SetActive(true);
            particle.Play();
        }
        else
        {
            Debug.LogWarning("Effect not found: " + effectName);
        }
    }

    public static void StopEffect(string effectName, ParticleSystem particle)
    {
        if (Instance._particlePools.ContainsKey(effectName))
        {
            particle.Stop();
            Instance._particlePools[effectName].ReturnToPool(particle);
        }
        else
        {
            Debug.LogWarning("Effect not found: " + effectName);
        }
    }
}
