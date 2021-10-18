using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace semanacrup
{
    class fruta
    { 
    //propiedades
        public string  _NOMBRE{ get; set; }
    public int _CANTIDAD  { get; set; }
    public int _PESO  { get; set; }
    public int _PRECIO{ get; set; }


    private Crup crup = new Crup();

  
    public MySqlDataReader getAllBooks()
    {
        string query = "SELECT NOMBRE,CANTIDAD,PESO,PRECIO FROM fruta";

        //llamado al metodo select de la clase Crud
        return crup.select(query);
    }

    //metodo para insertar o editar un registro
    public Boolean newEditBook(string action)
    {
        if (action == "new")
        {
            string query = "INSERT INTO fruta(cantidad, peso ,precio)" +
                "VALUES ('" + _CANTIDAD + "', '" + _PESO + "', '" + _PRECIO + "')";
            crup.executeQuery(query); 
            return true;
        }
        else if (action == "edit")
        {
            string query = "UPDATE fruta SET "
                + "CANTIDAD='" + _CANTIDAD + "' ,"
                + "PESO='" + _PESO + "',"
                + "PRECIO='" + _PRECIO+ "',"
                + "WHERE "
                + "NOMBRE='" + _NOMBRE + "'";
            crup.executeQuery(query);
            return true;
        }

        return false;
    }

  
    public Boolean deletefruta()
    {
        string query = "DELETE FROM fruta WHERE NOMBRE='" + _NOMBRE+ "'";
        crup.executeQuery(query);
        return true;
    }
}
}