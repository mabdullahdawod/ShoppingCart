//using ShoppingCart.Modal;


//namespace ShoppingCart.Services
//{
//    public class AddingService
//    {
//    }
//}




//using GreenerDashboard.Client.Utilities.Helper;
//using System;
//using System.Threading.Tasks;

//using Greener.Web.Definitions.API.Downloads;
//namespace GreenerDashboard.Client.Services
//{
//    public class MeterDownloadService : IMeterDownload
//    {
//        private readonly IAPIHelper _apiHelper = null;

//        public MeterDownloadService(IAPIHelper apiHelper)
//        {
//            _apiHelper = apiHelper;
//        }

//        //public async Task<string> MeterDataAsExcel(DateTime fromUtc, DateTime toUtc)
//        //{
//        //    string parameter = "?fromUtc=" + fromUtc + "&toUtc=" + toUtc;
//        //    var data = await _apiHelper.GetRequestAsync<string>($"api/1.0/MeterDownload/MeterDataAsExcel/{parameter}");
//        //    return data;
//        //}

//        public async Task<string> MeterDataAsExcel(MeterDownloadParameterDto parameter)
//        {

//            //var data = await _apiHelper.SendPostRequestAsync<string>($"api/1.0/MeterDownload/MeterDataAsExcel/", parameter);
//            //var data = await _apiHelper.SendPostRequestAsync<string>($"api/1.0/MeterDownload/MeterDataAsExcelDeltaYear/", parameter);
//            var data = await _apiHelper.SendPostRequestAsync<string>($"api/1.0/MeterDownload/MeterDataAsExcelConsumption/", parameter);
//            return data;
//        }

//    }

//    //public class MeterDownloadParameterDto
//    //{
//    //    public bool IsExcel { get; set; }
//    //    public DateTime FromUtc { get; set; }
//    //    public DateTime ToUtc { get; set; }


//    //}
//}
