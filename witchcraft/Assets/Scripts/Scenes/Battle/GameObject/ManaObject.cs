using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaObject : MonoBehaviour
{
    BoxCollider boxCollider;
    protected Mana manaData;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
        manaData = this.gameObject.GetComponent<Mana>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        boxCollider.size = new Vector3(0, 0, 0);
        Destroy(this.gameObject, 0.5f);
    }

    public Define.Elements.TYPE GetElementType()
    {
        return manaData.ElementType;
    }
}
