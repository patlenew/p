using UnityEngine;
using System.Collections;

public class EnemyClass {

    public int hpBasic;
    public float reloadTime;
    public string weaponType;
    public bool isMelee;

    public EnemyClass()
    {
        hpBasic = 2;
        reloadTime = 2;
        weaponType = "Gun";
        isMelee = false;
    }
	
}

public class BasicEnemy: EnemyClass
{
    
    public BasicEnemy()
    {
        hpBasic = 2;
        reloadTime = 2;
        weaponType = "Gun";
        isMelee = false;
    }
}

public class MeleeEnemy: EnemyClass
{
    public MeleeEnemy()
    {
        hpBasic = 4;
        reloadTime = 0;
        weaponType = "Stick";
        isMelee = true;
    }
}
