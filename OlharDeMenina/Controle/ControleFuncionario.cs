﻿using MySql.Data.MySqlClient;
using OlharDeMenina.Modelo;

namespace OlharDeMenina.Controle
{
    internal class ControleFuncionario
    {
        public string AdicionarFuncionarios(Funcionarios funcionario)
        {
            FuncionariosDAO func = new FuncionariosDAO();
            string mensagem = func.Adicionar(funcionario);
            return mensagem;
        }

        public MySqlDataReader RetornarFuncionarios()
        {
            FuncionariosDAO funf = new FuncionariosDAO();
            return funf.RetornaFuncionarios();
        }

        public MySqlDataReader RetornarFuncionarios(int idFunc)
        {
            FuncionariosDAO funf = new FuncionariosDAO();
            return funf.RetornaFuncionarios(idFunc);
        }

        public string DeletarFuncionario(int idFunc)
        {
            FuncionariosDAO funf = new FuncionariosDAO();
            return funf.DeletarFuncionarios(idFunc);
        }

        public string EditarFuncionario(Funcionarios funcionarios, int idFunc)
        {
            FuncionariosDAO funf = new FuncionariosDAO();
            string mensagem = funf.EditarFuncionarios(funcionarios, idFunc);

            return mensagem;
        }
    }
}