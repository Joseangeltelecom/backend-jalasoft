using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Exceptions;
using EcommerceJala.Infrastructure.Repositories;

namespace EcommerceJala.Infrastructure.Validators
{
    public static class CreateItemValidator
    {
        public static void Validate(Item item) 
        {
            int index = new ItemRepository().items.FindIndex(p => p.Name == item.Name);

            if (item == null)
            {
                throw new ItemArgumentExeption($"{nameof(item)} is null.");
            }
            else if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ItemArgumentExeption($"{nameof(item.Name)} is null/Empty.");
            }
            else if (index != -1)
            {
                throw new ItemArgumentExeption($"{nameof(item.Name)} Already Exists.");
            }
            else if (string.IsNullOrWhiteSpace(item.Description))
            {
                throw new ItemArgumentExeption($"{nameof(item.Description)} is null/Empty.");
            }
            else if (item.Price <= 0)
            {
                throw new ItemArgumentExeption($"{nameof(item.Price)} can't be less or equal to zero (0).");
            }
        }
    }

}
