using Postgrest.Attributes ;
using Postgrest.Models;

namespace Supabase.API.Models;

[Table("newsletter")]
public class NewsLetter : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("read_time")]
    public int ReadTime { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}