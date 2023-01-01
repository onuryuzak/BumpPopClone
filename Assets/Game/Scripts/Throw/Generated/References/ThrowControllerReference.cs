using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `ThrowController`. Inherits from `AtomReference&lt;ThrowController, ThrowControllerPair, ThrowControllerConstant, ThrowControllerVariable, ThrowControllerEvent, ThrowControllerPairEvent, ThrowControllerThrowControllerFunction, ThrowControllerVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ThrowControllerReference : AtomReference<
        ThrowController,
        ThrowControllerPair,
        ThrowControllerConstant,
        ThrowControllerVariable,
        ThrowControllerEvent,
        ThrowControllerPairEvent,
        ThrowControllerThrowControllerFunction,
        ThrowControllerVariableInstancer>, IEquatable<ThrowControllerReference>
    {
        public ThrowControllerReference() : base() { }
        public ThrowControllerReference(ThrowController value) : base(value) { }
        public bool Equals(ThrowControllerReference other) { return base.Equals(other); }
        protected override bool ValueEquals(ThrowController other)
        {
            throw new NotImplementedException();
        }
    }
}
