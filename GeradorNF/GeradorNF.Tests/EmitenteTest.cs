using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeradorNF.Model;
using GeradorNF.BLL;
using System.Net.Http;

namespace GeradorNF.Tests
{
    [TestClass]
    public class EmitenteTest
    {
        [TestMethod]
        public void CriarEmitenteSemCNPJ()
        {
            Emitente emitente = new Emitente();
            emitente.Bairro = "Bairro Teste";
            emitente.CEP = "37990000";
            emitente.Cidade = "Ibiraci";
            emitente.CidadeCodigo = 1234;
            emitente.CNAE = "4455";
            emitente.CNPJ = "12345678901234";
            emitente.Complemento = string.Empty;
            emitente.DataCadastro = DateTime.Now;
            emitente.Fone = "3535355414";
            emitente.IM = "12";
            emitente.InscricaoEstadual = "123123123";
            emitente.Logradouro = "rua das flores";
            emitente.NomeFantasia = "Ronaldo Viola";
            emitente.NumeroCasa = "s/n";
            emitente.Pais = "BRASIL";
            emitente.PaisCodigo = 1589;
            emitente.RazaoSocial = "Viola do Ronaldo LTDA";
            emitente.UF = "MG";

            Assert.AreNotEqual(emitente.CNPJ.Length, 0);

        }
    }
}
