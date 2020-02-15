using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario
{
    // Start is called before the first frame update
    public String usuario, contraseña;

    public Usuario(String usuario, String contraseña)
    {
        this.usuario = usuario;
        this.contraseña = contraseña;
    }
}