using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    public abstract void Move();
    public abstract void RandomChoiceItem();
    public abstract void TeleportItemToDragon(GameObject dragonEgg);
}
