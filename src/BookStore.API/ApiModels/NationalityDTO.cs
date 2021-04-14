using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class NationalityDTO
    {
        public string Id { set; get; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }

        public static NationalityDTO FromNationality(Nationality nationality)
        {
            return new NationalityDTO
            {
                Name = nationality.Name,
                Id = nationality.Id
            };
        }
    }
}