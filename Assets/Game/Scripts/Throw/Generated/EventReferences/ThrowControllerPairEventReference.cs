using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `ThrowControllerPair`. Inherits from `AtomEventReference&lt;ThrowControllerPair, ThrowControllerVariable, ThrowControllerPairEvent, ThrowControllerVariableInstancer, ThrowControllerPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ThrowControllerPairEventReference : AtomEventReference<
        ThrowControllerPair,
        ThrowControllerVariable,
        ThrowControllerPairEvent,
        ThrowControllerVariableInstancer,
        ThrowControllerPairEventInstancer>, IGetEvent 
    { }
}
