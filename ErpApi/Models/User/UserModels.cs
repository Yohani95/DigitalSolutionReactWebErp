
using ErpApi.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.User
{
    public class UserModels
    {
        [Key]
        public int id_usuario { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string nombre_usuario { get; set; }
        public string Password { get; set; }
        public int cargo { get; set; }
        public byte[] foto_perfil{ get; set; }
        public string nombreFoto { get; set; }
        [ForeignKey("cargo")]
        public virtual RolesModels roles { get; set; }
    }
}
