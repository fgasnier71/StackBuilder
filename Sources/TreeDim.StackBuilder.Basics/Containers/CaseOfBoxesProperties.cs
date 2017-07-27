using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class CaseOfBoxesProperties : BoxProperties
    {
        /// <summary>
        /// Instantiate a new case from a box, a case definition and a case optimization constraintset
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="bProperties">Box properties</param>
        /// <param name="constraintSet">Case optimization constraint set</param>
        public CaseOfBoxesProperties(Document document
            , BoxProperties boxProperties
            , CaseDefinition caseDefinition
            , ParamSetPackOptim constraintSet)
            : base(document)
        {
            _boxProperties = boxProperties;
            _boxProperties.AddDependancy(this);
            _caseDefinition = caseDefinition;
            _constraintSet = constraintSet;

            SetWeight( _caseDefinition.CaseEmptyWeight(_boxProperties, _constraintSet));

            OnAttributeModified(boxProperties);
        }

        public BoxProperties InsideBoxProperties => _boxProperties;
        public CaseDefinition CaseDefinition => _caseDefinition;
        public ParamSetPackOptim CaseOptimConstraintSet => _constraintSet;
        public double WeightEmpty
        {
            get { return _caseDefinition.CaseEmptyWeight(_boxProperties, _constraintSet); }
        }

        public override double Weight
        {
            get { return WeightEmpty + _caseDefinition.Arrangement.Number * _boxProperties.Weight; }
        }

        public int NumberOfBoxes => _caseDefinition.Arrangement.Number;

        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            Vector3D outerDim = _caseDefinition.OuterDimensions(_boxProperties, _constraintSet);
            SetLength(outerDim.X);
            SetWidth(outerDim.Y);
            SetHeight(outerDim.Z);

            Vector3D innerDim = _caseDefinition.InnerDimensions(_boxProperties);
            InsideLength = innerDim.X;
            InsideWidth = innerDim.Y;
            InsideHeight = innerDim.Z;
        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            Modify();
            base.OnEndUpdate(updatedAttribute);
        }

        #region Non-Public Members

        private BoxProperties _boxProperties;
        private CaseDefinition _caseDefinition;
        private ParamSetPackOptim _constraintSet;

        protected override void RemoveItselfFromDependancies()
        {
            _boxProperties.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }

        #endregion
    }
}
