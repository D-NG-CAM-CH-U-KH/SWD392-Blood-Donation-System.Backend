using System.Text.Json.Serialization;

namespace SWD392_BloodDonationSystem.DAL.Data.Metadatas;

public class PagingResponse<T> 
{
    [JsonPropertyName("items")]
    public IEnumerable<T> Items { get; set; }

    [JsonPropertyName("meta")]
    public PaginationMeta Meta { get; set; }
}