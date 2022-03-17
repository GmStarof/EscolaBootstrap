using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppaiEstudeEx
{
    public class PrintMenu
    {

        public void MenuPrincipal()
        {
            Console.WriteLine(" Menu do AppaiEstude\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Escolha sua opção de menu: ");
            Console.WriteLine("\t1 - – Gestão de aluno");
            Console.WriteLine("\t2 - – Gestão de professores");
            Console.WriteLine("\t3 - – Currículo escolar");
            Console.WriteLine("\t4 - – Gestão financeira");
            Console.WriteLine("\t0 - – Sair");

            Console.WriteLine("Pressione um numero e aperte Enter");


        }

        public void MenuAluno()
        {
            Console.Clear();

            Console.WriteLine("Escolha sua opção de menu de Alunos: ");
            Console.WriteLine("\t1 - – – Listar Alunos");
            Console.WriteLine("\t2 - – - Cadastrar Alunos");
            Console.WriteLine("\t3 - – - Cadastrar matérias");
            Console.WriteLine("\t4 - – – Cadastrar nota");
            Console.WriteLine("\t5 - – – Excluir Aluno");
            Console.WriteLine("\t6 - – - Voltar para Pagina anterior");

            Console.WriteLine("Pressione um numero e aperte Enter");

        }

        public void MenuProfessor()
        {

            Console.Clear();

            Console.WriteLine("Escolha sua opção de menu Professores : ");
            Console.WriteLine("\t1 - – – Listar Professores");
            Console.WriteLine("\t2 - – - Cadastrar Professores");
            Console.WriteLine("\t3 - – - Cadastrar matérias");
            Console.WriteLine("\t4 - – – Excluir Professor");
            Console.WriteLine("\t5 - – - Voltar para Pagina anterior");

            Console.WriteLine("Pressione um numero e aperte Enter");

        }

        public void MenuCurriculo()
        {
            Console.Clear();

            Console.WriteLine("Escolha sua opção de menu Curriculo Escolar: ");
            Console.WriteLine("\t1 - – – Cadastrar Matéria");
            Console.WriteLine("\t2 - – - Excluir Matéria");
            Console.WriteLine("\t3 - – - Voltar para Pagina anterior");
            Console.WriteLine("Pressione um numero e aperte Enter");
        }

        public void MenuFinancia()
        {
            Console.Clear();

            Console.WriteLine("Escolha sua opção de menu Gestão financeira: ");
            Console.WriteLine("\t1 - – – Listar Professores com pendencia de pagamento");
            Console.WriteLine("\t2 - – - Listar alunos inadimplentes");
            Console.WriteLine("\t3 - – - Dar baixa de pagamento de alunos");
            Console.WriteLine("\t4 - – – Pagar professor");
            Console.WriteLine("\t5 - – - Voltar para Pagina anterior");
            Console.WriteLine("Pressione um numero e aperte Enter");
        }
    }
}
