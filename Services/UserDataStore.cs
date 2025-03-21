using APIsRest.Models;

namespace APIsRest.Services;

public class UserDataStore
{
    public List<Users> Users { get; set; }

    public static UserDataStore Current { get; } = new UserDataStore();

    public UserDataStore()
    {
        Users = new List<Users>() {
            new Users() {
                Id = 1,
                Name = "Alex Adasme",
                Email = "alexadasme74@gmail.com",
                Accesos = new List<Accesos>(){
                    new Accesos(){
                        Id = 2,
                        Name = "Administrador",
                        Rol = Accesos.eROL.Administrador
                    },
                    new Accesos(){
                        Id = 3,
                        Name = "Programador",
                        Rol = Accesos.eROL.Programador
                    }
                }
            },
            new Users() {
                Id = 2,
                Name = "Isidora Pavez",
                Email = "IsiPavez18@gmail.com",
                Accesos = new List<Accesos>(){
                    new Accesos(){
                        Id = 1,
                        Name = "Jefe",
                        Rol = Accesos.eROL.Jefe
                    },
                    new Accesos(){
                        Id = 2,
                        Name = "Administrador",
                        Rol = Accesos.eROL.Administrador
                    }
                }
            },
             new Users() {
                Id = 3,
                Name = "Emanuel Farias",
                Email = "EmaFarias24@gmail.com",
                Accesos = new List<Accesos>(){
                    new Accesos(){
                        Id = 3,
                        Name = "Programador",
                        Rol = Accesos.eROL.Programador
                    },
                     new Accesos(){
                        Id = 4,
                        Name = "Usuario",
                        Rol = Accesos.eROL.Usuario
                    }
                }
            },
             new Users() {
                Id = 4,
                Name = "Cristopher Neira",
                Email = "ChisteNeira@gmail.com",
                Accesos = new List<Accesos>(){
                    new Accesos(){
                        Id = 4,
                        Name = "Usuario",
                        Rol = Accesos.eROL.Usuario
                    }
                }
            },
        };
    }
}


