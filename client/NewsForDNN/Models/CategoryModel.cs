namespace NewsForDNN.Models;

public class CategoryModel
{
    public int ItemId { get; set; } = -1;
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public int AssignedUserId { get; set; }
    public int ModuleId { get; set; }
    public int CreatedByUserId { get; set; } = -1;
    public int LastModifiedByUserId { get; set; } = -1;
    public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedOnDate { get; set; } = DateTime.UtcNow;
}
