using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisCylinderPallet : AnalysisPackablePallet
    {
        public AnalysisCylinderPallet(
            Packable packable,
            PalletProperties palletProperties,
            ConstraintSetPackablePallet constraintSet)
            : base(packable, palletProperties, constraintSet)
        {
        }

        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            return loadBBox;
        }
    }
}
