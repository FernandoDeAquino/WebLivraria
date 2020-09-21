using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLivraria.Business;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    public class LivrosDados
    {
        #region CRUD de livros

        public void IncluirLivro(string titulo, string editora, int edicao, string anopublic, decimal valor, string assunto, string autor)
        {
            livro livro = new livro();
            ManterLivro manterLivro = new ManterLivro();

            livro.TitLivro = titulo;
            livro.EditaLivro = editora;
            livro.EdicaoLivro = edicao;
            livro.AnoPublicacao = anopublic;
            livro.PrecoLivro = valor;
            livro.AssuntoLivro = assunto;
            livro.AutorLivro = autor;

            manterLivro.InserirLivro(livro);

            // Atualização das tabelas Livro_Assunto e Livro_Autor
            livroAssunto livroAssunto = new livroAssunto();
            livroAssunto.CodDoLivro_Assunto = livro.CodigoLivro;
            livroAssunto.CodDoAssunto = int.Parse(assunto);

            ManterLivroAssunto manterLivroAssunto = new ManterLivroAssunto();
            manterLivroAssunto.InserirLivroAssunto(livroAssunto);

            livroAutores livroAutor = new livroAutores();
            livroAutor.CodDoLivro_Autor = livro.CodigoLivro;
            livroAutor.CodDoAutor = int.Parse(autor);

            ManterLivroAutor mntLivroAutor = new ManterLivroAutor();
            mntLivroAutor.InserirLivroAutor(livroAutor);

        }

        public void ExcluirLivro(Int32 codigo, Int32 assunto, Int32 autor)
        {

            livro livro = new livro();
            ManterLivro manterLivro = new ManterLivro();
            livro.CodigoLivro = codigo;
            manterLivro.ExcluirLivro(livro.CodigoLivro);
        }

        public void AtualizaLivro(Int32 codLivro, string titulo, string editora, int edicao, string anopublic, decimal valor, Int32 assunto, Int32 autor)
        {
            livro livro = new livro();
            ManterLivro manterLivro = new ManterLivro();
            livro.CodigoLivro = codLivro;
            livro.TitLivro = titulo;
            livro.EditaLivro = editora;
            livro.EdicaoLivro = edicao;
            livro.AnoPublicacao = anopublic;
            livro.PrecoLivro = valor;
            manterLivro.AtualizaLivro(livro);

            // Atualização das tabelas Livro_Assunto e Livro_Autor
            livroAssunto livroAssunto = new livroAssunto();
            livroAssunto.CodDoLivro_Assunto = livro.CodigoLivro;
            livroAssunto.CodDoAssunto = assunto;
            ManterLivroAssunto manterLivroAssunto = new ManterLivroAssunto();
            manterLivroAssunto.AtualizaLivroAssunto(livroAssunto);


            livroAutores livroAutor = new livroAutores();
            livroAutor.CodDoLivro_Autor = livro.CodigoLivro;
            livroAutor.CodDoAutor = autor;

            ManterLivroAutor manterLivroAutor = new ManterLivroAutor();
            manterLivroAutor.AtualizarLivroAutor(livroAutor);

        }

        #endregion

        #region CRUD de autores

        public void IncluirAutor(string nome)
        {
            autor autor = new autor();
            ManterAutor manterAutor = new ManterAutor();

            autor.NomeAutor = nome;
            manterAutor.InserirAutor(autor);
        }

        public void ExcluirAutor(Int32 codigo)
        {
            autor autor = new autor();
            ManterAutor manterAutor = new ManterAutor();
            autor.CodigoAutor = codigo;
            manterAutor.ExcluirAutor(autor.CodigoAutor);
        }


        #endregion

        #region CRUD de assuntos

        public void IncluirAssunto(string descricao)
        {
            assunto assunto = new assunto();
            ManterAssunto manterAssunto = new ManterAssunto();
            assunto.DescAssunto = descricao;
            manterAssunto.InserirAssunto(assunto);
        }

        public void ExcluirAssunto(Int32 codigo)
        {
            assunto assunto = new assunto();
            ManterAssunto manterAssunto = new ManterAssunto();
            assunto.CodigoAssunto = codigo;
            manterAssunto.ExcluirAssunto(assunto.CodigoAssunto);
        }

        #endregion

    }
}