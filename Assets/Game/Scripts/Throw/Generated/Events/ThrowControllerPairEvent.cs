using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `ThrowControllerPair`. Inherits from `AtomEvent&lt;ThrowControllerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ThrowControllerPair", fileName = "ThrowControllerPairEvent")]
    public sealed class ThrowControllerPairEvent : AtomEvent<ThrowControllerPair>
    {
    }
}
