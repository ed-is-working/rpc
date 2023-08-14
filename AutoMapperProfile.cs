using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpc
{
    /**
     * This class is used to map DTOs to Models and vice versa
     */
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}