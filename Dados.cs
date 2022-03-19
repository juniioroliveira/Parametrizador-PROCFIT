using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parametrizador_PROCFIT
{
    internal class Dados
    {
        public static List<Dados> DadosList = new List<Dados>();
        private string _servidor;
        public string Servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }

        private string _banco;
        public string Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private bool _conectado;
        public bool Conectado
        {
            get { return _conectado; }
            set { _conectado = value; }
        }


        private Dados(string servidor, string banco, string usuario, string senha, bool conectado)
        {
            Servidor = servidor;
            Banco = banco;
            Usuario = usuario;
            Senha = senha;
            Conectado = conectado;

        }

        public static void Armazenar(string _servidor, string _banco, string _usuario, string _senha, bool _conectado)
        {
            DadosList.Clear();

            DadosList.Add(new Dados(
                servidor: _servidor,
                banco: _banco,
                usuario: _usuario,
                senha: _senha,
                conectado: _conectado
                ));
        }


    }
}
