namespace Supabase.API.Contracts;

public class CreateNewsLetterRequest 
{
    public string Name { get; set; }    
    public string Description { get; set; }    
    public int ReadTime { get; set; }    
}
