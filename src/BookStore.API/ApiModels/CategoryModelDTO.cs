using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class CategoryModelDTO
    {
        public string Id { set; get; }

        [Required(ErrorMessage = "Category Name Is Required")]
        public string Name { set; get; }

        public static CategoryModelDTO FromCategory(Category item)
        {
            return new CategoryModelDTO
            {
                Name = item.Name,
                Id = item.Id
            };
        }
    }
}