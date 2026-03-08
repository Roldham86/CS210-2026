public class Book
{
    private string _title;
    private int _catalogID;
    private bool _isCheckedOut;

    public Book(string title, int catalogID, bool isCheckedOut)
    {
        _title = title;
        _catalogID = catalogID;
        _isCheckedOut = isCheckedOut;
    }
   public Book(string title, int catalogID)
    {
        _title = title;
        _catalogID = catalogID;
    }

        public string getSummery()
    {
        return $"Book: {_title} [ID: {_catalogID}] - Checked Out: {_isCheckedOut}";
    }
}

