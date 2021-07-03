namespace Milburn_Software2
{
    public class Report
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }

        public Report(string column1, string column2)
        {
            Column1 = column1;
            Column2 = column2;
        }

        public Report(string column1, string column2, string column3, string column4)
        {
            Column1 = column1;
            Column2 = column2;
            Column3 = column3;
            Column4 = column4;
        }
    }
}
