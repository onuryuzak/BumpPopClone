using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `ThrowController`. Inherits from `AtomEvent&lt;ThrowController&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ThrowController", fileName = "ThrowControllerEvent")]
    public sealed class ThrowControllerEvent : AtomEvent<ThrowController>
    {
    }
}
