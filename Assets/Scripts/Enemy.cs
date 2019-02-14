using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA;
    [SerializeField]
    protected Transform pointB;

    public abstract void Update();

    public virtual void Attack() { }

}
