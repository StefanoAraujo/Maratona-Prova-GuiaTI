using Newtonsoft.Json;

namespace GuiaTI.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
