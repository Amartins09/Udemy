using System.ComponentModel.DataAnnotations;

namespace MVC.Models{
    public class Product{
        [Required(ErrorMessage="Id não foi informado")]
        public int Id {get;set;}
        
        [Required(ErrorMessage="Name não foi informado")]
        [MinLength(3, ErrorMessage="Tamanho minimo do Nome é 3")]
        public string Name {get;set;}

        [Required(ErrorMessage="Price não foi informado")]
        [Range(1, float.MaxValue, ErrorMessage="Preço deve ser positivo")]
        public float Price {get;set;}
    }
}