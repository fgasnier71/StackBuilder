namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisCylinderTruck :  AnalysisPackableTruck
    {
        public AnalysisCylinderTruck(Document doc, Packable packable, TruckProperties truckProperties, ConstraintSetCylinderTruck constraintSet)
            : base(doc, packable, truckProperties, constraintSet)
        {
        }
    }
}
