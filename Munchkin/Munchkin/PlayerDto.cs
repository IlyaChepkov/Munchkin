using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    public class PlayerDto
    {

        public readonly bool isMale;
        public byte Level { get; private set; }
        public string PlayerName { get; }
        public Profession MunchkinProfession;
        public Race MunchkinRace;
        public List<Cloth> MunchkinInventory = new List<Cloth>();
        public List<Effect> MunchkinEffects = new List<Effect>();
        public bool MunchkinisMale;
        public string Munchkinname;

        internal static PlayerDto GetPlayerDto(Player player)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = pi =>
                pi.GetMethod != null && (pi.GetMethod.IsPublic || pi.GetMethod.IsPrivate);
                cfg.CreateMap<Player, PlayerDto>()
                .IncludeMembers(dest => dest.Munchkin.ToString );
            });

            var mapper = configuration.CreateMapper();

            PlayerDto dto = new PlayerDto();
            dto = mapper.Map(player, dto);
            return dto;
        }
    }
}
