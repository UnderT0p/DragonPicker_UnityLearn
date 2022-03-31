using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDropItem
{
    public abstract void ReturnToPlatform();
    public abstract void VisibilityOn();
    public abstract void VisibilityOff();
    public abstract void PlayAnimation();
    public abstract void PlaySound(AudioClip audioClip);
    public abstract void ChangePlayerHealth();
    public abstract void ChangePlayerScore();

}
