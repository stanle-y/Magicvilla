using Magicvilla_API.modelos.DTO;

namespace Magicvilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO{Id=1, Nombre="vista al mar",Ocupantes=3,MetrosCuadrados=50},
            new VillaDTO{Id=2, Nombre="vista al parque",Ocupantes=4,MetrosCuadrados=90}
        };

    }
}
