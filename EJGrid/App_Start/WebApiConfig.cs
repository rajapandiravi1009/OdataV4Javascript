using EJGrid.Models;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using static EJGrid.Controllers.OrdersController;

namespace EJGrid
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "WebAPITest";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Orders>("Orders");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
    
}
