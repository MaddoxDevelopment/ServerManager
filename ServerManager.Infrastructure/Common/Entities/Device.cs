namespace ServerManager.Infastructure.Common.Entities
{
    public class Device
    {
        public string Id { get; set; }
        public string ShortId { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}