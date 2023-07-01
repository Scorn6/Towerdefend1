using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerDate
{
    public GameObject TowerPrefab;
    public int cost;
    public int costPro;
    public int costProMax;
    public int costjineng1;
    public int costjineng2;
    public TowerType type;
}
public enum TowerType
{
    Tower1,
    Tower2,
    Tower3,
    Tower4,
    Tower5
}
