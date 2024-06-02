using CustomCRM.Domain.Primitives;

namespace CustomCRM.Domain.Raids
{
    public class Raid : AggregateRoot
    {
        public RaidId Id { get; set; }
    }
}
