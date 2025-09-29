using Entities.Master;

namespace OpenFinanceWebApi.IServices
{
    public interface IChargeMasterMakerService
    {
        IEnumerable<ChargeMasterMakerModel> GetMakerDetails();

        string Addcharge(ChargeMasterMakerModel user);

        ChargeMasterMakerModel GetIndDetails(string SegmentID);

        IEnumerable<ChargeMasterMakerModel> GetSearch(string SegmentID);
        string EditMaster(ChargeMasterMakerModel user);


        string DeleteCharge(ChargeMasterMakerModel model);
        IEnumerable<ChargeMasterMakerModel> ChargeCheckerDetail();

        //ChargeMasterMakerModel GetCheckIndDetails(string Id);

        string ChargeApproveOrReject(ChargeMasterMakerModel CheckerApprRej);

        ChargeMasterMakerModel GetCheckerIndDetails(string SegmentID);




    }
}
