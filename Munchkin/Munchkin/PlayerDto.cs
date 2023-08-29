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

        public bool IsMale { get; set; }
        public byte Level { get; set; }
        public string PlayerName { get; set; }
        public Profession MunchkinProfession { get; set; }
        public Race MunchkinRace { get; set; }
        public List<Cloth> MunchkinInventory { get; set; }
        public List<Effect> MunchkinEffects { get; set; }
        public bool MunchkinIsMale { get; set; }
        public string MunchkinName { get; set; }

        internal static PlayerDto GetPlayerDto(Player player)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = pi =>
                pi.GetMethod != null && (pi.GetMethod.IsPublic || pi.GetMethod.IsPrivate);
            });

            var mapper = configuration.CreateMapper();

            PlayerDto dto = new PlayerDto();
            dto = mapper.Map(player, dto);
            return dto;
        }
    }
}
