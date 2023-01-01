using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `ThrowController`. Inherits from `AtomEventReference&lt;ThrowController, ThrowControllerVariable, ThrowControllerEvent, ThrowControllerVariableInstancer, ThrowControllerEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ThrowControllerEventReference : AtomEventReference<
        ThrowController,
        ThrowControllerVariable,
        ThrowControllerEvent,
        ThrowControllerVariableInstancer,
        ThrowControllerEventInstancer>, IGetEvent 
    { }
}
