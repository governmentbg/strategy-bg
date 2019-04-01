namespace Models.Context.Account
{
  public class CheckBoxListItem
  {
    public int ID { get; set; }
    public int ParentCategoryID { get; set; }
    public string Display { get; set; }
    public bool IsChecked { get; set; }
  }
}

