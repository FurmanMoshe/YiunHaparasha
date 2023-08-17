using Microsoft.AspNetCore.Mvc;
using System;
using YiunHa.BL;

namespace YiunHa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        MenuimWinningsBL menuimWinningsBl = new MenuimWinningsBL();
        CommonTableSuiteBL commonTableSuiteBl = new CommonTableSuiteBL();
        CommonTableBL commonTableBl = new CommonTableBL();
        CodeMosadotBL codeMosadotBl= new CodeMosadotBL();
        UserBL userBl = new UserBL();
        SystemSettingsBL systemSettingsBl = new SystemSettingsBL();
        CodeIshuvBL codeIshuvBl = new CodeIshuvBL();

        [HttpPost]
        [Route("[action]")]
        public int CreateNewUser([FromBody] User user)
        {
            user.SetCodeMosad();
            user.CodeForMaayan = userBl.GetCodeForMaayan(user);
            user.CodeForReshetMazon = userBl.GetCodeForReshetMazon(user);
            User updatedUser = codeIshuvBl.HandleNewIshuvIfNeeded(user);
            updatedUser = codeMosadotBl.HandleNewMosadIfNeeded(updatedUser);

            return userBl.CreateNewUser(updatedUser);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public object IsTZExists(int id)
        {
            return userBl.IsTZExists(id);
        }

        [HttpGet]
        [Route("[action]/{id}/{code}")]
        public object VerifyCodeManuyByTZ(int id, int code)
        {
            string errorMsg = "";
            bool exists = userBl.VerifyCodeManuyByTZ(id, code);
            if (!exists)
            {
                errorMsg = systemSettingsBl.GetWrongCodeMassege();
            }
            return new ResultD(exists, errorMsg);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ResultB GetUserDetails(int id)
        {
            UserDto user = userBl.GetUserByTZ(id);
            return new ResultB(user,
                systemSettingsBl.CanChangeFoodChain(user));
        }

        [HttpPost]
        [Route("[action]")]
        public void UpdateExistUser([FromBody] User newUser)
        {
            newUser.SetCodeMosad();
            newUser.CodeForMaayan = userBl.GetCodeForMaayan(newUser);
            User updatedUser = codeIshuvBl.HandleNewIshuvIfNeeded(newUser);
            updatedUser = codeMosadotBl.HandleNewMosadIfNeeded(updatedUser);

            userBl.UpdateExistsUser(updatedUser);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ResultC GetManuyInfo(int id)
        {
            ResultC result = new ResultC();
            string[] systemData = systemSettingsBl.GetSystemSettingsData();
            int?[] bigudList = commonTableSuiteBl.GetShovarBigud(id);
            object[] foodChainList = userBl.GetFoodChainInfo(id);
            result.SystemMassege = systemData[0];
            result.MilgaTitle = systemData[1];
            result.AnswerTitle = systemData[2];
            result.AnswerTitleForHalacha = systemData[3];
            result.MilgaValidity = systemData[4];
            result.CodeManuy = userBl.GetCodeManuyByTZ(id);
            result.LastMilga = commonTableBl.GetLastMilga(id);
            result.Shovar = bigudList[0];
            result.ShovarBarkod = bigudList[1];
            result.FoodChain = (Nullable<int>)foodChainList[0];
            result.FoodChainBarkod1 = (Nullable<double>)foodChainList[1];
            result.FoodChainBarkod2 = (Nullable<double>)foodChainList[2];
            result.AnswerToGilyun = menuimWinningsBl.GetAnswersToGilun(id);
            result.HalachaAnswerToGilyun = menuimWinningsBl.GetSystemHalachaAnswersToGilun(id);

            return result;
        }
    }
}
