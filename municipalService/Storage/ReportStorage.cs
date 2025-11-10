using municipalService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;



namespace municipalService.Storage
{
    public class ReportStorage
    {
        public static List<ReportFormModel> Reports { get; } = new List<ReportFormModel>();

    }
}
