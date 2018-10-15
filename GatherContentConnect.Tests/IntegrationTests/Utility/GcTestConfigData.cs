using System;
using System.Configuration;

namespace GatherContentConnect.Tests.IntegrationTests.Utility
{
    public class GcTestConfigData
    {
        public string Email { get; set; }
        public string ApiKey { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectId { get; set; }
        public int TemplateId { get; set; }
        public int ItemId { get; set; }
        public int StatusId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string ItemName { get; set; }
        public int ParentId { get; set; }

        public GcTestConfigData()
        {
            Email = ConfigurationManager.AppSettings["Email"];
            ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            AccountId = Convert.ToInt32(ConfigurationManager.AppSettings["AccountId"]);
            FirstName = ConfigurationManager.AppSettings["FirstName"];
            LastName = ConfigurationManager.AppSettings["LastName"];
            ProjectId = Convert.ToInt32(ConfigurationManager.AppSettings["ProjectId"]);
            TemplateId = Convert.ToInt32(ConfigurationManager.AppSettings["TemplateId"]);
            ItemId = Convert.ToInt32(ConfigurationManager.AppSettings["ItemId"]);
            StatusId = Convert.ToInt32(ConfigurationManager.AppSettings["StatusId"]);
            ParentId = Convert.ToInt32(ConfigurationManager.AppSettings["ParentId"]);
            ProjectName = ConfigurationManager.AppSettings["ProjectName"];
            ProjectType = ConfigurationManager.AppSettings["ProjectType"];
            ItemName = ConfigurationManager.AppSettings["ItemName"];
        }
    }
}