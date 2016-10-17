using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.BusinessData.SharedService;
using Microsoft.SharePoint.BusinessData.MetadataModel;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.BusinessData.Runtime;
namespace BCSRunTime // Set namespace according to your project
{
    class Program // Set class name as per your project
    {
        static void Main(string[] args)
        {
            ExecuteBcsEctMethods(@"http://localhost:81/"); // set your site URL
        }
        static void ExecuteBcsEctMethods(string siteUrl)
        {
            using (SPSite site = new SPSite(siteUrl))
            {
                using (new SPServiceContextScope(SPServiceContext.GetContext(site)))
                {
                    BdcServiceApplicationProxy proxy = (BdcServiceApplicationProxy)SPServiceContext.Current.GetDefaultProxy(typeof(BdcServiceApplicationProxy));
                    DatabaseBackedMetadataCatalog model = proxy.GetDatabaseBackedMetadataCatalog();
                    IEntity entity = model.GetEntity("EmployeeEntityModel.BdcModel1", "Entity1"); // Namespace, Entity name
                    ILobSystemInstance lobSystemInstance = entity.GetLobSystem().GetLobSystemInstances()[0].Value;
                    IMethodInstance method = entity.GetMethodInstance("ReadList", MethodInstanceType.Finder); // Finder method name
                    IView view = entity.GetFinderView(method.Name);

                    IFilterCollection filterCollection = entity.GetDefaultFinderFilters();
                    IEntityInstanceEnumerator entityInstanceEnumerator = entity.FindFiltered(filterCollection, method.Name, lobSystemInstance, OperationMode.Online);
                    Console.WriteLine("Employee Login ID | Job Title");
                    while (entityInstanceEnumerator.MoveNext())
                    {
                        Console.WriteLine(entityInstanceEnumerator.Current["LoginID"].ToString() + " - " + entityInstanceEnumerator.Current["JobTitle"].ToString()); // Column names

                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
