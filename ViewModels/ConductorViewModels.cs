using Locaserv.Bdv.Api.Models;

namespace Locaserv.Bdv.Api.ViewModels
{
    public record DetailConductorViewModel
    {
        private DetailConductorViewModel(Conductor conductor)
        {
            Uuid = conductor.Uuid;
            Code = conductor.Code;
            Name = conductor.Name;
        }

        public Guid Uuid { get; }
        public string Code { get; }
        public string Name { get; }

        public static explicit operator DetailConductorViewModel(Conductor conductor)
            => new(conductor);
    }

    public record CreateConductorViewMode(string Name, string Code)
    {
        public static explicit operator Conductor(CreateConductorViewMode conductor)
           => new()
           {
               Code = conductor.Code,
               Name = conductor.Name
           };
    }

    public record UpdateConductorViewModel(Guid Uuid, string Name, string Code)
    {
        public static explicit operator Conductor(UpdateConductorViewModel conductor)
            => new()
            {
                Uuid = conductor.Uuid,
                Code = conductor.Code,
                Name = conductor.Name,
            };
    }

    public record DeleteConductorViewMode(Guid Uuid);
}