using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.User
{
    public class RolesModels
    {
        [Key]
        public int id_rol { get; set; }
        public string nombre_rol{ get; set; }
    }
}
