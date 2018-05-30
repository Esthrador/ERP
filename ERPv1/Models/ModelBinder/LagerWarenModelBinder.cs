using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ERPv1.Models.DbContext;
using ERPv1.Models.ViewModels;
using TrackerEnabledDbContext.Common.Extensions;

namespace ERPv1.Models.ModelBinder
{
    public class LagerWarenModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var vm = new LagerWarenViewModel();

            using (var db = new ApplicationDbContext())
            {
                vm.Waren = db.Waren.ToList();
                vm.Lager = db.Lager.Find(bindingContext
                    .ValueProvider.GetValue("Lager.ID").ConvertTo(typeof(Guid)));
                vm.LagerWaren = new List<LagerWaren>();

                // Waren am Lager anpassen
                var formVars = HttpContext.Current.Request.Form;
                foreach (string formKey in formVars)
                {
                    if (formKey.StartsWith("menge_"))
                    {
                        var warenId = formKey.Split('_')[1];
                        var menge = formVars[formKey];

                        vm.LagerWaren.Add(new LagerWaren
                        {
                            Ware = db.Waren.Find(Guid.Parse(warenId)),
                            Lager = vm.Lager,
                            Menge = Convert.ToInt32(menge)
                        });
                    }
                }

            }

            return vm;
        }
    }
}