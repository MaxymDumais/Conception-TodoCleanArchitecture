using CleanTodo.Domain.DTOS.Ships;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.Validators.Ships
{
   public class UpdateShipValidation : AbstractValidator<UpdateShipDto>
   {
      public UpdateShipValidation()
      {

         RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100)
            .WithMessage("Le nom de votre navire doit contenir entre 2 et 100 caractères...");

         RuleFor(x => x.GoldCargo)
            .NotNull()
            .InclusiveBetween(0, 1000000)
            .WithMessage("Le nombre d'or stocké sur le navire doit être entre 0 et 1 000 000...");

         RuleFor(x => x.Captain)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage("Le nom du capitaine de ce navire doit contenir entre 2 et 50 caractères...");

         RuleFor(x => x.CrewSize)
            .NotEmpty()
            .InclusiveBetween(1, 500)
            .WithMessage("Votre équipage peut seulement être constitué de 1 à 500 pirates");
      }
   }
}
