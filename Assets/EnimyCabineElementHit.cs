using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyCabineElementHit : DamageableComponent
{
    public override void DestroyElement(float delay)
    {
        transform.parent.GetComponent<EnimyComponentCabine>().DestroyElement();
    }
}
