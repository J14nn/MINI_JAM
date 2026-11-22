using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class PlayerRagdoll : MonoBehaviour
{
    [SerializeField] private Rig rig;
    [SerializeField] private List<TwoBoneIKConstraint> IKs;

    private RagdollComponent[] ragdolls;

    private void Start()
    {
        ragdolls = GetComponentsInChildren<RagdollComponent>();

        DisableRagdoll();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            EnableRagdoll();
            Globals.hasWon = true;
        }
    }

    private void DisableRagdoll()
    {
        foreach (RagdollComponent r in ragdolls)
        {
            r.DisableRagdoll();
        }
    }

    public void EnableRagdoll()
    {
        rig.weight = 0f;

        foreach (RagdollComponent r in ragdolls)
        {
            r.EnableRagdoll();
        }

        foreach (TwoBoneIKConstraint ik in IKs)
        {
            ik.enabled = false;
        }
    }
}