public interface ICheckoutable
{
    string Title { get; set; }
    bool CheckedOut { get; set; }

}