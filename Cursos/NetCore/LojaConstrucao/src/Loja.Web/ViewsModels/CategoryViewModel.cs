using System.ComponentModel.DataAnnotations;

namespace Loja.Web.ViewModel{

    public class CategoryViewModel{
        public int Id {get;set;}
        [Required]
        public string Name {get;set;}
    }
}