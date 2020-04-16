using System.Data;
namespace ProyectoReact.Data
{
    public static class ApplicationUser
    {
        internal static DataTable ListUser()
        {
            using (var table = new DataTable())
            {
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");
                table.NewRow();
                table.NewRow();
                table.NewRow();
                table.NewRow();
                table.NewRow();
                table.NewRow();
                table.NewRow();
                table.Rows.Add(new object[] { 1, "Oscar" });
                table.Rows.Add(new object[] { 2, "Brian" });
                table.Rows.Add(new object[] { 3, "Joel" });
                table.Rows.Add(new object[] { 4, "Ivan" });
                table.Rows.Add(new object[] { 5, "Ana" });
                table.Rows.Add(new object[] { 6, "Rodrigo" });
                table.Rows.Add(new object[] { 7, "Elian" });
                return table;
            }
        }
    }
}
