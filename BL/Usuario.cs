using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PracticaEntities context = new DL.PracticaEntities())
                {
                    if (usuario.Nombre != null)
                    {
                        usuario.Opcion = 1;
                        var query = context.Database.ExecuteSqlCommand($"AddUsuario '{usuario.Opcion}','{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.FechaNacimiento}'");

                        if (query != null)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                    else
                    {
                        var query = context.Database.SqlQuery<ML.Usuario>($"AddUsuario {usuario.Opcion},'{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.FechaNacimiento}'").ToList();
                        if (query.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (var Item in query)
                            {
                                ML.Usuario usuario1 = Item;
                                result.Objects.Add(usuario1);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
