using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


[RequireComponent(typeof(XRGrabInteractable))]

public class BreakApartOnActivate : MonoBehaviour
{
	//[Header("Tuning")]
	
    [SerializeField] float explosionForce = 3f;
    [SerializeField] float explosionRadius = 0.5f;

    //Creating Interactables and Interactor
    public XRGrabInteractable flower;
    public XRBaseInteractable interactor;
    public Component[] petals;
    private int petalCounter;
    public InputActionReference pullPetalAction;

    private void Awake()
    {
        flower = GetComponent<XRGrabInteractable>();
        petals = flower.GetComponentsInChildren<Rigidbody>();
        petalCounter = 1;
        pullPetalAction.action.Enable();
        pullPetalAction.action.performed += OnActivate;
    }

    private void OnDestroy()
    {
        pullPetalAction.action.Disable();
        pullPetalAction.action.performed -= OnActivate;
    }


    private void OnActivate(InputAction.CallbackContext context) // trigger pulled
    {
        Rigidbody rb = (Rigidbody)petals[petalCounter];
        //for (int i = 0; i < petals.Length; i++)
        //{
            //Rigidbody rb = (Rigidbody)petals[i];
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.transform.parent = null;
        rb.AddExplosionForce(explosionForce,
                                flower.transform.position,
                                explosionRadius,
                                0.1f);
        petalCounter++;
        //Debug.Log(interactor.selectEntered.ToString());
        //}
    }
}