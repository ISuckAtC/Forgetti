using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnchor : MonoBehaviour
{
    public float DistanceIgnore;

    public Transform StoredObject;

    public GameObject TempIgnore;
    public Transform Replace(Transform other)
    {
        Transform ret = StoredObject;
        if (ret) Destroy(ret.GetComponent<Anchored>());
        if (other) 
        {
            other.gameObject.AddComponent<Anchored>().Anchor = this;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.position = transform.position + new Vector3(0, other.GetComponentInChildren<Renderer>().bounds.extents.y, 0);
            other.rotation = Quaternion.identity;
        }
        StoredObject = other;

        return ret;
    }

    public void FixedUpdate()
    {
        if (TempIgnore && Vector3.Distance(transform.position, TempIgnore.transform.position) > DistanceIgnore) TempIgnore = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject == TempIgnore) return;
        if (StoredObject) return;
        if (other.attachedRigidbody.tag == "Pickup")
        {
            Replace(other.attachedRigidbody.transform);
            if (other.attachedRigidbody.gameObject == BasicController.Player.GetComponent<BasicController>().HeldObject)
            {
                other.attachedRigidbody.transform.parent = null;
                BasicController.Player.GetComponent<BasicController>().HeldObject = null;
                other.attachedRigidbody.useGravity = true;
                other.attachedRigidbody.angularDrag = 0.05f;
                Destroy(other.attachedRigidbody.gameObject.GetComponent<Pickup>());
            }
            other.attachedRigidbody.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
