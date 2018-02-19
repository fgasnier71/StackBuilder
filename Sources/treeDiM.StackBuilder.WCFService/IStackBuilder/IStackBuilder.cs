using System.ServiceModel;

namespace treeDiM.StackBuilder.WCFService
{
    [ServiceContract]
    public interface IStackBuilder
    {
        [OperationContract]
        DCSBSolution SB_GetBestSolution(
            DCSBCase sbCase, DCSBPallet sbPallet, DCSBInterlayer sbInterlayer
            , DCSBConstraintSet sbConstraintSet
            , DCCompFormat expectedFormat, bool showCotations);
    }
}
