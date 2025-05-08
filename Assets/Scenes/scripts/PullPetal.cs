using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;


[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]

public class BreakApartOnActivate : MonoBehaviour
{
	[Header("Tuning")]
	[SerializeField] float explosionForce = 3f;
    [SerializeField] float explosionRadius = 0.5f;

    public Component[] petals;

    UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    //void Awake() => grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

    //void OnEnable() => grab.activated += OnActivate;
    //void OnDisable() => grab.activated -= OnActivate;

    void Update() // trigger pulled
    {
        petals = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in petals)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.transform.parent = null;
                rb.AddExplosionForce(explosionForce,
                                     grab.transform.position,
                                     explosionRadius,
                                     0.1f);
            }
        }
    }


    //void OnActivate(ActivateEventArgs _) // trigger pulled
	//{
	//	petals = GetComponentsInChildren<Rigidbody>();

    //    foreach (Rigidbody rb in petals)
	//	{
			//if (rb == grab.attachedRigidbody) continue;
	//		rb.isKinematic = false;
	//		rb.useGravity = true;
	//		rb.transform.parent = null;
	//		rb.AddExplosionForce(explosionForce,
	//							 grab.transform.position,
	//							 explosionRadius,
	//							 0.1f);
	//	}
	//}
}
