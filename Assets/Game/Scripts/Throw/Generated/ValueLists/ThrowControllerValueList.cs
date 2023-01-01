using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `ThrowController`. Inherits from `AtomValueList&lt;ThrowController, ThrowControllerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/ThrowController", fileName = "ThrowControllerValueList")]
    public sealed class ThrowControllerValueList : AtomValueList<ThrowController, ThrowControllerEvent> { }
}
