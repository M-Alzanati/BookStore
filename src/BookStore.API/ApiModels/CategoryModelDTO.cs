using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class CategoryModelDTO
    {
        [Required(ErrorMessage = "Category Name Is Required")]
        public string Name { set; get; }

        public static CategoryModelDTO FromAuthor(Category item)
        {
            return new CategoryModelDTO
            {
                Name = item.Name,
            };
        }
    }
}