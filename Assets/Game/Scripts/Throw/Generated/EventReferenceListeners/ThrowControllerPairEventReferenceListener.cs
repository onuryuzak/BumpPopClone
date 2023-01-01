using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ThrowControllerPair`. Inherits from `AtomEventReferenceListener&lt;ThrowControllerPair, ThrowControllerPairEvent, ThrowControllerPairEventReference, ThrowControllerPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ThrowControllerPair Event Reference Listener")]
    public sealed class ThrowControllerPairEventReferenceListener : AtomEventReferenceListener<
        ThrowControllerPair,
        ThrowControllerPairEvent,
        ThrowControllerPairEventReference,
        ThrowControllerPairUnityEvent>
    { }
}
