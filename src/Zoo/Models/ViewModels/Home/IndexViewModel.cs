using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoo.Models.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Animals = new List<AnimalWithEnclosureModel>();
        }

        public IList<AnimalWithEnclosureModel> Animals { get; set; }
    }

    public class AnimalWithEnclosureModel
    {
        public int AnimalId { get;set; }
        public string AnimalName { get; set; }
        public int EnclosureId { get; set; }
        public string EnclosureName { get; set; }
    }
}