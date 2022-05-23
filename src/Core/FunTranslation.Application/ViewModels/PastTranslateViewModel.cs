using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels
{
    public class PastTranslateViewModel
    {
        public PastTranslateViewModel()
        {
            this.PastTranslations = new List<PastTranslation>();
        }
        public List<PastTranslation> PastTranslations { get; set; }
        public string? UserId { get; set; }
        public string? LanguageId { get; set; }
    }
}
