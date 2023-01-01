using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ThrowController`. Inherits from `AtomEventReferenceListener&lt;ThrowController, ThrowControllerEvent, ThrowControllerEventReference, ThrowControllerUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ThrowController Event Reference Listener")]
    public sealed class ThrowControllerEventReferenceListener : AtomEventReferenceListener<
        ThrowController,
        ThrowControllerEvent,
        ThrowControllerEventReference,
        ThrowControllerUnityEvent>
    { }
}
