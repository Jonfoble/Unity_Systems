using UnityEngine;

[CreateAssetMenu(menuName = "Particle Effect Config")]
public class ParticleEffect : ScriptableObject
{
    public string effectName; // Unique identifier for each effect
    public ParticleSystem particlePrefab; // Prefab of the particle system
    public int initialPoolSize = 5; // Initial size of the pool for this effect
}
