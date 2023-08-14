using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning("Animator component not found on the object.");
        }
    }

    /// <summary>
    /// Play an animation by name.
    /// </summary>
    /// <param name="animationName">Name of the animation clip.</param>
    public void PlayAnimation(string animationName)
    {
        if (_animator != null)
        {
            _animator.Play(animationName);
        }
    }

    /// <summary>
    /// Pause the currently playing animation.
    /// </summary>
    public void PauseAnimation()
    {
        if (_animator != null)
        {
            _animator.speed = 0f;
        }
    }

    /// <summary>
    /// Resume the paused animation.
    /// </summary>
    public void ResumeAnimation()
    {
        if (_animator != null)
        {
            _animator.speed = 1f;
        }
    }

    /// <summary>
    /// Stop the currently playing animation.
    /// </summary>
    public void StopAnimation()
    {
        if (_animator != null)
        {
            _animator.StopPlayback();
        }
    }

    /// <summary>
    /// Set a boolean parameter in the animator.
    /// </summary>
    public void SetBool(string paramName, bool value)
    {
        if (_animator != null)
        {
            _animator.SetBool(paramName, value);
        }
    }

    /// <summary>
    /// Set a float parameter in the animator.
    /// </summary>
    public void SetFloat(string paramName, float value)
    {
        if (_animator != null)
        {
            _animator.SetFloat(paramName, value);
        }
    }
}
